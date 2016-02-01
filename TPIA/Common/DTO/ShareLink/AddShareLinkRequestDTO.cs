using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPIA.Common.Enumeration;

namespace TPIA.Common.DTO.ShareLink
{
    public class AddShareLinkRequestDTO
    {
        /// <summary>
        /// 連結類別
        /// </summary>
        public enLinkCategory Category { get; set; }

        /// <summary>
        /// 連結標題
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 連結描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 連結圖片
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 連結網址
        /// </summary>
        public string LinkUrl { get; set; }
    }
}