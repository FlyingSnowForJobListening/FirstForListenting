using System;

namespace FS.Message.Structure
{
    public class LogisticsHead
    {
        /// <summary>
        /// 36位系统唯一序号
        /// </summary>
        public Guid guid { get; set; }
        /// <summary>
        /// 主管海关代码,物流企业选择通关现场的海关4位代码
        /// </summary>
        public string customsCode { get; set; }
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
        /// 订单编号
        /// </summary>
        public string orderNo { get; set; }
        /// <summary>
        /// 电商平台代码,10位海关代码
        /// </summary>
        public string ebpCode { get; set; }
        /// <summary>
        /// 电商平台名称
        /// </summary>
        public string ebpName { get; set; }
        /// <summary>
        /// 物流企业代码,10位海关代码
        /// </summary>
        public string logisticsCode { get; set; }
        /// <summary>
        /// 物流企业名称
        /// </summary>
        public string logisticsName { get; set; }
        /// <summary>
        /// 物流运单编号
        /// </summary>
        public string logisticsNo { get; set; }
        /// <summary>
        /// 进出口标志,I/E标志
        /// </summary>
        public OrderType ieFlag { get; set; }
        /// <summary>
        /// 运输方式代码,海关参数代码
        /// </summary>
        public string trafMode { get; set; }
        /// <summary>
        /// 运输工具名称,物流企业提供
        /// </summary>
        public string trafName { get; set; }
        /// <summary>
        /// 航班航次号,物流企业提供
        /// </summary>
        public string voyageNo { get; set; }
        /// <summary>
        /// 提运单号,物流企业提供
        /// </summary>
        public string billNo { get; set; }
        /// <summary>
        /// 订单运输费用
        /// </summary>
        public float? freight { get; set; }
        /// <summary>
        /// 订单保价费用
        /// </summary>
        public float? insuredFee { get; set; }
        /// <summary>
        /// 币制,海关参数代码
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 进出口货的实际毛重,单位为千克
        /// </summary>
        public float? weight { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public float? netWt { get; set; }
        /// <summary>
        /// 件数(包裹数量)
        /// </summary>
        public float? packNo { get; set; }
        /// <summary>
        /// 包裹单信息,用/分割多个包裹单号
        /// </summary>
        public string parcelInfo { get; set; }
        /// <summary>
        /// 商品简要信息，物流企业可视验的运输商品信息
        /// </summary>
        public string goodsInfo { get; set; }
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
        /// 收货人所在国家(地区),海关参数代码
        /// </summary>
        public string consigneeCountry { get; set; }
        /// <summary>
        /// 发货人名称
        /// </summary>
        public string shipper { get; set; }
        /// <summary>
        /// 发货人地址
        /// </summary>
        public string shipperAddress { get; set; }
        /// <summary>
        /// 发货人电话
        /// </summary>
        public string shipperTelephone { get; set; }
        /// <summary>
        /// 发货人所在国家(地区)代码
        /// </summary>
        public string shipperCountry { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }
    }
}
