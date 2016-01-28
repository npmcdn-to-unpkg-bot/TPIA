
using System;
using TPIA.Common.Enumeration;
namespace TPIA.Common.DTO.News
{
    /// <summary>
    /// 新增最新消息
    /// </summary>
    public class AddNewsRequestDTO
    {
        /// <summary>
        /// 消息類別
        /// </summary>
        public enNewsCategory Category { get; set; }
        /// <summary>
        /// 消息標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 消息內文
        /// </summary>
        public string NewsContent { get; set; }
    }
}
