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
        public void DealMessage301(string orderNo, string orderNoFake, string logisticsNo, bool isReceived, bool isCreated, string guid, string destPath)
        {
            try
            {
                EntryCreate entry = new EntryCreate();
                entry.ItemGuid = new Guid(guid);
                entry.IsReceived = isReceived;
                entry.IsCreated = isCreated;
                entry.CreateTime = entry.ReceiveTime = DateTime.Now;
                entry.FilePath = destPath;

                MessageTrack msTrack = new MessageTrack();
                msTrack.ItemGuid = Guid.NewGuid();
                msTrack.OrderNo = orderNo;
                msTrack.OrderNoFake = orderNoFake;
                msTrack.LogisticsNo = logisticsNo;
                msTrack.Entry301s = new List<EntryCreate>();
                msTrack.Entry301s.Add(entry);
                using (var db = new EntryContext())
                {
                    db.MessageTracks.Add(msTrack);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error("DealMessage301 Exception : " + ex.ToString());
            }
        }
        public void DealMessage302(string orderNoFake, string guid, string status, string returnTime, string returnInfo, string destPath)
        {
            try
            {
                EntryReceive entry = new EntryReceive();
                entry.ItemGuid = new Guid(guid);
                entry.Status = Convert.ToInt32(status);
                entry.ReturnTime = Utilities.ConvertToDatetime(returnTime, "yyyyMMddhhmmss");
                entry.ReturnInfo = returnInfo;
                entry.FilePath = destPath;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry302s")
                                where m.OrderNoFake == orderNoFake
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry302s.Add(entry);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error("DealMessage302 Exception : " + ex.ToString());
            }
        }
        public void DealMessage501(bool isReceived, bool isCreated, string guid, string orderNoFake, string logisticNo, string destPath)
        {
            try
            {
                EntryCreate entry = new EntryCreate();
                entry.ItemGuid = new Guid(guid);
                entry.IsReceived = isReceived;
                entry.IsCreated = isCreated;
                entry.ReceiveTime = entry.CreateTime = DateTime.Now;
                entry.FilePath = destPath;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry501s")
                                where m.OrderNoFake == orderNoFake
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry501s.Add(entry);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error("DealMessage501 Exception : " + ex.ToString());
            }
        }
        public void DealMessage502(string logisticsNo, string guid, string status, string returnTime, string returnInfo, string destPath)
        {
            try
            {
                EntryReceive entry = new EntryReceive();
                entry.ItemGuid = new Guid(guid);
                entry.Status = Convert.ToInt32(status);
                entry.ReturnTime = Utilities.ConvertToDatetime(returnTime, "yyyyMMddhhmmss");
                entry.ReturnInfo = returnInfo;
                entry.FilePath = destPath;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry502s")
                                where m.LogisticsNo == logisticsNo
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry502s.Add(entry);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error("DealMessage502 Exception : " + ex.ToString());
            }
        }
        public void DealMessage601(bool isReceived, bool isCreated, string guid, string copNo, string destPath)
        {
            try
            {
                EntryCreate entry = new EntryCreate();
                entry.ItemGuid = new Guid(guid);
                entry.IsReceived = isReceived;
                entry.IsCreated = isCreated;
                entry.ReceiveTime = entry.CreateTime = DateTime.Now;
                entry.FilePath = destPath;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry601s")
                                where m.OrderNoFake == copNo
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry601s.Add(entry);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error("DealMessage601 Exception : " + ex.ToString());
            }
        }
        public void DealMessage602(string copNo, string guid, string status, string returnTime, string returnInfo, string destPath)
        {
            try
            {
                EntryReceive entry = new EntryReceive();
                entry.ItemGuid = new Guid(guid);
                entry.Status = Convert.ToInt32(status);
                entry.ReturnTime = Utilities.ConvertToDatetime(returnTime, "yyyyMMddhhmmss");
                entry.ReturnInfo = returnInfo;
                entry.FilePath = destPath;
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks.Include("Entry602s")
                                where m.OrderNoFake == copNo
                                select m;
                    var msTrack = query.FirstOrDefault();
                    msTrack.Entry602s.Add(entry);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error("DealMessage602 Exception : " + ex.ToString());
            }
        }


    }
}
