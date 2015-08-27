using FS.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.TestWebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RestRequest restRequest = new RestRequest("http://127.0.0.1:21111/Messages/Create301", "68544065718738");
                restRequest.Execute();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
