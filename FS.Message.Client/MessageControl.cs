using FS.Configuration;
using FS.Database.Entries;
using FS.Log;
using FS.Rest;
using FS.Utility;
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
        public string a_restUrl;
        public string a_restService;

        public MessageControl(ExecuteMethod method)
        {
            this.a_restService = method.ToString();
            this.a_restUrl = string.Format("{0}:{1}/{2}/", ConfigurationInfo.RestHost, ConfigurationInfo.RestPort, this.a_restService);
        }

        public MessageControl(string method = "Messages")
        {
            this.a_restService = method;
            this.a_restUrl = string.Format("{0}:{1}/{2}/", ConfigurationInfo.RestHost, ConfigurationInfo.RestPort, this.a_restService);
        }

        public MessageTrack GetMessageTrackByGuid(MessageFilter filter)
        {
            MessageTrack result = null;
            try
            {
                string resultStr = Execute(ExecuteAction.GetByGuid, Utilities.JsonSerialize(filter));
                result = JsonConvert.DeserializeObject<MessageTrack>(resultStr);
            }
            catch (Exception ex)
            {
                Logs.Error("GetMessageTrackByGuid Exception: " + ex.ToString());
            }
            return result;
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

        public List<MessageTrack> GetMessageTrackByFilter(MessageFilter filter)
        {
            List<MessageTrack> result = null;
            try
            {
                string resultStr = Execute(ExecuteAction.GetByFilter, Utilities.JsonSerialize(filter));
                result = JsonConvert.DeserializeObject<List<MessageTrack>>(resultStr);
            }
            catch (Exception ex)
            {
                Logs.Error("GetMessageTrackByFilter Exception: " + ex.ToString());
            }
            return result;
        }

        public string GetCacheCount()
        {
            string result = null;
            try
            {
                string resultStr = Execute(ExecuteAction.GetCache);
                result = JsonConvert.DeserializeObject(resultStr).ToString();
            }
            catch (Exception ex)
            {
                Logs.Error("GetCacheCount Exception: " + ex.ToString());
            }
            return result;
        }

        public string SendMessage601Now()
        {
            string result = null;
            try
            {
                string resultStr = Execute(ExecuteAction.Clear601);
                result = JsonConvert.DeserializeObject(resultStr).ToString();
            }
            catch (Exception ex)
            {
                Logs.Error("SendMessage601Now Exception: " + ex.ToString());
            }
            return result;
        }

        public string Execute(ExecuteAction action, string param = "")
        {
            RestRequest restRequest = null;
            switch (action)
            {
                case ExecuteAction.Get:
                case ExecuteAction.GetCache:
                case ExecuteAction.Clear601:
                    restRequest = new RestRequest(this.a_restUrl + action.ToString(), param, "GET");
                    break;
                case ExecuteAction.GetByGuid:
                case ExecuteAction.GetByFilter:
                    restRequest = new RestRequest(this.a_restUrl + action.ToString(), param, "POST");
                    break;
                default:
                    break;
            }
            return restRequest.Execute();
        }
    }
}
