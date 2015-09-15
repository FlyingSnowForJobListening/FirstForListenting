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

        private void GetToolControl()
        {
            if (a_control == null)
            {
                a_control = new MessageControl(ExecuteMethod.Tools);
            }
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            string flag = eventArgument.Substring(0, 36);
            string para = eventArgument.Substring(36);
            GetToolControl();
            switch (flag)
            {
                case "7322BBDD-FB89-4FAE-A699-834B085FF09E":
                    a_result = "7322BBDD-FB89-4FAE-A699-834B085FF09E" + a_control.GetCacheCount();
                    break;
                case "6179029E-D073-4354-8FBD-6725D089EC63":
                    a_result = "6179029E-D073-4354-8FBD-6725D089EC63" + a_control.SendMessage601Now();
                    break;
                default:
                    break;
            }
        }

        public string GetCallbackResult()
        {
            return a_result;
        }
    }
}