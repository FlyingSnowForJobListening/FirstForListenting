using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.Database.Entries;
using FS.Message.Controller;

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

        public List<MessageTrack> GetMessageTracks(MessageFilter filter)
        {
            return null;
        }
    }
}
