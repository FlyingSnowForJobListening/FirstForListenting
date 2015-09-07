using FS.Database.Entries;
using FS.Message.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FS.Message.Web.Pages.Tables
{
    public partial class MessageTable : System.Web.UI.Page, ICallbackEventHandler
    {
        MessageControl a_control;
        List<MessageTrack> a_messages;
        public string a_result;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetMessageControl();
                //a_messages = a_control.GetAllMessageTrack();
                //a_result = JsonConvert.SerializeObject(new { Messages = a_messages });

                LoadMessageTableAjax();
            }
        }

        public string GetCallbackResult()
        {
            return a_result;
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
            string flag = eventArgument.Substring(0, 36);
            string para = eventArgument.Substring(36);
            switch (flag)
            {
                case "CC6D7081-6756-4465-AEE8-18D374DBF73F":
                    GetAllMessages();
                    break;
                default:
                    break;
            }
        }

        private void LoadMessageTableAjax()
        {
            ClientScriptManager csm = Page.ClientScript;
            string reference = csm.GetCallbackEventReference(this, "args", "LoadMessageTableAjaxSuccess", "", "LoadMessageTableAjaxError", false);
            string callbackScript = "function CallLoadMessageTableAjax(args, context) {\n" +
               reference + ";\n }";
            csm.RegisterClientScriptBlock(this.GetType(), "CallLoadMessageTableAjax", callbackScript, true);
        }

        public void GetAllMessages()
        {
            GetMessageControl();
            a_messages = a_control.GetAllMessageTrack();
            a_result = JsonConvert.SerializeObject(new { Messages = a_messages });
        }
    }
}