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
            MessageService msService = null;
            try
            {
                orderHead = new OrderHead();
                orderLists = new List<OrderList>();
                mssql = new MessageSql();
                mssql.QueryData301(orderNo, ref orderHead, ref orderLists, ref logisticsNo);
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
                    xele.Save(ConfigurationInfo.PathSend + "\\" + FileUtilities.GetNewFileName(orderNo) + ".xml");

                    string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "301") + "\\" + FileUtilities.GetNewFileName(orderNo) + ".xml";

                    msService = new MessageService();
                    msService.DealMessage301(orderNo, orderHead.orderNo, logisticsNo, false, true, orderHead.guid.ToString(), destPath);

                    xele.Save(destPath);
                }
                else
                {
                    Logs.Info("Does not exist in database: " + orderNo);
                }
            }
            catch (Exception ex)
            {
                Logs.Error("Create301Message Exception:" + ex.ToString());
                success = false;
            }
            return success;
        }
        public bool CreateMessage501(string orderNoFake)
        {
            bool success = true;
            LogisticsHead logisticsHead = null;
            MessageSql mssql = null;
            try
            {
                mssql = new MessageSql();
                logisticsHead = new LogisticsHead();
                mssql.QueryData501(orderNoFake, ref logisticsHead);
                RestRequest restRequest = new RestRequest(string.Format("{0}:{1}/Logistics/Create501", ConfigurationInfo.RestHost, ConfigurationInfo.RestPort), Utilities.JsonSerialize(logisticsHead));
                success = Convert.ToBoolean(restRequest.Execute());
                if (success)
                {
                    mssql.UpdateSchedule501(orderNoFake, logisticsHead.billNo);
                }
                else
                {
                    Logs.Info("Create501Message Response Error! Date:" + Utilities.JsonSerialize(logisticsHead));
                }

            }
            catch (Exception ex)
            {
                success = false;
                Logs.Error("Create501Message Exception : " + ex.ToString());
            }
            return success;
        }
        public bool CreateMessage503(string logisticsNo, string orderNoFake)
        {
            bool success = true;
            LogisticsStatus logisticsStatus = null;
            MessageSql mssql = null;
            MessageService msService = null;
            try
            {
                logisticsStatus = new LogisticsStatus();
                mssql = new MessageSql();
                if (string.IsNullOrEmpty(orderNoFake))
                {
                    mssql.QueryData503ByLogisticsNo(logisticsNo, ref logisticsStatus);
                }
                else
                {
                    mssql.QueryDate503ByOrderNo(orderNoFake, ref logisticsStatus);
                }
                RestRequest restRequest = new RestRequest(string.Format("{0}:{1}/Logistics/Create503", ConfigurationInfo.RestHost, ConfigurationInfo.RestPort), Utilities.JsonSerialize(logisticsStatus));
                success = Convert.ToBoolean(restRequest.Execute());
                if (success)
                {
                    mssql.UpdateSchedule503(logisticsNo, orderNoFake);

                    //string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "503") + "\\" + FileUtilities.GetNewFileName(logisticsStatus.logisticsNo) + ".xml";

                    //msService = new MessageService();
                    //msService.DealMessage503(false, true, logisticsStatus.guid.ToString(), logisticsStatus.logisticsNo, "");
                }
                else
                {
                    Logs.Info("Create503Message Response Error! Date:" + Utilities.JsonSerialize(logisticsStatus));
                }
            }
            catch (Exception ex)
            {
                success = false;
                Logs.Error("CreateMessage503 Exception : " + ex.ToString());
            }
            return success;
        }

        public static void CreateMessage601(object param)
        {
            InventoryHead inventoryHead = null;
            List<InventoryList> inventoryLists = null;
            BaseSubscribe baseSubscribe = null;
            XElement xele = null;
            XNamespace ns = null;
            MessageSql mssql = null;
            MessageService msService = null;
            try
            {
                string logisticsNo = param.ToString();
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
                }
            }
            catch (Exception ex)
            {
                Logs.Error("Create301Message Exception:" + ex.ToString());
            }
        }
    }
}
