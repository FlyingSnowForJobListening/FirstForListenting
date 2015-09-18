﻿using FS.Cache;
using FS.Configuration;
using FS.Log;
using FS.Message.Structure;
using FS.Rest;
using FS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FS.Message.Controller
{
    public class MessageControl
    {
        public bool CreateMessage301(string orderNo)
        {
            bool success = true;
            OrderHead orderHead = null;
            List<OrderList> orderLists = null;
            XElement xele = null;
            XNamespace ns = null;
            MessageSql mssql = null;
            string logisticsNo = null;
            string logisticsCode = null;
            MessageService msService = null;
            try
            {
                orderHead = new OrderHead();
                orderLists = new List<OrderList>();
                mssql = new MessageSql();
                mssql.QueryData301(orderNo, ref orderHead, ref orderLists, ref logisticsNo, ref logisticsCode);
                if (orderHead.guid != new Guid())
                {
                    ns = "http://www.chinaport.gov.cn/ceb";
                    xele = new XElement(ns + "CEB301Message");
                    xele.SetAttributeValue(XNamespace.Xmlns + "ceb", ns);
                    xele = orderHead.ToXElememt(xele, ns);
                    foreach (var a in orderLists)
                    {
                        xele = a.ToXElememt(xele, ns);
                    }
                    FileUtilities.CreateFolder(ConfigurationInfo.PathSend);

                    string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "301") + "\\" + FileUtilities.GetNewFileName(orderNo) + ".xml";

                    msService = new MessageService();
                    success = msService.DealMessage301(orderNo, orderHead.orderNo, logisticsNo, false, true, orderHead.guid.ToString(), destPath);
                    if (!success)
                    {
                        destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUpError, "301") + "\\" + FileUtilities.GetNewFileName(orderNo) + ".xml";
                    }
                    xele.Save(ConfigurationInfo.PathSend + "\\" + FileUtilities.GetNewFileName(orderNo) + ".xml");
                    xele.Save(destPath);
                    if (ConfigurationInfo.Need501)
                    {
                        MessageCache.AddMessageCache("501_" + orderHead.orderNo, CacheInfo.SetCacheInfo("501", new { OrderNoFake = orderHead.orderNo, LogisticsCode = logisticsCode }));
                        CacheInfo cache503R = CacheInfo.SetCacheInfo("503R", new { logisticsNo = logisticsNo, logisticsCode = logisticsCode });
                        cache503R.createTime = DateTime.Now.AddMinutes(5);
                        MessageCache.AddMessageCache("503R_" + logisticsNo, cache503R);
                        CacheInfo cache601 = CacheInfo.SetCacheInfo("601", new { LogisticsNo = logisticsNo, LogisticsCode = logisticsCode });
                        cache601.createTime = DateTime.Now.AddMinutes(10);
                        MessageCache.AddMessageCache("601_" + logisticsNo, cache601);
                    }
                }
                else
                {
                    Logs.Info("Does not exist in database: " + orderNo);
                    success = false;
                }
            }
            catch (Exception ex)
            {
                Logs.Error("Create301Message Exception:" + ex.ToString());
                success = false;
            }
            return success;
        }
        public bool CreateMessage501(string orderNoFake, string logisticsCode)
        {
            bool success = true;
            LogisticsHead logisticsHead = null;
            MessageSql mssql = null;
            MessageService msService = null;
            XElement xele = null;
            XNamespace ns = null;
            try
            {
                mssql = new MessageSql();
                logisticsHead = new LogisticsHead();
                mssql.QueryData501(orderNoFake, ref logisticsHead);

                if (logisticsHead.guid != new Guid())
                {
                    RestRequest restRequest = new RestRequest(string.Format("{0}:{1}/Logistics/Create501", ConfigurationInfo.RestHost, ConfigurationInfo.RestPort), Utilities.JsonSerialize(logisticsHead));
                    success = Convert.ToBoolean(restRequest.Execute());
                }
                else
                {
                    success = false;
                }
                if (success)
                {
                    mssql.UpdateSchedule501(orderNoFake, logisticsHead.billNo);

                    ns = "http://www.chinaport.gov.cn/ceb";
                    xele = new XElement(ns + "CEB501Message");
                    xele.SetAttributeValue(XNamespace.Xmlns + "ceb", ns);
                    xele = logisticsHead.ToXElememt(xele, ns);

                    string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "501") + "\\" + FileUtilities.GetNewFileName(orderNoFake, "Create") + ".xml";

                    xele.Save(destPath);

                    msService = new MessageService();
                    msService.DealMessage501(false, true, logisticsHead.guid.ToString(), orderNoFake, logisticsHead.logisticsNo, destPath);
                }
                else
                {
                    Logs.Info("Create501Message Response Error! Date:" + Utilities.JsonSerialize(logisticsHead));
                }
            }
            catch (Exception ex)
            {
                success = false;
                Logs.Error("Create501Message Exception: " + ex.ToString());
            }
            finally
            {
                if (!success)
                {
                    MessageCache.DeleteMessageCache("503R" + logisticsHead.logisticsNo);
                    MessageCache.DeleteMessageCache("601" + logisticsHead.logisticsNo);
                }
            }
            return success;
        }
        public bool CreateMessage503R(string logisticsNo, string logisticsCode)
        {
            bool success = true;
            LogisticsStatus logisticsStatus = null;
            MessageSql mssql = null;
            MessageService msService = null;
            XElement xele = null;
            XNamespace ns = null;
            try
            {
                mssql = new MessageSql();
                logisticsStatus = new LogisticsStatus();
                mssql.QueryData503ByLogisticsNo(logisticsNo, ref logisticsStatus);
                if (logisticsStatus.guid != new Guid())
                {
                    RestRequest restRequest = new RestRequest(string.Format("{0}:{1}/Logistics/Create503", ConfigurationInfo.RestHost, ConfigurationInfo.RestPort), Utilities.JsonSerialize(logisticsStatus));
                    success = Convert.ToBoolean(restRequest.Execute());
                }
                else
                {
                    success = false;
                }
                if (success)
                {
                    mssql.UpdateSchedule503(null, logisticsNo);

                    ns = "http://www.chinaport.gov.cn/ceb";
                    xele = new XElement(ns + "CEB503Message");
                    xele.SetAttributeValue(XNamespace.Xmlns + "ceb", ns);
                    xele = logisticsStatus.ToXElememt(xele, ns);

                    string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "503") + "\\" + FileUtilities.GetNewFileName(logisticsNo, "Create", "R") + ".xml";

                    xele.Save(destPath);

                    msService = new MessageService();
                    msService.DealMessage503(false, true, logisticsStatus.guid.ToString(), logisticsNo, destPath, "R");
                }
                else
                {
                    success = false;
                    Logs.Info("CreateMessage503R Response Error! Date:" + Utilities.JsonSerialize(logisticsStatus));
                }
            }
            catch (Exception ex)
            {
                success = false;
                Logs.Error("CreateMessage503R Exception: " + ex.ToString());
            }
            return success;
        }
        public bool CreateMessage503L(string orderNoFake, string logisticsCode)
        {
            bool success = true;
            LogisticsStatus logisticsStatus = null;
            MessageSql mssql = null;
            MessageService msService = null;
            XElement xele = null;
            XNamespace ns = null;
            try
            {
                mssql = new MessageSql();
                logisticsStatus = new LogisticsStatus();
                mssql.QueryDate503ByOrderNo(orderNoFake, ref logisticsStatus);
                if (logisticsStatus.guid != new Guid())
                {
                    RestRequest restRequest = new RestRequest(string.Format("{0}:{1}/Logistics/Create503", ConfigurationInfo.RestHost, ConfigurationInfo.RestPort), Utilities.JsonSerialize(logisticsStatus));
                    success = Convert.ToBoolean(restRequest.Execute());
                }
                else
                {
                    success = false;
                }
                if (success)
                {
                    mssql.UpdateSchedule503(orderNoFake, null);

                    ns = "http://www.chinaport.gov.cn/ceb";
                    xele = new XElement(ns + "CEB503Message");
                    xele.SetAttributeValue(XNamespace.Xmlns + "ceb", ns);
                    xele = logisticsStatus.ToXElememt(xele, ns);

                    string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "503") + "\\" + FileUtilities.GetNewFileName(logisticsStatus.logisticsNo, "Create", "L") + ".xml";

                    msService = new MessageService();
                    msService.DealMessage503(false, true, logisticsStatus.guid.ToString(), logisticsStatus.logisticsNo, destPath, "L");
                }
                else
                {
                    success = false;
                    Logs.Info("CreateMessage503L Response Error! Date:" + Utilities.JsonSerialize(logisticsStatus));
                }
            }
            catch (Exception ex)
            {
                success = false;
                Logs.Error("CreateMessage503L Exception: " + ex.ToString());
            }
            return success;
        }
        public bool CreateMessage601(string logisticsNo)
        {
            bool success = true;
            InventoryHead inventoryHead = null;
            List<InventoryList> inventoryLists = null;
            BaseSubscribe baseSubscribe = null;
            XElement xele = null;
            XNamespace ns = null;
            MessageSql mssql = null;
            MessageService msService = null;
            try
            {
                inventoryHead = new InventoryHead();
                inventoryLists = new List<InventoryList>();
                baseSubscribe = new BaseSubscribe();
                mssql = new MessageSql();
                mssql.QueryDate601(logisticsNo, ref inventoryHead, ref inventoryLists, ref baseSubscribe);
                if (inventoryHead.guid != new Guid())
                {
                    ns = "http://www.chinaport.gov.cn/ceb";
                    xele = new XElement(ns + "CEB601Message");
                    xele.SetAttributeValue(XNamespace.Xmlns + "ceb", ns);
                    xele = inventoryHead.ToXElememt(xele, ns);
                    foreach (var a in inventoryLists)
                    {
                        xele = a.ToXElememt(xele, ns);
                    }
                    xele = baseSubscribe.ToXElememt(xele, ns);
                    FileUtilities.CreateFolder(ConfigurationInfo.PathSend);
                    xele.Save(ConfigurationInfo.PathSend + "\\" + FileUtilities.GetNewFileName(inventoryHead.orderNo) + "_601.xml");

                    string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "601") + "\\" + FileUtilities.GetNewFileName(inventoryHead.orderNo, "Create") + ".xml";

                    msService = new MessageService();
                    msService.DealMessage601(false, true, inventoryHead.guid.ToString(), inventoryHead.copNo, destPath);

                    xele.Save(destPath);
                }
                else
                {
                    Logs.Info("Does not exist in database:" + logisticsNo);
                    success = false;
                }
            }
            catch (Exception ex)
            {
                Logs.Error("Create301Message Exception:" + ex.ToString());
                success = false;
            }
            return success;
        }
    }
}
