using System;
using System.Net;

namespace FS.Rest
{
    public class RestRequest
    {
        public string requestUrl = null;
        public string paramStr = null;
        public string method = null;

        public RestRequest(string Url, string jsonStr = "", string method = "POST")
        {
            this.requestUrl = Url;
            this.paramStr = jsonStr;
            this.method = method;
        }

        public string Execute()
        {
            ClientRest client = null;
            string result = null;
            Uri uri = null;
            client = new ClientRest();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            if (!client.IsBusy)
            {
                uri = new Uri(requestUrl, UriKind.Absolute);
                if (this.method.Equals("POST", StringComparison.CurrentCultureIgnoreCase))
                {
                    result = client.UploadString(uri, method, paramStr);
                }
                else
                {
                    result = client.DownloadString(uri);
                }
            }
            return result;
        }
    }
}
