using FS.Configuration;
using FS.Log;
using FS.Message.Structure;
using FS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FS.Logistics.Server
{
    public class LogisticsControl
    {
        public bool Create501Message(LogisticsHead logisticsHead)
        {
            bool isSuccess = true;
            BaseSubscribe baseSubscribe = null;
            XElement xele = null;
            XNamespace ns = null;
            try
            {
                Logs.Debug("Create501Message Start!" + logisticsHead.orderNo);
                baseSubscribe = GetBaseSubscribe();
                ns = "http://www.chinaport.gov.cn/ceb";
                xele = new XElement(ns + "CEB501Message");
                xele.SetAttributeValue(XNamespace.Xmlns + "ceb", ns);
                xele = logisticsHead.ToXElememt(xele, ns);
                xele = baseSubscribe.ToXElememt(xele, ns);
                FileUtilities.CreateFolder(ConfigurationInfo.PathSend);
                xele.Save(ConfigurationInfo.PathSend + "\\" + logisticsHead.orderNo + "_501.xml");
                Logs.Debug("Create501Message End! OrderNo_" + logisticsHead.orderNo);
            }
            catch (Exception ex)
            {
                Logs.Error("Create501Message Exception: " + ex.ToString());
                isSuccess = false;
            }
            return isSuccess;
        }

        public bool Create503Message(LogisticsStatus logisticsStatus)
        {
            bool isSuccess = true;
            BaseSubscribe baseSubscribe = null;
            XElement xele = null;
            XNamespace ns = null;
            try
            {
                Logs.Debug("Create503Message Start! OrderNo_" + logisticsStatus.logisticsNo);
                baseSubscribe = GetBaseSubscribe();
                ns = "http://www.chinaport.gov.cn/ceb";
                xele = new XElement(ns + "CEB503Message");
                xele.SetAttributeValue(XNamespace.Xmlns + "ceb", ns);
                xele = logisticsStatus.ToXElememt(xele, ns);
                xele = baseSubscribe.ToXElememt(xele, ns);
                FileUtilities.CreateFolder(ConfigurationInfo.PathSend);
                xele.Save(ConfigurationInfo.PathSend + "\\" + logisticsStatus.logisticsNo + "_" + logisticsStatus.logisticsStatus + "_503.xml");
                Logs.Debug("Create503Message End! OrderNo_" + logisticsStatus.logisticsNo);
            }
            catch (Exception ex)
            {
                Logs.Error("Create503Message Exception: " + ex.ToString());
                isSuccess = false;
            }
            return isSuccess;
        }
        private BaseSubscribe GetBaseSubscribe()
        {
            BaseSubscribe result = null;
            try
            {
                result = new BaseSubscribe();
                result.status = "ALL";
                result.dxpMode = "DXP";
                result.dxpAddress = "DXPENT0000001110"; ;
                result.note = null;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}