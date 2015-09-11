using FS.Rest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FS.Tool
{
    public partial class Tools : Form
    {
        RequestObj a_requestObj;
        public Tools()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            a_requestObj = new RequestObj();
            this.tboxRequestUrl.DataBindings.Add("Text", a_requestObj, "RequestUrl");
            this.tboxOrderNo.DataBindings.Add("Text", a_requestObj, "OrderNo");
            this.tboxOrderNoFake.DataBindings.Add("Text", a_requestObj, "OrderNoFake");
            this.tboxLogisticsNo.DataBindings.Add("Text", a_requestObj, "LogisticsNo");
        }
        private bool CheckValue(int flag)
        {
            bool enough = true;
            if (string.IsNullOrEmpty(a_requestObj.RequestUrl))
            {
                MessageBox.Show("Request Url is Null!");
                return false;
            }
            switch (flag)
            {
                case 301:
                    if (string.IsNullOrEmpty(a_requestObj.OrderNo))
                    {
                        MessageBox.Show("OrderNo is Null!");
                        enough = false;
                    }
                    break;
                case 501:
                    if (string.IsNullOrEmpty(a_requestObj.OrderNoFake))
                    {
                        MessageBox.Show("OrderNoFake is Null!");
                        enough = false;
                    }
                    break;
                case 5031:
                    if (string.IsNullOrEmpty(a_requestObj.LogisticsNo))
                    {
                        MessageBox.Show("LogisticsNo is Null!");
                        enough = false;
                    }
                    break;
                case 5032:
                    if (string.IsNullOrEmpty(a_requestObj.OrderNoFake))
                    {
                        MessageBox.Show("OrderNoFake is Null!");
                        enough = false;
                    }
                    break;
                case 601:
                    if (string.IsNullOrEmpty(a_requestObj.LogisticsNo))
                    {
                        MessageBox.Show("LogisticsNo is Null!");
                        enough = false;
                    }
                    break;
                default:
                    break;
            }
            return enough;
        }
        #region Event
        private void btnCreate301_Click(object sender, EventArgs e)
        {
            string url = null;
            RestRequest rest = null;
            try
            {
                if (CheckValue(301))
                {
                    url = string.Format("{0}/Messages/Create301/{1}", a_requestObj.RequestUrl, a_requestObj.OrderNo);
                    rest = new RestRequest(url);
                    rest.Execute();
                    MessageBox.Show("Success!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCreate501_Click(object sender, EventArgs e)
        {
            string url = null;
            RestRequest rest = null;
            try
            {
                if (CheckValue(501))
                {
                    url = string.Format("{0}/Messages/Create501", a_requestObj.RequestUrl);
                    rest = new RestRequest(url, a_requestObj.OrderNoFake);
                    rest.Execute();
                    MessageBox.Show("Success!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCreate601_Click(object sender, EventArgs e)
        {
            string url = null;
            RestRequest rest = null;
            try
            {
                if (CheckValue(601))
                {
                    url = string.Format("{0}/Messages/Create601", a_requestObj.RequestUrl);
                    rest = new RestRequest(url, a_requestObj.LogisticsNo);
                    rest.Execute();
                    MessageBox.Show("Success!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCreate503R_Click(object sender, EventArgs e)
        {
            string url = null;
            RestRequest rest = null;
            try
            {
                if (CheckValue(5031))
                {
                    url = string.Format("{0}/Messages/Create503R", a_requestObj.RequestUrl);
                    rest = new RestRequest(url, a_requestObj.LogisticsNo);
                    rest.Execute();
                    MessageBox.Show("Success!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCreate503L_Click(object sender, EventArgs e)
        {
            string url = null;
            RestRequest rest = null;
            try
            {
                if (CheckValue(5032))
                {
                    url = string.Format("{0}/Messages/Create503L", a_requestObj.RequestUrl);
                    rest = new RestRequest(url, a_requestObj.OrderNoFake);
                    rest.Execute();
                    MessageBox.Show("Success!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}
