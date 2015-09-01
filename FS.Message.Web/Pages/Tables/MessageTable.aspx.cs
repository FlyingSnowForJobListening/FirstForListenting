using FS.Message.Client;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MessageControl control = new MessageControl();
                var result = control.GetAllMessageTrack();
            }
        }
    }
}