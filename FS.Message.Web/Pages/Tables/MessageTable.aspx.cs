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
    public partial class MessageTable : System.Web.UI.Page
    {
        MessageControl a_control;
        List<MessageTrack> a_messages;
        public string a_result;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMessageControl();
                a_messages = a_control.GetAllMessageTrack();
                a_result = JsonConvert.SerializeObject(new { Messages = a_messages });
            }
        }

        private void GetMessageControl()
        {
            if (a_control == null)
            {
                a_control = new MessageControl();
            }
        }
    }
}