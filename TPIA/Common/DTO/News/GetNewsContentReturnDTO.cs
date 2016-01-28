using System;

namespace TPIA.Common.DTO.News
{
    /// <summary>
    /// 最新消息內文-回傳
    /// </summary>
    public class GetNewsContentReturnDTO
    {
        //public string NewSClass { get; set; }
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