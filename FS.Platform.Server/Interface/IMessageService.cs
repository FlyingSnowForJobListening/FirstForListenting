using FS.Database.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace FS.Platform.Server
{
    [ServiceContract(Namespace = "FS.Platform.Server")]
    public interface IMessageService
    {
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Create301/{orderNo}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool CreateMessage301(string orderNo);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Create601/{logisticsNo}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool CreateMessage601(string logisticsNo);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetByFilter", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<MessageTrack> GetMessageTracksByFilter(MessageFilter filter);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Get", ResponseFormat = WebMessageFormat.Json)]
        List<MessageTrack> GetAllMessageTracks();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetByGuid", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        MessageTrack GetMessageTrackByGuid(MessageFilter Filter);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetCache", ResponseFormat = WebMessageFormat.Json)]
        string GetCacheCount();
    }
}
