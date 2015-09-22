using FS.Configuration;
using FS.Database;
using FS.Database.Entries;
using FS.Log;
using FS.Message.Structure;
using FS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FS.Message.Controller
{
    public class MessageService
    {
        public bool DealMessage301(string orderNo, string orderNoFake, string logisticsNo, bool isReceived, bool isCreated, string guid, string destPath, string logisticCode)
        {
            bool success = true;
            try
            {
                EntryCreate entry = new EntryCreate();
                entry.ItemGuid = new Guid(guid);
                entry.IsReceived = isReceived;
                entry.IsCreated = isCreated;
                entry.CreateTime = entry.ReceiveTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                entry.FilePath = destPath;

                MessageTrack msTrack = new MessageTrack();
                msTrack.ItemGuid = Guid.NewGuid();
                msTrack.OrderNo = orderNo;
                msTrack.OrderNoFake = orderNoFake;
                msTrack.LogisticsNo = logisticsNo;
                msTrack.Schedule = 301;
                msTrack.LastUpdateTicks = DateTime.Now.Ticks;
                msTrack.Commnet1 = logisticCode;
                msTrack.Entry301s = new List<EntryCreate>();
                msTrack.Entry302s = new List<EntryReceive>();
                msTrack.Entry501s = new List<EntryCreate>();
                msTrack.Entry502s = new List<EntryReceive>();
                msTrack.Entry503s = new List<EntryCreate>();
                msTrack.Entry504s = new List<EntryReceive>();
                msTrack.Entry601s = new List<EntryCreate>();
                msTrack.Entry602s = new List<EntryReceive>();
                msTrack.Entry301s.Add(entry);
                using (var db = new EntryContext())
                {
                    db.MessageTracks.Add(msTrack);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error(string.Format("DealMessage301 OrderNo: {0} , Exception: {1}", orderNo, ex.ToString()));
                success = false;
            }
            return success;
        }
        public bool DealMessage302(string orderNoFake, string guid, string status, string returnTime, string returnInfo, string destPath)
        {
            bool success = true;
            try
            {
                EntryReceive entry = new EntryReceive();
                entry.ItemGuid = new Guid(guid);
                entry.Status = Convert.ToInt32(status);
                entry.ReturnTime = returnTime;
                entry.ReturnInfo = returnInfo;
                entry.FilePath = destPath;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry302s")
                                where m.OrderNoFake == orderNoFake
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry302s.Add(entry);
                    msTrack.LastUpdateTicks = DateTime.Now.Ticks;
                    if (msTrack.Schedule < 302)
                    {
                        msTrack.Schedule = 302;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error(string.Format("DealMessage302 OrderNoFake: {0} , Exception: {1}", orderNoFake, ex.ToString()));
                success = false;
            }
            return success;
        }
        public bool DealMessage501(bool isReceived, bool isCreated, string guid, string orderNoFake, string logisticNo, string destPath)
        {
            bool success = true;
            try
            {
                EntryCreate entry = new EntryCreate();
                entry.ItemGuid = new Guid(guid);
                entry.IsReceived = isReceived;
                entry.IsCreated = isCreated;
                entry.ReceiveTime = entry.CreateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                entry.FilePath = destPath;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry501s")
                                where m.OrderNoFake == orderNoFake
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry501s.Add(entry);
                    msTrack.LastUpdateTicks = DateTime.Now.Ticks;
                    msTrack.Schedule = 501;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error(string.Format("DealMessage501 OrderNoFake: {0} , Exception: {1}", orderNoFake, ex.ToString()));
                success = false;
            }
            return success;
        }
        public bool DealMessage502(string logisticsNo, string guid, string status, string returnTime, string returnInfo, string destPath)
        {
            bool success = true;
            try
            {
                EntryReceive entry = new EntryReceive();
                entry.ItemGuid = new Guid(guid);
                entry.Status = Convert.ToInt32(status);
                entry.ReturnTime = returnTime;
                entry.ReturnInfo = returnInfo;
                entry.FilePath = destPath;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry502s")
                                where m.LogisticsNo == logisticsNo
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry502s.Add(entry);
                    msTrack.LastUpdateTicks = DateTime.Now.Ticks;
                    msTrack.Schedule = 502;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error(string.Format("DealMessage502 LogisticsNo: {0} , Exception: {1}", logisticsNo, ex.ToString()));
                success = false;
            }
            return success;
        }
        public bool DealMessage503(bool isReceived, bool isCreated, string guid, string logisticNo, string destPath, string commnet1)
        {
            bool success = true;
            try
            {
                EntryCreate entry = new EntryCreate();
                entry.ItemGuid = new Guid(guid);
                entry.IsReceived = isReceived;
                entry.IsCreated = isCreated;
                entry.ReceiveTime = entry.CreateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                entry.FilePath = destPath;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry503s")
                                where m.LogisticsNo == logisticNo
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry503s.Add(entry);
                    msTrack.LastUpdateTicks = DateTime.Now.Ticks;
                    msTrack.Schedule = 503;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error(string.Format("DealMessage503 LogisticsNo: {0} , Exception: {1}", logisticNo, ex.ToString()));
                success = false;
            }
            return success;
        }
        public bool DealMessage504(string logisticsNo, string guid, string status, string logisticsStatus, string returnTime, string returnInfo, string destPath)
        {
            bool success = true;
            try
            {
                EntryReceive entry = new EntryReceive();
                entry.ItemGuid = new Guid(guid);
                entry.Status = Convert.ToInt32(status);
                entry.ReturnTime = returnTime;
                entry.ReturnInfo = returnInfo;
                entry.FilePath = destPath;
                entry.Commnet1 = logisticsStatus;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry504s")
                                where m.LogisticsNo == logisticsNo
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry504s.Add(entry);
                    msTrack.LastUpdateTicks = DateTime.Now.Ticks;
                    msTrack.Schedule = 504;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error(string.Format("DealMessage504 LogisticsNo: {0} Exception: {1}", logisticsNo, ex.ToString()));
                success = false;
            }
            return success;
        }
        public bool DealMessage601(bool isReceived, bool isCreated, string guid, string copNo, string destPath)
        {
            bool success = true;
            try
            {
                EntryCreate entry = new EntryCreate();
                entry.ItemGuid = new Guid(guid);
                entry.IsReceived = isReceived;
                entry.IsCreated = isCreated;
                entry.ReceiveTime = entry.CreateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                entry.FilePath = destPath;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry601s")
                                where m.OrderNoFake == copNo
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry601s.Add(entry);
                    msTrack.LastUpdateTicks = DateTime.Now.Ticks;
                    msTrack.Schedule = 601;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error(string.Format("DealMessage601 OrderNoFake: {0} Exception : {1}", copNo, ex.ToString()));
                success = false;
            }
            return success;
        }
        public bool DealMessage602(string copNo, string guid, string status, string returnTime, string returnInfo, string destPath)
        {
            bool success = true;
            try
            {
                EntryReceive entry = new EntryReceive();
                entry.ItemGuid = new Guid(guid);
                entry.Status = Convert.ToInt32(status);
                entry.ReturnTime = returnTime;
                entry.ReturnInfo = returnInfo;
                entry.FilePath = destPath;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry602s")
                                where m.OrderNoFake == copNo
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry602s.Add(entry);
                    msTrack.LastUpdateTicks = DateTime.Now.Ticks;
                    msTrack.Schedule = 602;
                    if (status.Equals("899"))
                    {
                        msTrack.IsFinished = true;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error(string.Format("DealMessage602 OrderNoFake: {0} , Exception: {1}", copNo, ex.ToString()));
                success = false;
            }
            return success;
        }
        public string GetLogisticCodeByOrderNoFake(string orderNoFake)
        {
            string result = null;
            try
            {
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks
                                where m.OrderNoFake.Equals(orderNoFake)
                                select m.Commnet1;
                    result = query.FirstOrDefault().ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.Error(string.Format("GetLogisticCodeByOrderNoFake OrderNoFake: {0} , Exception: {1}", orderNoFake, ex.ToString()));
            }
            return result;
        }
        public string GetLogisticCodeByLogisticsNo(string logisticsNo)
        {
            string result = null;
            try
            {
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks
                                where m.LogisticsNo.Equals(logisticsNo)
                                select m.Commnet1;
                    result = query.FirstOrDefault().ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.Error(string.Format("GetLogisticCodeByLogisticsNo OrderNoFake: {0} , Exception: {1}", logisticsNo, ex.ToString()));
            }
            return result;
        }
    }
}
