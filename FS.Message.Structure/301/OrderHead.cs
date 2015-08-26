using System;

namespace FS.Message.Structure
{
    public class OrderHead
    {
        /// <summary>
        /// 36位系统唯一序号
        /// </summary>
        public Guid guid { get; set; }
        /// <summary>
        /// 申报类型:1-新增;2-变更;3-删除，默认为1
        /// </summary>
        public int appType { get; set; }
        /// <summary>
        /// 业务时间,格式:YYYYMMDDhhmmss
        /// </summary>
        public DateTime appTime { get; set; }
        /// <summary>
        /// 业务状态,1-暂存,2-申报,默认为2
        /// </summary>
        public int appStatus { get; set; }
        /// <summary>
        /// 用户编号,电子口岸持卡人IC卡或UKEY编号
        /// </summary>
        public string appUid { get; set; }
        /// <summary>
        /// 用户名称,电子口岸持卡人姓名
        /// </summary>
        public string appUname { get; set; }
        /// <summary>
        /// 订单类型,I-进口商品订单;E-出口商品订单
        /// </summary>
        public OrderType orderType { get; set; }

        public string orderNo { get; set; }
        /// <summary>
        /// 电商企业代码
        /// </summary>
        public string ebpCode { get; set; }
        /// <summary>
        /// 电商企业名称
        /// </summary>
        public string ebpName { get; set; }

        public string ebcCode { get; set; }

        public string ebcName { get; set; }
        /// <summary>
        /// 申报单位代码,10位海关代码
        /// </summary>
        public string agentCode { get; set; }
        /// <summary>
        /// 申报单位名称
        /// </summary>
        public string agentName { get; set; }

        public float? goodsValue { get; set; }

        public float? freight { get; set; }
        /// <summary>
        /// 币制
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 收货人名称
        /// </summary>
        public string consignee { get; set; }
        /// <summary>
        /// 收货人地址
        /// </summary>
        public string consigneeAddress { get; set; }
        /// <summary>
        /// 收货人电话
        /// </summary>
        public string consigneeTelephone { get; set; }
        /// <summary>
        /// 收货人所在国家(地区)代码
        /// </summary>
        public string consigneeCountry { get; set; }

        public string note { get; set; }
    }
}
