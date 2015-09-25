using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.Database.Entries;
using FS.Message.Controller;
using FS.Log;
using FS.Database;
using FS.Message.Receiption;
using Newtonsoft.Json;

namespace FS.Platform.Server
{
    public class MessageService : IMessageService
    {
        public bool CreateMessage301(string orderNo)
        {
            MessageControl msControl = new MessageControl();
            return msControl.CreateMessage301(orderNo);
        }
        public bool CreateMessage501(string orderNoFake)
        {
            MessageControl msControl = new MessageControl();
            return msControl.CreateMessage501(orderNoFake);
        }
        public bool CreateMessage503R(string logisticsNo)
        {
            MessageControl msControl = new MessageControl();
            return msControl.CreateMessage503R(logisticsNo);
        }
        public bool CreateMessage503L(string orderNoFake)
        {
            MessageControl msControl = new MessageControl();
            return msControl.CreateMessage503L(orderNoFake);
        }
        public bool CreateMessage601(string logisticsNo)
        {
            MessageControl msControl = new MessageControl();
            return msControl.CreateMessage601(logisticsNo);
        }
        public List<MessageTrack> GetAllMessageTracks()
        {
            var start = DateTime.Now.AddDays(-10);
            List<MessageTrack> result = null;
            try
            {
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks
                                .Include("Entry301s")
                                .Include("Entry302s")
                                .Include("Entry501s")
                                .Include("Entry502s")
                                .Include("Entry503s")
                                .Include("Entry504s")
                                .Include("Entry601s")
                                .Include("Entry602s")
                                where !m.IsFinished && m.LastUpdateTicks >= start.Ticks
                                orderby m.LastUpdateTicks descending
                                select m;
                    result = query.ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.Error("GetAllMessageTracks Exception: " + ex.ToString());
            }
            return result;
        }
        public List<MessageTrack> GetMessageTracksByFilter(MessageFilter filter)
        {
            List<MessageTrack> result = null;
            try
            {
                Logs.Debug("GetMessageTracksByFilter Start! Filter:" + JsonConvert.SerializeObject(filter));
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks
                                .Include("Entry301s")
                                .Include("Entry302s")
                                .Include("Entry501s")
                                .Include("Entry502s")
                                .Include("Entry503s")
                                .Include("Entry504s")
                                .Include("Entry601s")
                                .Include("Entry602s")
                                where (string.IsNullOrEmpty(filter.OrderNo) ? true : m.OrderNo.IndexOf(filter.OrderNo) >= 0)
                                && (string.IsNullOrEmpty(filter.LogisticsNo) ? true : m.LogisticsNo.IndexOf(filter.LogisticsNo) >= 0)
                                && (filter.Status.Equals("All") ? true : filter.Status.Equals("True") ? m.IsFinished : !m.IsFinished)
                                && (filter.Start.Ticks == 0 ? true : m.LastUpdateTicks >= filter.Start.Ticks)
                                && (filter.End.Ticks == 0 ? true : m.LastUpdateTicks <= filter.End.Ticks)
                                orderby m.LastUpdateTicks descending
                                select m;
                    result = query.ToList();
                }
                Logs.Debug("GetMessageTracksByFilter End! Result Count:" + result.Count);
            }
            catch (Exception ex)
            {
                Logs.Error("GetAllMessageTracks Exception: " + ex.ToString());
            }
            return result;
        }
        public MessageTrack GetMessageTrackByGuid(MessageFilter Filter)
        {
            MessageTrack result = null;
            try
            {
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks
                                .Include("Entry301s")
                                .Include("Entry302s")
                                .Include("Entry501s")
                                .Include("Entry502s")
                                .Include("Entry503s")
                                .Include("Entry504s")
                                .Include("Entry601s")
                                .Include("Entry602s")
                                where m.ItemGuid == Filter.Guid
                                select m;
                    result = query.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Logs.Error("GetMessageTrackByGuid Exception: " + ex.ToString());
            }
            return result;
        }
        public bool DeleteMessageByGuid(MessageFilter filter)
        {
            bool success = true;
            try
            {
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks
                                .Include("Entry301s")
                                .Include("Entry302s")
                                .Include("Entry501s")
                                .Include("Entry502s")
                                .Include("Entry503s")
                                .Include("Entry504s")
                                .Include("Entry601s")
                                .Include("Entry602s")
                                where m.ItemGuid == filter.Guid
                                select m;
                    db.Entry(query.FirstOrDefault()).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error("DeleteMessageByGuid Exception: " + ex.ToString());
                success = false;
            }
            return success;
        }
        public bool DeleteMessageByFilter(MessageFilter filter)
        {
            bool success = true;
            try
            {
                using (var db = new EntryContext())
                {
                    var query = from m in db.MessageTracks
                                .Include("Entry301s")
                                .Include("Entry302s")
                                .Include("Entry501s")
                                .Include("Entry502s")
                                .Include("Entry503s")
                                .Include("Entry504s")
                                .Include("Entry601s")
                                .Include("Entry602s")
                                where (string.IsNullOrEmpty(filter.OrderNo) ? true : m.OrderNo.IndexOf(filter.OrderNo) >= 0)
                                && (string.IsNullOrEmpty(filter.LogisticsNo) ? true : m.LogisticsNo.IndexOf(filter.LogisticsNo) >= 0)
                                && (filter.Status.Equals("All") ? true : filter.Status.Equals("True") ? m.IsFinished : !m.IsFinished)
                                && (filter.Start.Ticks == 0 ? true : m.LastUpdateTicks >= filter.Start.Ticks)
                                && (filter.End.Ticks == 0 ? true : m.LastUpdateTicks <= filter.End.Ticks)
                                select m;
                    db.MessageTracks.RemoveRange(query);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logs.Error("DeleteMessageByFilter Exception: " + ex.ToString());
                success = false;
            }
            return success;
        }
    }
}
