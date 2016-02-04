using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TPIA.Common.DTO.News;
using TPIA.Common.Enumeration;
using TPIA.Entity.News.Contexts;
using TPIA.Entity.News.Entities;

namespace TPIA.Controllers.Api
{
    /// <summary>
    /// 最新消息 - Api
    /// </summary>
    public class NewsController : ApiController
    {
        private NewsContext _dbContext = new NewsContext();



        #region [ 取得最新消息標題清單 ]
        /// <summary>
        /// 取得 最新消息標題清單
        /// </summary>
        /// <returns></returns>
        public List<GetNewsListReturnDTO> GetNewsTitleList()
        {
            List<GetNewsListReturnDTO> lsreturnDto = new List<GetNewsListReturnDTO>();

            try
            {
                IEnumerable<News> dbSet = _dbContext.Set<News>().Where(o => o.IsEnable == true).OrderByDescending(o => o.CreateTime);

                foreach (News item in dbSet)
                {
                    GetNewsListReturnDTO newDto = new GetNewsListReturnDTO()
                    {
                        NewsID = item.ID,
                        NewsTitle = item.Title,
                        NewsCategory = item.Category,
                        CreateDate = item.CreateTime
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

        #region [ 取得公會訊息標題清單 ]
        /// <summary>
        /// 取得 公會訊息標題清單
        /// </summary>
        /// <returns></returns>
        public List<GetNewsListReturnDTO> GetGuildNewsTitleList()
        {
            List<GetNewsListReturnDTO> lsreturnDto = new List<GetNewsListReturnDTO>();

            try
            {
                IEnumerable<News> dbSet = _dbContext.Set<News>().Where(o => o.IsEnable == true && o.Category == enNewsCategory.Guild.ToString()).OrderByDescending(o => o.CreateTime);

                foreach (News item in dbSet)
                {
                    GetNewsListReturnDTO newDto = new GetNewsListReturnDTO()
                    {
                        NewsID = item.ID,
                        NewsTitle = item.Title,
                        NewsCategory = item.Category,
                        CreateDate = item.CreateTime
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

        #region [ 取得產業快訊標題清單 ]
        /// <summary>
        /// 取得 公會訊息標題清單
        /// </summary>
        /// <returns></returns>
        public List<GetNewsListReturnDTO> GetIndustryNewsTitleList()
        {
            List<GetNewsListReturnDTO> lsreturnDto = new List<GetNewsListReturnDTO>();

            try
            {
                IEnumerable<News> dbSet = _dbContext.Set<News>().Where(o => o.IsEnable == true && o.Category == enNewsCategory.Industry.ToString()).OrderByDescending(o => o.CreateTime);

                foreach (News item in dbSet)
                {
                    GetNewsListReturnDTO newDto = new GetNewsListReturnDTO()
                    {
                        NewsID = item.ID,
                        NewsTitle = item.Title,
                        NewsCategory = item.Category,
                        CreateDate = item.CreateTime
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

        #region [ 取得活動快訊標題清單 ]
        /// <summary>
        /// 取得 公會訊息標題清單
        /// </summary>
        /// <returns></returns>
        public List<GetNewsListReturnDTO> GetEventsNewsTitleList()
        {
            List<GetNewsListReturnDTO> lsreturnDto = new List<GetNewsListReturnDTO>();

            try
            {
                IEnumerable<News> dbSet = _dbContext.Set<News>().Where(o => o.IsEnable == true && o.Category == enNewsCategory.Activity.ToString()).OrderByDescending(o => o.CreateTime);

                foreach (News item in dbSet)
                {
                    GetNewsListReturnDTO newDto = new GetNewsListReturnDTO()
                    {
                        NewsID = item.ID,
                        NewsTitle = item.Title,
                        NewsCategory = item.Category,
                        CreateDate = item.CreateTime
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

        #region [ 取得展覽通知標題清單 ]
        /// <summary>
        /// 取得 公會訊息標題清單
        /// </summary>
        /// <returns></returns>
        public List<GetNewsListReturnDTO> GetExhibitionsNoticeTitleList()
        {
            List<GetNewsListReturnDTO> lsreturnDto = new List<GetNewsListReturnDTO>();

            try
            {
                IEnumerable<News> dbSet = _dbContext.Set<News>().Where(o => o.IsEnable == true && o.Category == enNewsCategory.Show.ToString()).OrderByDescending(o => o.CreateTime);

                foreach (News item in dbSet)
                {
                    GetNewsListReturnDTO newDto = new GetNewsListReturnDTO()
                    {
                        NewsID = item.ID,
                        NewsTitle = item.Title,
                        NewsCategory = item.Category,
                        CreateDate = item.CreateTime
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

        #region [ 取得研習課程標題清單 ]
        /// <summary>
        /// 取得 公會訊息標題清單
        /// </summary>
        /// <returns></returns>
        public List<GetNewsListReturnDTO> GetStudiesCourseTitleList()
        {
            List<GetNewsListReturnDTO> lsreturnDto = new List<GetNewsListReturnDTO>();

            try
            {
                IEnumerable<News> dbSet = _dbContext.Set<News>().Where(o => o.IsEnable == true && o.Category == enNewsCategory.Class.ToString()).OrderByDescending(o => o.CreateTime);

                foreach (News item in dbSet)
                {
                    GetNewsListReturnDTO newDto = new GetNewsListReturnDTO()
                    {
                        NewsID = item.ID,
                        NewsTitle = item.Title,
                        NewsCategory = item.Category,
                        CreateDate = item.CreateTime
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

        #region [ 取得專業發表標題清單 ]
        /// <summary>
        /// 取得 公會訊息標題清單
        /// </summary>
        /// <returns></returns>
        public List<GetNewsListReturnDTO> GetProfessionalPostTitleList()
        {
            List<GetNewsListReturnDTO> lsreturnDto = new List<GetNewsListReturnDTO>();

            try
            {
                IEnumerable<News> dbSet = _dbContext.Set<News>().Where(o => o.IsEnable == true && o.Category == enNewsCategory.Project.ToString()).OrderByDescending(o => o.CreateTime);

                foreach (News item in dbSet)
                {
                    GetNewsListReturnDTO newDto = new GetNewsListReturnDTO()
                    {
                        NewsID = item.ID,
                        NewsTitle = item.Title,
                        NewsCategory = item.Category,
                        CreateDate = item.CreateTime
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


        #region [ 取得最新消息內文 ]
        /// <summary>
        /// 取得 最新消息內文
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public GetNewsContentReturnDTO GetNewsContent(int NewsID)
        {
            GetNewsContentReturnDTO returnDto = null;

            News dbSet = _dbContext.Set<News>().FirstOrDefault(o => o.IsEnable == true && o.ID.Equals(NewsID));

            returnDto = new GetNewsContentReturnDTO()
            {
                NewsID = dbSet.ID,
                NewsCategory = (enNewsCategory)Enum.Parse(typeof(enNewsCategory), dbSet.Category),
                NewsTitle = dbSet.Title,
                NewsContent = dbSet.NewsContent,
                CreateDate = dbSet.CreateTime
            };

            return returnDto;
        }
        #endregion

        #region [ BackEnd ]

        #region [ 新增消息 ]
        [HttpPost]
        public enErrorCode AddNews(AddNewsRequestDTO dto)
        {
            enErrorCode enCode = enErrorCode.EXCEPTION;
            try
            {

                News n = new News()
                {
                    Title = dto.Title.Trim(),
                    Category = dto.Category.ToString(),
                    NewsContent = dto.NewsContent.Trim(),
                    IsEnable = true,
                    CreateTime = DateTime.Now
                };

                var dbSet = _dbContext.Set<News>().Add(n);
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

        #region [ 編輯消息 ]
        [HttpPost]
        public enErrorCode EditNews(EditNewsRequestDTO dto)
        {
            enErrorCode enCode = enErrorCode.EXCEPTION;
            try
            {
                News n = _dbContext.Set<News>().Find(dto.NewsID);
                n.Title = dto.Title;
                n.Category = dto.Category.ToString();
                n.NewsContent = dto.NewsContent;
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
        public enErrorCode DeleteNews(DeleteNewsRequestDTO dto)
        {
            enErrorCode enCode = enErrorCode.EXCEPTION;
            try
            {
                News n = _dbContext.Set<News>().FirstOrDefault(o => o.ID == dto.NewsID);
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
