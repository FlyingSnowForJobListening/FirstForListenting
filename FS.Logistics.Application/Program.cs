using FS.Logistics.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FS.Logistics.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost logistics = null;
            try
            {
                logistics = new ServiceHost(typeof(LogisticsService));
                logistics.Open();
                Console.WriteLine("Running ...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (logistics != null && logistics.State == CommunicationState.Opened)
                {
                    logistics.Close();
                }
            }
        }
    }
}
