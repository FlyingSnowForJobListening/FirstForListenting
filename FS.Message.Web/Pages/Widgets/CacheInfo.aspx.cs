using FS.Message.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FS.Message.Web.Pages.Widgets
{
    public partial class CacheInfo : System.Web.UI.Page, ICallbackEventHandler
    {
        MessageControl a_control;
        public string a_result;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCacheInfoAjax();
            }
            //if (!IsPostBack)
            //{
            //    GetMessageControl();
            //    a_result = a_control.GetCacheCount();
            //}
        }

        private void LoadCacheInfoAjax()
        {
            ClientScriptManager csm = Page.ClientScript;
            string reference = csm.GetCallbackEventReference(this, "args", "LoadCacheInfoAjaxSuccess", "", "LoadCacheInfoAjaxError", false);
            string callbackScript = "function CallLoadCacheInfoAjax(args, context) {\n" +
               reference + ";\n }";
            csm.RegisterClientScriptBlock(this.GetType(), "CallLoadCacheInfoAjax", callbackScript, true);
        }

        private void GetMessageControl()
        {
            if (a_control == null)
            {
                a_control = new MessageControl();
            }
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            throw new NotImplementedException();
        }

        public string GetCallbackResult()
        {
            throw new NotImplementedException();
        }
    }
}