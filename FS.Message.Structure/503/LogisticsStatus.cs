using System;

namespace FS.Message.Structure
{
    public class LogisticsStatus
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
        /// R/L R运抵,L离境
        /// </summary>
        public string logisticsStatus { get; set; }
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
        /// 备注
        /// </summary>
        public string note { get; set; }
    }
}
