using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TPIA.Common.DTO.Company;
using TPIA.Common.Enumeration;
using TPIA.Entity.Company.Contexts;
using TPIA.Entity.Company.Entities;

namespace TPIA.Controllers.Api
{
    /// <summary>
    /// 企業會員名錄
    /// </summary>
    public class CompanyController : ApiController
    {
        private CompanyContext _dbContext = new CompanyContext();

        #region [ 取得企業會員名錄清單 ]
        /// <summary>
        /// 取得 企業會員名錄清單
        /// </summary>
        /// <returns></returns>
        public List<GetCompanyListReturnDTO> GetCompanyList()
        {
            List<GetCompanyListReturnDTO> lsreturnDto = new List<GetCompanyListReturnDTO>();

            try
            {
                IEnumerable<Company> dbSet = _dbContext.Set<Company>().Where(o => o.IsEnable == true).OrderByDescending(o=>o.CID);

                foreach (Company item in dbSet)
                {
                    GetCompanyListReturnDTO newDto = new GetCompanyListReturnDTO()
                    {
                        CID = item.CID,
                        CompanyName = item.CompanyName
                    };
                    lsreturnDto.Add(newDto);
                }                
            }
            catch (Exception ex)
            {

                throw;
            }
            return lsreturnDto;
        }
        #endregion

        #region [ 取得企業會員詳細資料 ]
        /// <summary>
        /// 取得 企業會員詳細資料
        /// </summary>
        /// <param name="CID">公司代碼</param>
        /// <returns></returns>
        public GetCompayDetailReturnDTO GetCompayDetail(int CID)
        {
            GetCompayDetailReturnDTO returnDto = null;

            returnDto = (from c in _dbContext.Set<Company>()
                         where c.IsEnable == true && c.CID.Equals(CID)
                         select new GetCompayDetailReturnDTO()
                         {
                             CompanyName = c.CompanyName,
                             Manager = c.Manager,
                             Sales = c.Sales,
                             AboutUs = c.AboutUs,
                             Address = c.Address,
                             Phone = c.Phone,
                             Tax = c.Tax,
                             EMail = c.EMail,
                             MainProducts = c.MainProducts,
                             SiteURL = c.SiteURL,

                             Products = _dbContext.Set<CompanyProduct>().Where(p => p.CID.Equals(CID)).Select(p => new GetCompayProductDTO()
                             {
                                 ProductTitle = p.ProductTitle,
                                 ProductImgURL = p.ProductImgURL,
                                 ProductDesc = p.ProductDesc
                             }).AsEnumerable()
                         }).FirstOrDefault();

            return returnDto;
        }

        public GetCompayInfoReturnDTO GetCompayInfo(int CID)
        {
            GetCompayInfoReturnDTO returnDto = null;

            returnDto = (from c in _dbContext.Set<Company>()
                         where c.IsEnable == true && c.CID.Equals(CID)
                         select new GetCompayInfoReturnDTO()
                         {
                             CID = c.CID,
                             CompanyName = c.CompanyName,
                             Manager = c.Manager,
                             Sales = c.Sales,
                             AboutUs = c.AboutUs,
                             Address = c.Address,
                             Phone = c.Phone,
                             Tax = c.Tax,
                             EMail = c.EMail,
                             MainProducts = c.MainProducts,
                             SiteURL = c.SiteURL,
                         }).FirstOrDefault();

            return returnDto;
        }
        #endregion

        #region [ BackEnd ]

        #region [ 新增企業會員 ]
        [HttpPost]
        public enErrorCode AddCompayInfo(AddCompanyInfoRequestDTO dto)
        {
            enErrorCode enCode = enErrorCode.EXCEPTION;
            try
            {

                Company c = new Company()
                {
                    CompanyName = dto.CompanyName,
                    Manager = dto.Manager,
                    Sales = dto.Sales,
                    AboutUs = dto.AboutUs,
                    Address = dto.Address,
                    Phone = dto.Phone,
                    Tax = dto.Tax,
                    EMail = dto.EMail,
                    MainProducts = dto.MainProducts,
                    SiteURL = dto.SiteURL,
                    IsEnable = true
                };

                var dbSet = _dbContext.Set<Company>().Add(c);
                int result = _dbContext.SaveChanges();

                if (result == 1)
                {
                    enCode = enErrorCode.SUCCESS;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return enCode;
        }
        #endregion

        #region [ 編輯企業資訊 ]
        [HttpPost]
        public enErrorCode EditCompayInfo(EditCompanyInfoRequestDTO dto)
        {
            enErrorCode enCode = enErrorCode.EXCEPTION;
            try
            {
                Company c = _dbContext.Set<Company>().Find(dto.CID);
                c.CompanyName = dto.CompanyName;
                c.Manager = dto.Manager;
                c.Sales = dto.Sales;
                c.AboutUs = dto.AboutUs;
                c.Address = dto.Address;
                c.Phone = dto.Phone;
                c.Tax = dto.Tax;
                c.EMail = dto.EMail;
                c.MainProducts = dto.MainProducts;
                c.SiteURL = dto.SiteURL;
                int result = _dbContext.SaveChanges();

                if (result == 1)
                {
                    enCode = enErrorCode.SUCCESS;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return enCode;
        }
        #endregion

        #region [ 刪除消息 ]
        [HttpPost]
        public enErrorCode DeleteCompayInfo(int CID)
        {
            enErrorCode enCode = enErrorCode.EXCEPTION;
            try
            {
                Company n = _dbContext.Set<Company>().Find(CID);
                n.IsEnable = false;
                int result = _dbContext.SaveChanges();

                if (result == 1)
                {
                    enCode = enErrorCode.SUCCESS;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return enCode;
        }
        #endregion

        #endregion
    }
}
