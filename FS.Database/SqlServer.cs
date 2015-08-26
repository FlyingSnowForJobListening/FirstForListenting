using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Database
{
    public class SqlServer
    {

        private SqlTransaction Transaction { get; set; }

        #region Fields
        public string server { get; set; }
        public string database { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public SqlConnection connection { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Connect SQL
        /// </summary>     
        public SqlServer(string server, string database, string user, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(database) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
                {
                    return;
                }
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = server;
                builder.InitialCatalog = database;
                builder.UserID = user;
                builder.Password = password;
                connection = new SqlConnection(builder.ToString());
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Get Connect Exception; " + ex.ToString());
            }
        }
        public SqlServer(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Close Connection Object
        /// </summary>
        public virtual void CloseConnect()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("CloseConnect Exception; " + ex.ToString());
            }
        }
        public void OpenConnect()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("OpenConnect Exception; " + ex.ToString());
            }
        }
        /// <summary>
        /// Execute the stored procedure
        /// </summary>       
        public virtual SqlDataReader ExePROC(string name, SqlParameter[] parameters)
        {
            SqlDataReader reader = null;
            try
            {
                OpenConnect();
                string _commandString = "[" + name + "]";
                SqlCommand _command = new SqlCommand(_commandString, this.connection);
                _command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parm in parameters)
                {
                    _command.Parameters.Add(parm);
                }
                reader = _command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                throw new Exception("ExePROC Exception; " + ex.ToString());
            }
        }
        /// <summary>
        /// Execute the stored procedure non query
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual int ExePROCNonQuery(string name, SqlParameter[] parameters)
        {
            try
            {
                string _commandString = "[" + name + "]";
                SqlCommand _command = new SqlCommand(_commandString, this.connection);
                _command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parm in parameters)
                {
                    _command.Parameters.Add(parm);
                }
                return _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("ExePROC Exception; " + ex.ToString());
            }
        }
        /// <summary>
        /// Set SQL Parameter
        /// </summary>     
        public virtual SqlParameter SetParameter(string name, SqlDbType type, int size, object value, bool isOutPut = false)
        {
            SqlParameter _para = null;
            try
            {
                if (size <= 0)
                {
                    _para = new SqlParameter(name, type);
                }
                else
                {
                    _para = new SqlParameter(name, type, size);
                }
                if (isOutPut)
                {
                    _para.Direction = ParameterDirection.Output;
                }
                _para.Value = value;
                return _para;
            }
            catch (Exception ex)
            {
                throw new Exception("SetParameter Exception; " + ex.ToString());
            }
        }
        #endregion
    }
}
