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
                ns = "http://www.chinaport.gov.cn/ceb";
                xele = new XElement(ns + "CEB301Message");
                xele.SetAttributeValue(XNamespace.Xmlns + "ceb", ns);
                xele = orderHead.ToXElememt(xele, ns);
                foreach (var a in orderLists)
                {
                    xele = a.ToXElememt(xele, ns);
                }
                FileUtilities.CreateFolder(ConfigurationInfo.PathSend);
                xele.Save(ConfigurationInfo.PathSend + "\\" + orderNo + "_301.xml");

                string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "301") + "\\" + FileUtilities.GetNewFileName(orderNo) + ".xml";

                msService = new MessageService();
                msService.DealMessage301(orderNo, orderHead.orderNo, logisticsNo, false, true, orderHead.guid.ToString(), destPath);

                xele.Save(destPath);
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
