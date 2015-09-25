using FS.Cache;
using FS.Configuration;
using FS.Database;
using FS.Log;
using FS.Message.Controller;
using FS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FS.Message.Receiption
{
    public class ReceiptHelper
    {
        public static void OnProgressReceipt(object param)
        {
            try
            {
                string path = param.ToString();
                QueueCache.AddQueueCache(path);
                ReceiptThread.AwakenThread();
            }
            catch (Exception ex)
            {
            }
        }

        public static void DealWith301(XElement xElement, string path)
        {
            MessageService msService = null;
            try
            {
                IEnumerable<XElement> eles = xElement.Elements().First().Elements();
                string orderNoFake = eles.Where(e => e.Name.LocalName == "orderNo").First().Value;
                string orderNo = orderNoFake.Substring(0, orderNoFake.IndexOf('_'));

                string fileName = FileUtilities.GetNewFileName() + ".xml";
                string fileDestFolder = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "301");
                FileUtilities.FileMove(path, fileDestFolder + "\\" + fileName);

                //msService.DealMessage301(orderNo, orderNoFake, )
            }
            catch (Exception ex)
            {
                Logs.Error("DealWith301 Exception: " + ex.ToString());
            }
        }
        public static void DealWith302(XElement xElement, string path)
        {
            ReceiptSql sqlserver = null;
            MessageService msService = null;
            try
            {
                IEnumerable<XElement> eles = xElement.Elements().First().Elements();
                string guid = eles.Where(e => e.Name.LocalName == "guid").First().Value;
                string orderNoFake = eles.Where(e => e.Name.LocalName == "orderNo").First().Value;
                string status = eles.Where(e => e.Name.LocalName == "returnStatus").First().Value;
                string returnTime = eles.Where(e => e.Name.LocalName == "returnTime").First().Value;
                string returnInfo = eles.Where(e => e.Name.LocalName == "returnInfo").First().Value;

                sqlserver = new ReceiptSql();
                sqlserver.Operate302(orderNoFake, status, returnInfo);

                string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "302") + "\\" + FileUtilities.GetNewFileName(orderNoFake, status) + ".xml";

                msService = new MessageService();
                bool success = msService.DealMessage302(orderNoFake, guid, status, returnTime, returnInfo, destPath);
                if (!success)
                {
                    destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUpError, "302") + "\\" + FileUtilities.GetNewFileName(orderNoFake, status) + ".xml";
                }
                FileUtilities.FileMove(path, destPath);
                if (ConfigurationInfo.Need501 && status.Equals("120"))
                {

                    CacheInfo info = MessageCache.GetCacheByKey("501" + orderNoFake);
                    MessageCache.DeleteMessageCache("501" + orderNoFake);
                    string logisticCode = null;
                    if (info != null)
                    {
                        logisticCode = ((dynamic)info.value).LogisticCode;
                    }
                    else
                    {
                        logisticCode = msService.GetLogisticCodeByOrderNoFake(orderNoFake);
                    }
                    if (MessageControl.CheckNeedSendLogistics(logisticCode))
                    {
                        MessageControl msControl = new MessageControl();
                        msControl.CreateMessage501(orderNoFake);
                    }
                }
            }
            catch (Exception ex)
            {
                BackUpForError(path);
                Logs.Error("DealWith302 Exception: " + ex.ToString());
            }
        }
        public static void DealWith501(XElement xElement, string path)
        {
            ReceiptSql sqlserver = null;
            MessageService msService = null;
            try
            {
                IEnumerable<XElement> eles = xElement.Elements().First().Elements();
                string guid = eles.Where(e => e.Name.LocalName == "guid").First().Value;
                string billNo = eles.Where(e => e.Name.LocalName == "billNo").First().Value;
                string orderNoFake = eles.Where(e => e.Name.LocalName == "orderNo").First().Value;
                string logisticsNo = eles.Where(e => e.Name.LocalName == "logisticsNo").First().Value;
                string weigth = eles.Where(e => e.Name.LocalName == "weight").First().Value;
                string freight = eles.Where(e => e.Name.LocalName == "freight").First().Value;
                string logisticsCode = eles.Where(e => e.Name.LocalName == "logisticsCode").First().Value;

                if (!MessageControl.CheckNeedSendLogistics(logisticsCode))
                {
                    sqlserver = new ReceiptSql();
                    sqlserver.Operate501(orderNoFake, billNo, weigth, freight);

                    string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "501") + "\\" + FileUtilities.GetNewFileName(orderNoFake) + ".xml";

                    msService = new MessageService();
                    bool success = msService.DealMessage501(true, false, guid, orderNoFake, logisticsNo, destPath);
                    if (!success)
                    {
                        destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUpError, "501") + "\\" + FileUtilities.GetNewFileName(orderNoFake) + ".xml";
                    }

                    CacheInfo cache601 = CacheInfo.SetCacheInfo("601", Utilities.SetArrayList(logisticsNo, logisticsCode));
                    cache601.createTime = DateTime.Now.AddMinutes(1);
                    MessageCache.AddMessageCache("601_" + logisticsNo, cache601);

                    FileUtilities.FileMove(path, destPath);
                }
            }
            catch (Exception ex)
            {
                BackUpForError(path);
                Logs.Error("DealWith501 Exception: " + ex.ToString());
            }
        }
        public static void DealWith502(XElement xElement, string path)
        {
            ReceiptSql sqlserver = null;
            MessageService msService = null;
            try
            {
                IEnumerable<XElement> eles = xElement.Elements().First().Elements();
                string guid = eles.Where(e => e.Name.LocalName == "guid").First().Value;
                string logisticsNo = eles.Where(e => e.Name.LocalName == "logisticsNo").First().Value;
                string status = eles.Where(e => e.Name.LocalName == "returnStatus").First().Value;
                string returnTime = eles.Where(e => e.Name.LocalName == "returnTime").First().Value;
                string returnInfo = eles.Where(e => e.Name.LocalName == "returnInfo").First().Value;
                string logisticsCode = eles.Where(e => e.Name.LocalName == "logisticsCode").First().Value;

                sqlserver = new ReceiptSql();
                sqlserver.Operate502(logisticsNo, status, returnInfo);

                string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "502") + "\\" + FileUtilities.GetNewFileName(logisticsNo, status) + ".xml";

                msService = new MessageService();
                bool success = msService.DealMessage502(logisticsNo, guid, status, returnTime, returnInfo, destPath);
                if (!success)
                {
                    destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUpError, "502") + "\\" + FileUtilities.GetNewFileName(logisticsNo, status) + ".xml";
                }

                FileUtilities.FileMove(path, destPath);
                if (MessageControl.CheckNeedSendLogistics(logisticsCode) && status.Equals("120"))
                {
                    MessageCache.DeleteMessageCache("503R" + logisticsNo);
                    MessageControl msControl = new MessageControl();
                    msControl.CreateMessage503R(logisticsNo);
                }
            }
            catch (Exception ex)
            {
                Logs.Error("DealWith502 Exception: " + ex.ToString());
            }
        }
        public static void DealWith503(XElement xElement, string path)
        {
            MessageService msService = null;
            try
            {
                IEnumerable<XElement> eles = xElement.Elements().First().Elements();
                string guid = eles.Where(e => e.Name.LocalName == "guid").First().Value;
                string logisticsNo = eles.Where(e => e.Name.LocalName == "logisticsNo").First().Value;
                string logisticsStatus = eles.Where(e => e.Name.LocalName == "logisticsStatus").First().Value;

                string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "503") + "\\" + FileUtilities.GetNewFileName(logisticsNo) + ".xml";

                msService = new MessageService();
                msService.DealMessage503(true, false, guid, logisticsNo, destPath, logisticsStatus);

                FileUtilities.FileMove(path, destPath);
            }
            catch (Exception ex)
            {
                Logs.Error("DealWith503 Exception: " + ex.ToString());
            }
        }
        public static void DealWith504(XElement xElement, string path)
        {
            MessageService msService = null;
            try
            {
                IEnumerable<XElement> eles = xElement.Elements().First().Elements();
                string guid = eles.Where(e => e.Name.LocalName == "guid").First().Value;
                string logisticsNo = eles.Where(e => e.Name.LocalName == "logisticsNo").First().Value;
                string status = eles.Where(e => e.Name.LocalName == "returnStatus").First().Value;
                string returnTime = eles.Where(e => e.Name.LocalName == "returnTime").First().Value;
                string returnInfo = eles.Where(e => e.Name.LocalName == "returnInfo").First().Value;
                string logisticsStatus = eles.Where(e => e.Name.LocalName == "logisticsStatus").First().Value;
                if (logisticsStatus.Equals("R", StringComparison.CurrentCultureIgnoreCase) && status.Equals("120"))
                {
                    MessageCache601.RemoveCache(logisticsNo);
                    MessageControl control = new MessageControl();
                    control.CreateMessage601(logisticsNo);
                }

                string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "504") + "\\" + FileUtilities.GetNewFileName(logisticsNo, status, logisticsStatus) + ".xml";

                msService = new MessageService();
                msService.DealMessage504(logisticsNo, guid, status, logisticsStatus, returnTime, returnInfo, destPath);

                FileUtilities.FileMove(path, destPath);
            }
            catch (Exception ex)
            {
                Logs.Error("DealWith503 Exception: " + ex.ToString());
            }
        }
        public static void DealWith601(XElement xElement, string path)
        {
            MessageService msService = null;
            try
            {
                IEnumerable<XElement> eles = xElement.Elements().First().Elements();
                string guid = eles.Where(e => e.Name.LocalName == "guid").First().Value;
                string orderNoFake = eles.Where(e => e.Name.LocalName == "orderNo").First().Value;

                string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "601") + "\\" + FileUtilities.GetNewFileName(orderNoFake) + ".xml";

                msService = new MessageService();
                msService.DealMessage601(true, false, guid, orderNoFake, destPath);

                FileUtilities.FileMove(path, destPath);
            }
            catch (Exception ex)
            {
                BackUpForError(path);
                Logs.Error("DealWith601 Exception: " + ex.ToString());
            }
        }
        public static void DealWith602(XElement xElement, string path)
        {
            ReceiptSql sqlserver = null;
            MessageService msService = null;
            try
            {
                IEnumerable<XElement> eles = xElement.Elements().First().Elements();
                string guid = eles.Where(e => e.Name.LocalName == "guid").First().Value;
                string copNo = eles.Where(e => e.Name.LocalName == "copNo").First().Value;
                string preNo = null;
                string status = eles.Where(e => e.Name.LocalName == "returnStatus").First().Value;
                string returnTime = eles.Where(e => e.Name.LocalName == "returnTime").First().Value;
                string returnInfo = eles.Where(e => e.Name.LocalName == "returnInfo").First().Value;
                switch (status)
                {
                    case "-9999":
                        preNo = "";
                        break;
                    case "800":
                        preNo = eles.Where(e => e.Name.LocalName == "preNo").First().Value;
                        if (ConfigurationInfo.Need501)
                        {
                            MessageControl msControl = new MessageControl();
                            msControl.CreateMessage503L(copNo);
                        }
                        break;
                    default:
                        preNo = eles.Where(e => e.Name.LocalName == "preNo").First().Value;
                        break;
                }

                sqlserver = new ReceiptSql();
                sqlserver.Operate602(copNo, preNo, status);

                string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "602") + "\\" + FileUtilities.GetNewFileName(copNo, status) + ".xml";

                msService = new MessageService();
                msService.DealMessage602(copNo, guid, status, returnTime, returnInfo, destPath);

                FileUtilities.FileMove(path, destPath);
            }
            catch (Exception ex)
            {
                BackUpForError(path);
                Logs.Error("DealWith602 Exception: " + ex.ToString());
            }
        }
        public static void BackUpForError(string path)
        {
            FileUtilities.FileMove(path, Guid.NewGuid().ToString() + ".xml", true, ConfigurationInfo.PathBackUpError);
        }
    }
}
