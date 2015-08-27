using FS.Configuration;
using FS.Database;
using FS.Log;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FS.Message.Receiption
{
    public class ReceiptSql
    {
        public SqlServer a_sqlServer { get; set; }
        public ReceiptSql()
        {
            a_sqlServer = new SqlServer(ConfigurationInfo.DBConnectionString);
        }

        #region Public Method
        public void Operate302(string orderNoFake, string status, string returnInfo)
        {
            try
            {
                SqlParameter[] paras = ConvertToSqlParameters("302", orderNoFake, "", status, returnInfo, "", "", "");
                a_sqlServer.ExePROCNonQuery("MessageReceipt", paras);
            }
            catch (Exception ex)
            {
                Logs.Error("Operate302 Exception:" + ex.ToString());
            }
        }
        public void Operate501(string orderNoFake, string billNo, string weigth, string freight)
        {
            try
            {
                SqlParameter[] paras = ConvertToSqlParameters("501", orderNoFake, "", "0", weigth, freight, "", billNo);
                a_sqlServer.ExePROCNonQuery("MessageReceipt", paras);
            }
            catch (Exception ex)
            {
                Logs.Error("Operate501 Exception:" + ex.ToString());
            }
        }
        public void Operate502(string logisticsNo, string status, string reInfo)
        {
            try
            {
                SqlParameter[] paras = ConvertToSqlParameters("502", "", logisticsNo, status, reInfo, "", "", "");
                a_sqlServer.ExePROCNonQuery("MessageReceipt", paras);
            }
            catch (Exception ex)
            {
                Logs.Error("Operate502 Exception ： " + ex.ToString());
            }
        }
        public void Operate602(string copNo, string preNo, string status)
        {
            try
            {
                SqlParameter[] paras = ConvertToSqlParameters("602", copNo, "", status, "", copNo, preNo, "");
                a_sqlServer.ExePROCNonQuery("MessageReceipt", paras);
            }
            catch (Exception ex)
            {
                Logs.Error("Operate602 Exception:" + ex.ToString());
            }
        }
        #endregion

        #region Private Method
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
                        paras[8 + i] = a_sqlServer.SetParameter("Comment" + ((int)(i + 1)), SqlDbType.NVarChar, 300, null);
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
