using System;

namespace TPIA.Common.DTO.News
{
    /// <summary>
    /// 最新消息標題清單-回傳
    /// </summary>
    public class GetNewsListReturnDTO
    {
        /// <summary>
        /// 消息編號
        /// </summary>
        public int NewsID { get; set; }
        /// <summary>
        /// 消息類別
        /// </summary>
        public string NewsCategory { get; set; }
        /// <summary>
        /// 消息標題
        /// </summary>
        public string NewsTitle { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}