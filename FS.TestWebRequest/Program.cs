using FS.Rest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.TestWebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            string enterStr = "";
            try
            {
                while (!enterStr.Equals("exit"))
                {
                    Console.WriteLine("Enter OrderNo:");
                    enterStr = Console.ReadLine();
                    try
                    {
                        RestRequest restRequest = new RestRequest(ConfigurationManager.AppSettings["RequestUrl"], enterStr);
                        restRequest.Execute();
                        Console.WriteLine("Success!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                //RestRequest restRequest = new RestRequest("http://127.0.0.1:21111/Messages/Create301", "68544065718738");
                //RestRequest restRequest = new RestRequest("http://127.0.0.1:21111/Messages/Create301", "68867519419577");
                //RestRequest restRequest = new RestRequest("http://10.0.0.195:21111/Messages/Get", "", "GET");
                //RestRequest restRequest = new RestRequest("http://127.0.0.1:21111/Messages/Get", "", "GET");
                //RestRequest restRequest = new RestRequest("http://10.0.0.195:21111/Messages/GetByGuid", "E098ABBE-BE54-4493-8BCB-5BF0CD4AF01F");
                //var a = restRequest.Execute();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
