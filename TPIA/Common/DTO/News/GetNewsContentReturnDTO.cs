using System;
using TPIA.Common.Enumeration;

namespace TPIA.Common.DTO.News
{
    /// <summary>
    /// 最新消息內文-回傳
    /// </summary>
    public class GetNewsContentReturnDTO
    {
        /// <summary>
        /// 消息編號
        /// </summary>
        public int NewsID { get; set; }
        /// <summary>
        /// 消息分類
        /// </summary>
        public enNewsCategory NewsCategory { get; set; }
        /// <summary>
        /// 消息標題
        /// </summary>
        public string NewsTitle { get; set; }
        /// <summary>
        /// 消息內文
        /// </summary>
        public string NewsContent { get; set; }
        //public string DwgUrl { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}