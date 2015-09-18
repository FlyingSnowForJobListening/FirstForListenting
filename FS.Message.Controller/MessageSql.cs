using FS.Configuration;
using FS.Database;
using FS.Log;
using FS.Message.Structure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Message.Controller
{
    public class MessageSql
    {
        #region Init
        public SqlServer a_sqlServer { get; set; }
        public MessageSql()
        {
            a_sqlServer = new SqlServer(ConfigurationInfo.DBConnectionString);
        }
        #endregion

        #region Public Method
        public void QueryData301(string orderNo, ref OrderHead orderHead, ref List<OrderList> orderLists, ref string logisticsNo, ref string logisticsCode)
        {
            OrderList orderList = null;
            SqlDataReader dr = null;
            try
            {
                dr = a_sqlServer.ExePROC("MessageCenterQuery", ConvertToSqlParameters(301, orderNo, ""));
                if (dr.HasRows)
                {
                    int i = 1;
                    while (dr.Read())
                    {
                        if (i == 1)
                        {
                            orderHead = GetOrderHead(dr);
                            logisticsNo = Convert.ToString(dr["logisticsNo"]);
                        }
                        orderList = GetOrderList(dr, i++);
                        OrderList exist = orderLists.Find(o => o.gno.Equals(orderList.gno));
                        if (exist == null)
                        {
                            orderLists.Add(orderList);
                        }
                        else
                        {
                            exist.qty += orderList.qty;
                            exist.total += orderList.total;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.Error("Query301DataByOrderNo Exception:" + ex.ToString());
            }
            finally
            {
                dr.Close();
            }
        }
        public void QueryData501(string orderNoFake, ref LogisticsHead logisticsHead)
        {
            SqlDataReader dr = null;
            try
            {
                dr = a_sqlServer.ExePROC("MessageCenterQuery", ConvertToSqlParameters(501, orderNoFake, ""));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        logisticsHead = GetLogisticsHead(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.Error("Query501DataByOrderNo Exception : " + ex.ToString());
            }
            finally
            {
                dr.Close();
            }
        }
        public void QueryDate503ByOrderNo(string orderNo, ref LogisticsStatus logisticsStatus)
        {
            try
            {
                SqlDataReader dr = a_sqlServer.ExePROC("MessageCenterQuery", ConvertToSqlParameters(5032, orderNo, ""));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        logisticsStatus = GetLogisticsStatus(dr);
                        logisticsStatus.logisticsStatus = "L";
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.Error("Query503DataByOrderNo Exception : " + ex.ToString());
            }
        }
        public void QueryData503ByLogisticsNo(string logisticsNo, ref LogisticsStatus logisticsStatus)
        {
            try
            {
                SqlDataReader dr = a_sqlServer.ExePROC("MessageCenterQuery", ConvertToSqlParameters(5031, "", logisticsNo));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        logisticsStatus = GetLogisticsStatus(dr);
                        logisticsStatus.logisticsStatus = "R";
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Logs.Error("Query503DataByLogisticsNo Exception : " + ex.ToString());
            }
        }
        public void QueryDate601(string logisticsNo, ref InventoryHead inventoryHead, ref List<InventoryList> inventoryLists, ref BaseSubscribe baseSubscribe)
        {
            InventoryList inventoryList = null;
            SqlDataReader dr = null;
            try
            {
                dr = a_sqlServer.ExePROC("MessageCenterQuery", ConvertToSqlParameters(601, "", logisticsNo));
                if (dr.HasRows)
                {
                    int i = 1;
                    while (dr.Read())
                    {
                        if (i == 1)
                        {
                            inventoryHead = GetInventoryHead(dr);
                        }
                        inventoryList = GetInventoryList(dr, i++);
                        InventoryList exist = inventoryLists.Find(o => o.gno.Equals(inventoryList.gno));
                        if (exist == null)
                        {
                            inventoryLists.Add(inventoryList);
                        }
                        else
                        {
                            exist.qty += inventoryList.qty;
                            exist.total += inventoryList.total;
                            exist.qty1 += inventoryList.qty1;
                            exist.qty2 += inventoryList.qty2;
                        }
                        baseSubscribe = GetBaseSubscribe(dr);
                    }
                    foreach (var list in inventoryLists)
                    {
                        var f = inventoryHead.netWeight / inventoryLists.Count;
                        list.qty2 = ((float?)((int)(f * 100))) / 100;
                    }
                    //a_sqlServer.ExePROCNonQuery("MessageReceipt", ConvertToSqlParameters("601", inventoryHead.orderNo, logisticsNo, "0", "", inventoryHead.copNo, "", ""));
                }
            }
            catch (Exception ex)
            {
                Logs.Error("Query601DataByOrderNo Exception:" + ex.ToString());
            }
            finally
            {
                dr.Close();
            }
        }
        public void UpdateSchedule501(string orderNo, string billNo)
        {
            try
            {
                a_sqlServer.ExePROCNonQuery("MessageReceipt", ConvertToSqlParameters("501", orderNo, "", "0", "", "", "", billNo));
            }
            catch (Exception ex)
            {
                Logs.Error("Update501Schedule Exception : " + ex.ToString());
            }
        }
        public void UpdateSchedule503(string orderNo, string logisticNo)
        {
            try
            {
                if (string.IsNullOrEmpty(orderNo))
                {
                    a_sqlServer.ExePROCNonQuery("MessageReceipt", ConvertToSqlParameters("5031", "", logisticNo, "0", "", "", "", ""));
                }
                else
                {
                    a_sqlServer.ExePROCNonQuery("MessageReceipt", ConvertToSqlParameters("5032", orderNo, "", "0", "", "", "", ""));
                }
            }
            catch (Exception ex)
            {
                Logs.Error("Update503Schedule Exception : " + ex.ToString());
            }
        }
        #endregion

        #region Private Method
        private OrderHead GetOrderHead(SqlDataReader dr)
        {
            OrderHead result = null;
            try
            {
                result = new OrderHead();
                result.guid = Guid.NewGuid();
                result.appType = Convert.ToInt32(AppType.Add);
                result.appTime = DateTime.UtcNow;
                result.appStatus = Convert.ToInt32(AppStatus.Declare);
                result.appUid = Convert.ToString(dr["appUid"]); //"8910000308599";
                result.appUname = Convert.ToString(dr["appUname"]); //"张钟芮";
                result.orderType = OrderType.E;
                result.orderNo = Convert.ToString(dr["customs_OrderNo"]);
                result.ebpCode = Convert.ToString(dr["ebpCode"]); //"2117960080";
                result.ebpName = Convert.ToString(dr["ebpName"]); //"兴城市天浪电子商务信息有限公司";
                result.ebcCode = result.ebpCode;
                result.ebcName = result.ebpName;
                result.agentCode = result.ebpCode; //"2114980005";
                result.agentName = result.ebpName; //"葫芦岛誉悦国际货运代理有限责任公司";
                result.goodsValue = Convert.ToSingle(dr["orderAmount"]);
                result.freight = Convert.ToSingle(dr["orderFreight"]);
                result.currency = Convert.ToString(dr["orderFreightCurrency"]);
                result.consignee = Convert.ToString(dr["consignee"]);
                result.consigneeAddress = Convert.ToString(dr["consigneeAddress"]);
                result.consigneeTelephone = Convert.ToString(dr["consigneeTelephone"]);
                result.consigneeCountry = Convert.ToString(dr["consigneeCountry_Code"]);
                result.note = null;
            }
            catch (Exception ex)
            {
                throw new Exception("GetOrderHead Exception:" + ex.ToString());
            }
            return result;
        }
        private OrderList GetOrderList(SqlDataReader dr, int i)
        {
            OrderList result = null;
            try
            {
                result = new OrderList();
                result.gnum = i;
                result.itemNo = Convert.ToString(dr["itemNo"]);
                result.gno = Convert.ToString(dr["gnoCode"]);
                result.gcode = Convert.ToString(dr["gCode"]);
                result.gname = Convert.ToString(dr["gName"]);
                result.gmodel = Convert.ToString(dr["gModel"]);
                result.barCode = Convert.ToString(dr["barCode"]);
                result.brand = Convert.ToString(dr["brand"]);
                result.unit = Convert.ToString(dr["unit1"]);
                result.currency = Convert.ToString(dr["goodsCurrency"]);
                result.qty = Convert.ToSingle(dr["goddsNum"]);
                result.price = Convert.ToSingle(dr["price"]);
                result.total = Convert.ToSingle(dr["totalAmount"]);
                result.giftFlag = 0;
                result.note = null;
            }
            catch (Exception ex)
            {
                throw new Exception("GetOrderList Exception:" + ex.ToString());
            }
            return result;
        }
        private LogisticsHead GetLogisticsHead(SqlDataReader dr)
        {
            LogisticsHead result = null;
            try
            {
                result = new LogisticsHead();
                result.guid = Guid.NewGuid();
                result.customsCode = Convert.ToString(dr["customsCode"]);
                result.appType = Convert.ToInt32(AppType.Add);
                result.appTime = DateTime.UtcNow;
                result.appStatus = Convert.ToInt32(AppStatus.Declare);
                result.appUid = Convert.ToString(dr["appUid"]);
                result.appUname = Convert.ToString(dr["appUname"]);
                result.orderNo = Convert.ToString(dr["customs_OrderNo"]);
                result.ebpCode = Convert.ToString(dr["ebpCode"]);
                result.ebpName = Convert.ToString(dr["ebpName"]);
                result.logisticsCode = Convert.ToString(dr["logisticsCode"]);
                result.logisticsName = Convert.ToString(dr["logisticsName"]);
                result.logisticsNo = Convert.ToString(dr["logisticsNo"]);
                result.ieFlag = OrderType.E;
                result.trafMode = "9";
                result.trafName = Convert.ToString(dr["trafName"]);
                result.voyageNo = Convert.ToString(dr["voyageNo"]);
                result.billNo = DateTime.Now.ToString("yyyyMMdd") + "_" + result.logisticsNo;
                result.freight = Convert.ToSingle(dr["loginticsFreight"]);
                result.insuredFee = Convert.ToSingle(dr["insuredFee"]);
                result.currency = "142";
                result.weight = Convert.ToSingle(dr["orderWeight"]);
                result.netWt = Convert.ToSingle(dr["orderNetWeight"]);
                result.packNo = Convert.ToSingle(dr["packNo"]);
                result.parcelInfo = result.logisticsNo;
                result.goodsInfo = ";";
                result.consignee = Convert.ToString(dr["consignee"]);
                result.consigneeAddress = Convert.ToString(dr["consigneeAddress"]);
                result.consigneeTelephone = Convert.ToString(dr["consigneeTelephone"]);
                result.consigneeCountry = Convert.ToString(dr["consigneeCountry_Code"]);
                result.shipper = Convert.ToString(dr["shipper"]);
                result.shipperAddress = Convert.ToString(dr["shipperAddress"]);
                result.shipperTelephone = Convert.ToString(dr["shipperTelephone"]);
                result.shipperCountry = "142";
                result.note = "";
            }
            catch (Exception ex)
            {
                throw new Exception("GetLogisticsHead Exception : " + ex.ToString());
            }
            return result;
        }
        private LogisticsStatus GetLogisticsStatus(SqlDataReader dr)
        {
            LogisticsStatus result = null;
            try
            {
                result = new LogisticsStatus();
                result.guid = Guid.NewGuid();
                result.customsCode = Convert.ToString(dr["customsCode"]);
                result.appType = Convert.ToInt32(AppType.Add);
                result.appTime = DateTime.UtcNow;
                result.appStatus = Convert.ToInt32(AppStatus.Declare);
                result.appUid = Convert.ToString(dr["appUid"]);
                result.appUname = Convert.ToString(dr["appUname"]);
                result.logisticsCode = Convert.ToString(dr["logisticsCode"]);
                result.logisticsName = Convert.ToString(dr["logisticsName"]);
                result.logisticsNo = Convert.ToString(dr["logisticsNo"]);
                result.logisticsStatus = Convert.ToString(dr["logisticsRL"]); //L
                result.ieFlag = OrderType.E;
                result.trafMode = "9";
                result.trafName = Convert.ToString(dr["trafName"]);
                result.voyageNo = Convert.ToString(dr["voyageNo"]);
                result.billNo = Convert.ToString(dr["billNo"]);
                result.note = "";
            }
            catch (Exception ex)
            {
                throw new Exception("GetLogisticsStatus Exception : " + ex.ToString());
            }
            return result;
        }
        private InventoryHead GetInventoryHead(SqlDataReader dr)
        {
            InventoryHead result = null;
            try
            {
                result = new InventoryHead();
                result.guid = Guid.NewGuid();
                result.customsCode = Convert.ToString(dr["customsCode"]);//"0810"
                result.appType = (int)AppType.Add;
                result.appTime = DateTime.Now;
                result.appStatus = (int)AppStatus.Storage;
                result.appUid = Convert.ToString(dr["appUid"]);// "8910000308599";
                result.appUname = Convert.ToString(dr["appUname"]);// "张钟芮";
                result.copNo = Convert.ToString(dr["customs_OrderNo"]);// "20150501102414909";
                result.preNo = null;
                result.orderNo = Convert.ToString(dr["customs_OrderNo"]);
                result.ebpCode = Convert.ToString(dr["ebpCode"]);// "2117960080";
                result.ebpName = Convert.ToString(dr["ebpName"]);// "兴城市天浪电子商务信息有限公司";
                result.logisticsNo = Convert.ToString(dr["logisticsNo"]);
                result.logisticsCode = Convert.ToString(dr["logisticsCode"]);// "2101980101";
                result.logisticsName = Convert.ToString(dr["logisticsName"]);// "辽宁省邮政公司";
                result.invtNo = null;
                result.ieFlag = OrderType.E;
                result.portCode = Convert.ToString(dr["portCode"]);// "0803";
                result.ieDate = DateTime.Now.ToString("yyyyMMdd");
                result.ownerCode = result.ebpCode;
                result.ownerName = result.ebpName;
                result.tradeCode = Convert.ToString(dr["tradeCode"]);// "2114930090";
                result.tradeName = Convert.ToString(dr["tradeName"]);// "葫芦岛德容(集团)制衣有限公司";
                result.agentCode = Convert.ToString(dr["agentCode"]);// "2114980005";
                result.agentName = Convert.ToString(dr["agentName"]);// "葫芦岛誉悦国际货运代理有限责任公司";
                result.tradeMode = Convert.ToString(dr["tradeMode"]);// "9610";
                result.trafMode = "9";// "6";
                result.trafName = Convert.ToString(dr["trafName"]);// "邮政车";
                result.voyageNo = Convert.ToString(dr["voyageNo"]);// "辽P0028B";
                result.billNo = Convert.ToString(dr["billNo"]);//????????????????????
                result.loctNo = null;
                result.licenseNo = null;
                result.country = Convert.ToString(dr["destinationCountry"]);
                result.destinationPort = Convert.ToString(dr["destinationPort"]);
                result.freight = Convert.ToSingle(dr["loginticsFreight"]);
                result.freightCurr = "142";
                result.freightMark = "3";
                result.insuredFee = Convert.ToSingle(dr["insuredFee"]);
                result.insuredFeeCurr = "142";
                result.insuredFeeMark = "3";
                result.wrapType = Convert.ToString(dr["wrapType"]);
                result.packNo = Convert.ToSingle(dr["packNo"]);
                result.weight = Convert.ToSingle(dr["orderWeight"]);
                result.netWeight = Convert.ToSingle(dr["orderNetWeight"]);
                result.note = null;
            }
            catch (Exception ex)
            {
                throw new Exception("GetInventoryHead Exception:" + ex.ToString());
            }
            return result;
        }
        private InventoryList GetInventoryList(SqlDataReader dr, int i)
        {
            InventoryList result = null;
            try
            {
                result = new InventoryList();
                result.gnum = i;
                result.itemNo = Convert.ToString(dr["itemNo"]);
                result.gno = Convert.ToString(dr["gnoCode"]);
                result.gcode = Convert.ToString(dr["gCode"]);
                result.gname = Convert.ToString(dr["gName"]);
                result.gmodel = Convert.ToString(dr["gModel"]);
                result.barCode = Convert.ToString(dr["barCode"]);
                result.country = Convert.ToString(dr["goodsCountryCode"]);
                result.currency = Convert.ToString(dr["goodsCurrency"]);
                result.qty = Convert.ToSingle(dr["goddsNum"]);
                result.unit = Convert.ToString(dr["unit1"]);
                result.qty1 = Convert.ToSingle(dr["goddsNum"]);
                result.unit1 = Convert.ToString(dr["unit1"]);
                result.qty2 = Convert.ToSingle(dr["goddsNum"]);
                result.unit2 = Convert.ToString(dr["unit2"]);
                result.price = Convert.ToSingle(dr["price"]);
                result.total = Convert.ToSingle(dr["totalAmount"]);
            }
            catch (Exception ex)
            {
                throw new Exception("GetInventoryList Exception : " + ex.ToString());
            }
            return result;
        }
        private BaseSubscribe GetBaseSubscribe(SqlDataReader dr)
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
        private SqlParameter[] ConvertToSqlParameters(int flag, string orderNo, string logisticsNo)
        {
            SqlParameter[] paras = null;
            paras = new SqlParameter[3];
            paras[0] = a_sqlServer.SetParameter("OperateFlag", SqlDbType.Int, 0, flag);
            paras[1] = a_sqlServer.SetParameter("OrderNo", SqlDbType.NVarChar, 50, orderNo);
            paras[2] = a_sqlServer.SetParameter("LogisticsNo", SqlDbType.NVarChar, 50, logisticsNo);
            return paras;
        }
        private SqlParameter[] ConvertToSqlParameters(string operateFlag, string orderNo, string logisticsNo, string status, string reInfo, string copNo, string preNo, string billNo, params string[] args)
        {
            SqlParameter[] paras = null;
            try
            {
                paras = new SqlParameter[13];
                paras[0] = a_sqlServer.SetParameter("OperateFlag", SqlDbType.Int, 0, operateFlag);
                paras[1] = a_sqlServer.SetParameter("OrderNo", SqlDbType.NVarChar, 20, orderNo);
                paras[2] = a_sqlServer.SetParameter("Logistics", SqlDbType.NVarChar, 20, logisticsNo);
                paras[3] = a_sqlServer.SetParameter("Status", SqlDbType.Int, 0, status);
                paras[4] = a_sqlServer.SetParameter("ReturnInfo", SqlDbType.NVarChar, 200, reInfo);
                paras[5] = a_sqlServer.SetParameter("CopNo", SqlDbType.NVarChar, 20, copNo);
                paras[6] = a_sqlServer.SetParameter("PreNo", SqlDbType.NVarChar, 20, preNo);
                paras[7] = a_sqlServer.SetParameter("BillNo", SqlDbType.NVarChar, 50, billNo);
                for (int i = 0; i < 5; i++)
                {
                    if (i < args.Length)
                        paras[8 + i] = a_sqlServer.SetParameter("Comment" + ((int)(i + 1)), SqlDbType.NVarChar, 300, args[i]);
                    else
                        paras[8 + i] = a_sqlServer.SetParameter("Comment" + ((int)(i + 1)), SqlDbType.NVarChar, 300, string.Empty);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ConvertToSqlParameters Exception: " + ex.ToString());
            }
            return paras;
        }
        #endregion
    }
}
