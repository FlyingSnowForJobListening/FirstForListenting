using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.Database.Entries;
using FS.Message.Controller;
using FS.Log;
using FS.Database;

namespace FS.Platform.Server
{
    public class MessageService : IMessageService
    {
        public bool CreateMessage301(string orderNo)
        {
            MessageControl msControl = new MessageControl();
            return msControl.CreateMessage301(orderNo);
        }

        public bool CreateMessage601(string orderNo)
        {
            return true;
        }

        public List<MessageTrack> GetAllMessageTracks()
        {
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

        public List<MessageTrack> GetMessageTracks(MessageFilter filter)
        {
            return null;
        }
    }
}
