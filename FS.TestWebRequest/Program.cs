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

                //string a = "123456789qwertyui";
                //var b = a.Substring(0, 5);
                //var c = a.Substring(5);
                //Console.WriteLine(a);
                //Console.WriteLine(b);
                //Console.WriteLine(c);
                //RestRequest restRequest = new RestRequest("http://127.0.0.1:21111/Messages/Create301", "68544065718738");
                RestRequest restRequest = new RestRequest("http://127.0.0.1:21111/Messages/Create301", "68867519419577");
                //RestRequest restRequest = new RestRequest("http://127.0.0.1:21111/Messages/Get", "", "GET");

                var a = restRequest.Execute();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
