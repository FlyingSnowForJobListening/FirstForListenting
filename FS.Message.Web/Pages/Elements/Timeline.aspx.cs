using FS.Database.Entries;
using FS.Message.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FS.Message.Web.Pages.Elements
{
    public partial class Timeline : System.Web.UI.Page
    {
        MessageControl a_control;
        public string a_result;

        protected void Page_Load(object sender, EventArgs e)
        {
            MessageFilter filter = null;
            try
            {
                string itemGuid = Request.QueryString["ItemGuid"];
                GetMessageControl();
                filter = new MessageFilter();
                filter.Guid = new Guid(itemGuid);
                var resultObj = a_control.GetMessageTrackByGuid(filter);
                a_result = JsonConvert.SerializeObject(resultObj);
            }
            catch (Exception)
            {
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