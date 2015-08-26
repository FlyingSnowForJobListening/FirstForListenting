namespace FS.Message.Structure
{
    public class InventoryList
    {
        /// <summary>
        /// 商品序号
        /// </summary>
        public int gnum { get; set; }
        /// <summary>
        /// 企业商品货号
        /// </summary>
        public string itemNo { get; set; }
        /// <summary>
        /// 商品备案编号
        /// </summary>
        public string gno { get; set; }
        /// <summary>
        /// 10位海关商品编码
        /// </summary>
        public string gcode { get; set; }
        /// <summary>
        /// 商品规格类型
        /// </summary>
        public string gname { get; set; }
        /// <summary>
        /// 商品条形码
        /// </summary>
        public string gmodel { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string barCode { get; set; }
        /// <summary>
        /// 最终目的国（地区）代码
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 币制代码
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 成交数量
        /// </summary>
        public float? qty { get; set; }
        /// <summary>
        /// 币制
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 法定数量
        /// </summary>
        public float? qty1 { get; set; }
        /// <summary>
        /// 币制
        /// </summary>
        public string unit1 { get; set; }
        /// <summary>
        /// 法定数量
        /// </summary>
        public float? qty2 { get; set; }
        /// <summary>
        /// 币制
        /// </summary>
        public string unit2 { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public float? price { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public float? total { get; set; }
    }
}
