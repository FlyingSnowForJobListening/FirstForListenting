using System;
using System.Net;

namespace FS.Rest
{
    public class ClientRest : WebClient, IDisposable
    {
        int m_timeout { get; set; }
        WebRequest _webRequest = null;
        public ClientRest(int timeout = 90)
        {
            m_timeout = timeout;
            base.Encoding = System.Text.Encoding.UTF8;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            _webRequest = base.GetWebRequest(address);
            _webRequest.Timeout = m_timeout * 1000;
            return _webRequest;
        }
        public void Dispose()
        {
            base.Dispose();
            _webRequest.Abort();
        }
    }
}
