using FS.Cache;
using FS.Message.Controller;
using FS.Message.Receiption.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FS.Message.Receiption
{
    public class MessageThread
    {
        internal static void CheckCacheThread()
        {
            while (true)
            {
                lock (MessageCache.a_dic)
                {
                    List<string> keys = new List<string>();
                    foreach (var p in MessageCache.a_dic)
                    {
                        CacheInfo info = p.Value;
                        if ((DateTime.Now - info.createTime).TotalMinutes > 60)
                        {
                            switch (info.key)
                            {
                                case "501":
                                    WaitCallback wait501 = new WaitCallback(CreateMessage501);
                                    ThreadPool.QueueUserWorkItem(wait501, info.value);
                                    keys.Add(p.Key);
                                    break;
                                case "503R":
                                    WaitCallback wait503R = new WaitCallback(CreateMessage503R);
                                    ThreadPool.QueueUserWorkItem(wait503R, info.value);
                                    keys.Add(p.Key);
                                    break;
                                case "503L":
                                    WaitCallback wait503L = new WaitCallback(CreateMessage503L);
                                    ThreadPool.QueueUserWorkItem(wait503L, info.value);
                                    keys.Add(p.Key);
                                    break;
                                case "601":
                                    WaitCallback wait601 = new WaitCallback(CreateMessage503L);
                                    ThreadPool.QueueUserWorkItem(wait601, info.value);
                                    keys.Add(p.Key);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    foreach (string s in keys)
                    {
                        MessageCache.a_dic.Remove(s);
                    }
                }
                Thread.Sleep(2000);
            }
        }

        static void CreateMessage501(object para)
        {
            string orderNoFake = para.ToString();
            MessageControl control = new MessageControl();
            control.CreateMessage501(orderNoFake);
        }

        static void CreateMessage503R(object para)
        {
            string logisticsNo = para.ToString();
            MessageControl control = new MessageControl();
            control.CreateMessage503R(logisticsNo);
        }

        static void CreateMessage503L(object para)
        {
            string orderNoFake = para.ToString();
            MessageControl control = new MessageControl();
            control.CreateMessage503L(orderNoFake);
        }

        static void CreateMessage601(object para)
        {
        }
    }
}
