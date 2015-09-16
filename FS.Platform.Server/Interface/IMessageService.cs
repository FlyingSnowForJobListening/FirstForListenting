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

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Create501/{orderNoFake}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool CreateMessage501(string orderNoFake);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Create503R/{logisticsNo}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool CreateMessage503R(string logisticsNo);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Create503L/{orderNoFake}", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool CreateMessage503L(string orderNoFake);

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
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "DeleteByGuid", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool DeleteMessageByGuid(MessageFilter filter);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "DeleteByFilter", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool DeleteMessageByFilter(MessageFilter filter);
    }
}
