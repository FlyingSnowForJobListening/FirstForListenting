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
    interface IToolService
    {
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetCache", ResponseFormat = WebMessageFormat.Json)]
        string GetCacheCount();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "AwakeThread", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool AwakeThread();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Clear", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ClearMessageCache(string flag);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "ClearCacheFile", ResponseFormat = WebMessageFormat.Json)]
        int ClearFileCache();

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "ClearFileResidue", ResponseFormat = WebMessageFormat.Json)]
        int ClearFileResidue();
    }
}
