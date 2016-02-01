
namespace TPIA.Common.DTO.Company
{
    /// <summary>
    /// 取得公司清單
    /// </summary>
    public class GetCompanyListReturnDTO
    {
        /// <summary>
        /// 公司代碼
        /// </summary>
        public int CID { get; set; }
        /// <summary>
        /// 公司名稱
        /// </summary>
        public string CompanyName { get; set; }
    }
}