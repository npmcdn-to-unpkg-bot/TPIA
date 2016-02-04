using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPIA.Common.DTO.News;
using TPIA.Common.Enumeration;

namespace TPIA.Controllers
{
    /// <summary>
    /// 最新消息 - Web
    /// </summary>
    public class NewsController : Controller
    {
        private TPIA.Common.Adaptor.TLApiAdaptor _apiAdaptor = new TPIA.Common.Adaptor.TLApiAdaptor();

        #region [ FrondEnd]

        public ActionResult Index()
        {
            string url = "api/News/GetNewsTitleList";
            List<GetNewsListReturnDTO> resultDto = _apiAdaptor.Get<List<GetNewsListReturnDTO>>(url);
            return View(resultDto);
        }

        /// <summary>
        /// 取得公會訊息標題列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GuildNewsTitleList()
        {
            string url = "api/News/GetGuildNewsTitleList";
            List<GetNewsListReturnDTO> resultDto = _apiAdaptor.Get<List<GetNewsListReturnDTO>>(url);
            return View(resultDto);
        }

        /// <summary>
        /// 取得產業快訊標題列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetIndustryNewsTitleList()
        {
            string url = "api/News/GetIndustryNewsTitleList";
            List<GetNewsListReturnDTO> resultDto = _apiAdaptor.Get<List<GetNewsListReturnDTO>>(url);
            return View(resultDto);
        }

        /// <summary>
        /// 取得活動快訊標題列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetEventsNewsTitleList()
        {
            string url = "api/News/GetEventsNewsTitleList";
            List<GetNewsListReturnDTO> resultDto = _apiAdaptor.Get<List<GetNewsListReturnDTO>>(url);
            return View(resultDto);
        }

        /// <summary>
        /// 取得展覽通知標題列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetExhibitionsNoticeTitleList()
        {
            string url = "api/News/GetExhibitionsNoticeTitleList";
            List<GetNewsListReturnDTO> resultDto = _apiAdaptor.Get<List<GetNewsListReturnDTO>>(url);
            return View(resultDto);
        }

        /// <summary>
        /// 取得研習課程標題列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetStudiesCourseTitleList()
        {
            string url = "api/News/GetStudiesCourseTitleList";
            List<GetNewsListReturnDTO> resultDto = _apiAdaptor.Get<List<GetNewsListReturnDTO>>(url);
            return View(resultDto);
        }

        /// <summary>
        /// 取得專業發表標題列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProfessionalPostTitleList()
        {
            string url = "api/News/GetProfessionalPostTitleList";
            List<GetNewsListReturnDTO> resultDto = _apiAdaptor.Get<List<GetNewsListReturnDTO>>(url);
            return View(resultDto);
        }


        /// <summary>
        /// 取得 最新消息內文 - Web
        /// </summary>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult NewsContent(int NewsId)
        {
            string url = String.Format("api/News/GetNewsContent?NewsID={0}", NewsId);
            GetNewsContentReturnDTO result = _apiAdaptor.Get<GetNewsContentReturnDTO>(url);
            return View(result);
        }

        #endregion

        #region [ BackEnd ]

        public ActionResult BackEndIndex()
        {
            string url = "api/News/GetNewsTitleList";
            List<GetNewsListReturnDTO> resultDto = _apiAdaptor.Get<List<GetNewsListReturnDTO>>(url);
            return View(resultDto);
        }        

        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNews(AddNewsRequestDTO dto)
        {
            string url = "api/News/AddNews";
            enErrorCode result = _apiAdaptor.Post<AddNewsRequestDTO, enErrorCode>(url, dto);

            return RedirectToAction("BackEndIndex", "News");
        }

        public ActionResult EditNews(int NewsId)
        {
            string url = String.Format("api/News/GetNewsContent?NewsID={0}", NewsId);
            GetNewsContentReturnDTO result = _apiAdaptor.Get<GetNewsContentReturnDTO>(url);

            EditNewsRequestDTO dto = new EditNewsRequestDTO()
            {
                NewsID = NewsId,
                Title = result.NewsTitle,
                Category = result.NewsCategory,
                NewsContent = result.NewsContent
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditNews(EditNewsRequestDTO dto)
        {
            string url = "api/News/EditNews";
            enErrorCode result = _apiAdaptor.Post<EditNewsRequestDTO, enErrorCode>(url, dto);

            return RedirectToAction("BackEndIndex", "News");
        }

        public ActionResult DeleteNews(int NewsId)
        {
            string url = String.Format("api/News/GetNewsContent?NewsID={0}", NewsId);
            GetNewsContentReturnDTO result = _apiAdaptor.Get<GetNewsContentReturnDTO>(url);

            return View(result);
        }

        [HttpPost]
        public ActionResult DeleteNews(string NewsId)
        {
            string url = "api/News/DeleteNews";
            DeleteNewsRequestDTO dto = new DeleteNewsRequestDTO() { NewsID = int.Parse(NewsId) };
            enErrorCode result = _apiAdaptor.Post<DeleteNewsRequestDTO, enErrorCode>(url, dto);

            return RedirectToAction("BackEndIndex", "News");
        }
        #endregion
    }
}
