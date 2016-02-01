using TPIA.Common.Enumeration;

namespace TPIA.Common.DTO.ShareLink
{
    public class GetLinkDetailReturnDTO
    {
        /// <summary>
        /// 連結編號
        /// </summary>
        public int LID { get; set; }

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