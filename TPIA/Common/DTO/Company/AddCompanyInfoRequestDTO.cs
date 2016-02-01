using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPIA.Common.DTO.Company
{
    /// <summary>
    /// 企業會員資訊
    /// </summary>
    public class AddCompanyInfoRequestDTO
    {
        /// <summary>
        /// 公司名稱
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司負責人
        /// </summary>
        public string Manager { get; set; }
        /// <summary>
        /// 業務聯絡人
        /// </summary>
        public string Sales { get; set; }
        /// <summary>
        /// 公司簡介
        /// </summary>
        public string AboutUs { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 公司電話
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 公司傳真
        /// </summary>
        public string Tax { get; set; }
        /// <summary>
        /// 電子信箱
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// 主要產品
        /// </summary>
        public string MainProducts { get; set; }
        /// <summary>
        /// 公司網址
        /// </summary>
        public string SiteURL { get; set; }

        /// <summary>
        /// 產品列表
        /// </summary>
        //public IEnumerable<GetCompayProductDTO> Products { get; set; }
    }
}