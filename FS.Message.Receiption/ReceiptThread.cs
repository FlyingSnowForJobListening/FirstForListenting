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
    public class ReceiptThread
    {
        public static void OnProgressReceipt(object param)
        {
            try
            {
                string path = param.ToString();
                XElement xele = XElement.Load(path);

                string firstNodeName = xele.Name.LocalName.ToLower();
                switch (firstNodeName)
                {
                    case "ceb301message":
                        DealWith301(path);
                        break;
                    case "ceb302message":
                        DealWith302(xele, path);
                        break;
                    case "ceb501message":
                        DealWith501(xele, path);
                        break;
                    case "ceb502message":
                        //DealWith502(xele, path);
                        break;
                    case "ceb504message":
                        //DealWith504(xele, path);
                        break;
                    case "ceb601message":
                        DealWith601(xele, path);
                        break;
                    case "ceb602message":
                        //DealWith602(xele, path);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private static void DealWith301(string path)
        {
            try
            {
                string fileName = FileUtilities.GetNewFileName() + ".xml";
                string fileDestFolder = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "301");
                FileUtilities.FileMove(path, fileDestFolder + "\\" + fileName);
            }
            catch (Exception ex)
            {
                Logs.Error("DealWith301 Exception: " + ex.ToString());
            }
        }
        private static void DealWith302(XElement xElement, string path)
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
                msService.DealMessage302(orderNoFake, guid, status, returnTime, returnInfo, destPath);

                FileUtilities.FileMove(path, destPath);
                //if (ConfigurationInfo.Need501 && status.Equals("120"))
                //{
                //    MSControl control = new MSControl();
                //    control.Create501Message(orderNoFake);
                //}
            }
            catch (Exception ex)
            {
                BackUpForError(path);
                Logs.Error("DealWith302 Exception: " + ex.ToString());
            }
        }
        private static void DealWith501(XElement xElement, string path)
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

                if (!ConfigurationInfo.Need501)
                {
                    sqlserver = new ReceiptSql();
                    sqlserver.Operate501(orderNoFake, billNo, weigth, freight);

                    string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "501") + "\\" + FileUtilities.GetNewFileName(orderNoFake) + ".xml";

                    msService = new MessageService();
                    msService.DealMessage501(true, false, guid, orderNoFake, logisticsNo, destPath);

                    // Add Cache

                    FileUtilities.FileMove(path, destPath);
                }
            }
            catch (Exception ex)
            {
                BackUpForError(path);
                Logs.Error("DealWith501 Exception: " + ex.ToString());
            }
        }
        private static void DealWith502(XElement xElement, string path)
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

                sqlserver = new ReceiptSql();
                sqlserver.Operate502(logisticsNo, status, returnInfo);

                string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "502") + "\\" + FileUtilities.GetNewFileName(logisticsNo, status) + ".xml";

                msService = new MessageService();
                msService.DealMessage502(logisticsNo, guid, status, returnTime, returnInfo, destPath);

                FileUtilities.FileMove(path, destPath);
                if (ConfigurationInfo.Need501)
                {
                }
            }
            catch (Exception ex)
            {
                Logs.Error("DealWith502 Exception: " + ex.ToString());
            }
        }
        //503
        //504
        private static void DealWith601(XElement xElement, string path)
        {
            MessageService msService = null;
            try
            {
                IEnumerable<XElement> eles = xElement.Elements().First().Elements();
                string guid = eles.Where(e => e.Name.LocalName == "guid").First().Value;
                string copNo = eles.Where(e => e.Name.LocalName == "copNo").First().Value;

                string destPath = FileUtilities.GetNewFolderName(true, ConfigurationInfo.PathBackUp, "601") + "\\" + FileUtilities.GetNewFileName(copNo) + ".xml";

                msService = new MessageService();
                msService.DealMessage601(true, false, guid, copNo, destPath);

                FileUtilities.FileMove(path, destPath);
            }
            catch (Exception ex)
            {
                BackUpForError(path);
                Logs.Error("DealWith601 Exception: " + ex.ToString());
            }
        }
        private static void DealWith602(XElement xElement, string path)
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
        private static void BackUpForError(string path)
        {
            FileUtilities.FileMove(path, Guid.NewGuid().ToString() + ".xml", true, ConfigurationInfo.PathBackUpError);
        }
    }
}
