using FS.Configuration;
using FS.Database.Entries;
using FS.Log;
using FS.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Message.Client
{
    public class MessageControl
    {
        private string a_restUrl;
        private string a_restService;

        public MessageControl()
        {
            this.a_restService = "Messages";
            this.a_restUrl = string.Format("{0}:{1}/{2}/", ConfigurationInfo.RestHost, ConfigurationInfo.RestPort, this.a_restService);
        }
        public List<MessageTrack> GetAllMessageTrack()
        {
            List<MessageTrack> result = null;
            try
            {
                string resultStr = Execute(ExecuteAction.Get);
                result = JsonConvert.DeserializeObject<List<MessageTrack>>(resultStr);
            }
            catch (Exception ex)
            {
                Logs.Error("GetAllMessageTrack Exception: " + ex.ToString());
            }
            return result;
        }

        public string Execute(ExecuteAction action)
        {
            RestRequest restRequest = new RestRequest(this.a_restUrl + action.ToString(), "", "GET");
            return restRequest.Execute();
        }
    }
}
