using FS.Configuration;
using FS.Log;
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
                        //DealWith501(xele, path);
                        break;
                    case "ceb502message":
                        //DealWith502(xele, path);
                        break;
                    case "ceb504message":
                        //DealWith504(xele, path);
                        break;
                    case "ceb601message":
                        //DealWith601(xele, path);
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
                FileUtilities.FileMove(path, fileName, true, ConfigurationInfo.BackUpPath, "301");
            }
            catch (Exception ex)
            {
                Logs.Error("DealWith301 Exception: " + ex.ToString());
            }
        }
        private static void DealWith302(XElement xElement, string path)
        {
            string orderNoFake = null;
            string status = null;
            string returnInfo = null;
            ReceiptSql sqlserver = null;
            //ReceiptFiles receiptFiles = null;
            try
            {
                IEnumerable<XElement> eles = xElement.Elements().First().Elements();
                status = eles.Where(e => e.Name.LocalName == "returnStatus").First().Value;
                orderNoFake = eles.Where(e => e.Name.LocalName == "orderNo").First().Value;
                returnInfo = eles.Where(e => e.Name.LocalName == "returnInfo").First().Value;
                sqlserver = new ReceiptSql();
                sqlserver.Operate302(orderNoFake, status, returnInfo);
                //receiptFiles = new ReceiptFiles();
                //receiptFiles.Move(path, "302", ReceiptFiles.CreateFileName(orderNoFake, status));
                //if (ConfigurationInfo.Need501 && status.Equals("120"))
                //{
                //    MSControl control = new MSControl();
                //    control.Create501Message(orderNoFake);
                //}
            }
            catch (Exception ex)
            {
                Logs.Error("DealWith302 Exception: " + ex.ToString());
            }
        }
    }
}
