using System;
using System.Collections.Generic;
using System.Web.Http;
using TPIA.Common.DTO.ShareLink;
using TPIA.Common.Enumeration;
using TPIA.Entity.ShareLink.Contexts;
using TPIA.Entity.ShareLink.Entities;

namespace TPIA.Controllers.Api
{
    /// <summary>
    /// 友好連結
    /// </summary>
    public class LinkController : ApiController
    {
        private ShareLinkContext _dbContext = new ShareLinkContext();

        #region [ 取得友好連結清單 ]
        /// <summary>
        /// 取得 企業會員名錄清單
        /// </summary>
        /// <returns></returns>
        public List<GetShareLinkListReturnDTO> GetShareLinkList()
        {
            List<GetShareLinkListReturnDTO> lsreturnDto = new List<GetShareLinkListReturnDTO>();

            try
            {
                var dbSet = _dbContext.Set<ShareLink>();

                foreach (ShareLink item in dbSet)
                {
                    GetShareLinkListReturnDTO newDto = new GetShareLinkListReturnDTO()
                    {
                        LID = item.LID,
                        Category = (enLinkCategory)Enum.Parse(typeof(enLinkCategory), item.Category),
                        Title = item.Title,
                        Description = item.Description,
                        ImgUrl = item.ImgUrl,
                        LinkUrl = item.LinkUrl
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

        #region [ 取得友好連結詳細資料 ]
        /// <summary>
        /// 取得 企業會員詳細資料
        /// </summary>
        /// <param name="CID">公司代碼</param>
        /// <returns></returns>
        public GetLinkDetailReturnDTO GetLinkDetail(int LID)
        {
            GetLinkDetailReturnDTO returnDto = null;

            ShareLink sl = _dbContext.Set<ShareLink>().Find(LID);

            returnDto = new GetLinkDetailReturnDTO()
            {
                LID = sl.LID,
                Category = (enLinkCategory)Enum.Parse(typeof(enLinkCategory), sl.Category),
                Title = sl.Title,
                Description = sl.Description,
                ImgUrl = sl.ImgUrl,
                LinkUrl = sl.LinkUrl
            };

            return returnDto;
        }
        #endregion

        #region [ BackEnd ]

        #region [ 新增連結 ]
        [HttpPost]
        public enErrorCode AddShareLink(AddShareLinkRequestDTO dto)
        {
            enErrorCode enCode = enErrorCode.EXCEPTION;
            try
            {

                ShareLink sl = new ShareLink()
                {
                    Category = dto.Category.ToString(),
                    Title = (String.IsNullOrEmpty(dto.Title)) ? String.Empty : dto.Title,
                    Description = (String.IsNullOrEmpty(dto.Description)) ? String.Empty : dto.Description,
                    ImgUrl = (String.IsNullOrEmpty(dto.ImgUrl)) ? "/" : dto.ImgUrl,
                    LinkUrl = (String.IsNullOrEmpty(dto.LinkUrl)) ? "http://" : dto.LinkUrl
                };

                var dbSet = _dbContext.Set<ShareLink>().Add(sl);
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

        #region [ 編輯連結 ]
        [HttpPost]
        public enErrorCode EditShareLink(EditShareLinkRequestDTO dto)
        {
            enErrorCode enCode = enErrorCode.EXCEPTION;
            try
            {
                ShareLink sl = _dbContext.Set<ShareLink>().Find(dto.LID);
                sl.Category = dto.Category.ToString();
                sl.Title = (String.IsNullOrEmpty(dto.Title)) ? String.Empty : dto.Title;
                sl.Description = (String.IsNullOrEmpty(dto.Description)) ? String.Empty : dto.Description;
                sl.ImgUrl = (String.IsNullOrEmpty(dto.ImgUrl)) ? String.Empty : dto.ImgUrl;
                sl.LinkUrl = (String.IsNullOrEmpty(dto.LinkUrl)) ? String.Empty : dto.LinkUrl;
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

        #region [ 刪除連結 ]
        //[HttpPost]
        //public enErrorCode DeleteCompayInfo(int CID)
        //{
        //    enErrorCode enCode = enErrorCode.EXCEPTION;
        //    try
        //    {
        //        Company n = _dbContext.Set<Company>().Find(CID);
        //        n.IsEnable = false;
        //        int result = _dbContext.SaveChanges();

        //        if (result == 1)
        //        {
        //            enCode = enErrorCode.SUCCESS;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //    return enCode;
        //}
        #endregion

        #endregion
    }
}
