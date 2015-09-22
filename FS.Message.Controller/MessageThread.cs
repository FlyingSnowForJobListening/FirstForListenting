﻿using FS.Cache;
using FS.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FS.Message.Controller
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
                        if ((DateTime.Now - info.createTime).TotalMinutes > 5)
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
                                    WaitCallback wait601 = new WaitCallback(CreateMessage601);
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
                Thread.Sleep(5000);
            }
        }

        static void CreateMessage501(object para)
        {
            try
            {
                string orderNoFake = ((dynamic)para).OrderNoFake;
                string logisticsCode = ((dynamic)para).LogisticsCode;
                MessageControl control = new MessageControl();
                control.CreateMessage501(orderNoFake);
            }
            catch (Exception ex)
            {
                Logs.Error("CreateMessage501 static Exception:" + ex.ToString());
            }
        }

        static void CreateMessage503R(object para)
        {
            try
            {
                string logisticsNo = ((dynamic)para).LogisticsNo;
                string logisticsCode = ((dynamic)para).LogisticsCode;
                MessageControl control = new MessageControl();
                control.CreateMessage503R(logisticsNo);
            }
            catch (Exception ex)
            {
                Logs.Error("CreateMessage503R static Exception:" + ex.ToString());
            }
        }

        static void CreateMessage503L(object para)
        {
            try
            {
                string orderNoFake = ((dynamic)para).OrderNoFake;
                string logisticsCode = ((dynamic)para).LogisticsCode;
                MessageControl control = new MessageControl();
                control.CreateMessage503L(orderNoFake);
            }
            catch (Exception ex)
            {
                Logs.Error("CreateMessage503L static Exception:" + ex.ToString());
            }
        }

        public static void CreateMessage601(object para)
        {
            string logisticsNo = ((dynamic)para).LogisticsNo;
            MessageControl control = new MessageControl();
            control.CreateMessage601(logisticsNo);
        }
    }
}