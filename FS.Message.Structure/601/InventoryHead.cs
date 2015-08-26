using System;

namespace FS.Message.Structure
{
    public class InventoryHead
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
        /// 企业内部编号
        /// </summary>
        public string copNo { get; set; }
        /// <summary>
        /// 预录入编号
        /// </summary>
        public string preNo { get; set; }
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
        /// 物流运单编号
        /// </summary>
        public string logisticsNo { get; set; }
        /// <summary>
        /// 物流企业代码,10位海关代码
        /// </summary>
        public string logisticsCode { get; set; }
        /// <summary>
        /// 物流企业名称
        /// </summary>
        public string logisticsName { get; set; }
        /// <summary>
        /// 出境清单编号,海关审批后反馈
        /// </summary>
        public string invtNo { get; set; }
        /// <summary>
        /// 进出口标志,I/E标志
        /// </summary>
        public OrderType ieFlag { get; set; }
        /// <summary>
        /// 出口口岸代码
        /// </summary>
        public string portCode { get; set; }
        /// <summary>
        /// 出口日期
        /// </summary>
        public string ieDate { get; set; }
        /// <summary>
        /// 收发货人代码,出口发货人填写10位海关企业代码
        /// </summary>
        public string ownerCode { get; set; }
        /// <summary>
        /// 收发货人名称,实际发货人的企业名称
        /// </summary>
        public string ownerName { get; set; }
        /// <summary>
        /// 经营单位代码,10位海关代码
        /// </summary>
        public string tradeCode { get; set; }
        /// <summary>
        /// 经营单位名称
        /// </summary>
        public string tradeName { get; set; }
        /// <summary>
        /// 申报单位代码,10位海关代码
        /// </summary>
        public string agentCode { get; set; }
        /// <summary>
        /// 申报单位名称
        /// </summary>
        public string agentName { get; set; }
        /// <summary>
        /// 贸易方式
        /// </summary>
        public string tradeMode { get; set; }
        /// <summary>
        /// 运输方式代码,海关参数代码
        /// </summary>
        public string trafMode { get; set; }
        /// <summary>
        /// 运输工具名称,物流企业提供
        /// </summary>
        public string trafName { get; set; }

        public string voyageNo { get; set; }
        /// <summary>
        /// 提运单号,物流企业提供
        /// </summary>
        public string billNo { get; set; }

        public string loctNo { get; set; }
        /// <summary>
        /// 许可证号
        /// </summary>
        public string licenseNo { get; set; }
        /// <summary>
        /// 运抵国（地区）
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 指运港代码
        /// </summary>
        public string destinationPort { get; set; }
        /// <summary>
        /// 订单运输费用
        /// </summary>
        public float? freight { get; set; }
        /// <summary>
        /// 运费币制
        /// </summary>
        public string freightCurr { get; set; }
        /// <summary>
        /// 运费标志
        /// </summary>
        public string freightMark { get; set; }
        /// <summary>
        /// 订单保价费用
        /// </summary>
        public float? insuredFee { get; set; }
        /// <summary>
        /// 保费币制
        /// </summary>
        public string insuredFeeCurr { get; set; }
        /// <summary>
        /// 保费标志
        /// </summary>
        public string insuredFeeMark { get; set; }
        /// <summary>
        /// 包装种类代码
        /// </summary>
        public string wrapType { get; set; }
        /// <summary>
        /// 件数(包裹数量)
        /// </summary>
        public float? packNo { get; set; }
        /// <summary>
        /// 进出口货的实际毛重,单位为千克
        /// </summary>
        public float? weight { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public float? netWeight { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }
    }
}
