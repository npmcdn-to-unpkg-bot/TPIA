using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPIA.Common.DTO.ShareLink;
using TPIA.Common.Enumeration;

namespace TPIA.Controllers
{
    public class ShareLinkController : Controller
    {
        private TPIA.Common.Adaptor.TLApiAdaptor _apiAdaptor = new TPIA.Common.Adaptor.TLApiAdaptor();

        #region [ FrondEnd]

        public ActionResult Index()
        {
            string url = "api/Link/GetShareLinkList";
            List<GetShareLinkListReturnDTO> resultDto = _apiAdaptor.Get<List<GetShareLinkListReturnDTO>>(url);
            return View(resultDto);
        }

        public ActionResult LayOutContent()
        {
            string url = "api/Link/GetShareLinkList";
            List<GetShareLinkListReturnDTO> resultDto = _apiAdaptor.Get<List<GetShareLinkListReturnDTO>>(url);
            return View(resultDto);
        }

        ///// <summary>
        ///// 取得 最新消息內文 - Web
        ///// </summary>
        ///// <param name="NewsId"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult NewsContent(int NewsId)
        //{
        //    string url = String.Format("api/Link/GetNewsContent?NewsID={0}", NewsId);
        //    GetNewsContentReturnDTO result = _apiAdaptor.Get<GetNewsContentReturnDTO>(url);
        //    return View(result);
        //}

        #endregion

        #region [ BackEnd ]

        public ActionResult BackEndIndex()
        {
            string url = "api/Link/GetShareLinkList";
            List<GetShareLinkListReturnDTO> resultDto = _apiAdaptor.Get<List<GetShareLinkListReturnDTO>>(url);
            return View(resultDto);
        }

        public ActionResult AddShareLink()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShareLink(AddShareLinkRequestDTO dto)
        {
            string url = "api/Link/AddShareLink";
            enErrorCode result = _apiAdaptor.Post<AddShareLinkRequestDTO, enErrorCode>(url, dto);

            return RedirectToAction("BackEndIndex", "ShareLink");
        }

        public ActionResult EditShareLink(int LId)
        {
            string url = String.Format("api/Link/GetLinkDetail?LID={0}", LId);
            GetLinkDetailReturnDTO result = _apiAdaptor.Get<GetLinkDetailReturnDTO>(url);

            EditShareLinkRequestDTO dto = new EditShareLinkRequestDTO()
            {
                LID = result.LID,
                Category = result.Category,
                Title = result.Title,
                Description = result.Description,
                ImgUrl = result.ImgUrl,
                LinkUrl = result.LinkUrl
            };
            return View(dto);
        }

        [HttpPost]
        public ActionResult EditShareLink(EditShareLinkRequestDTO dto)
        {
            string url = "api/Link/EditShareLink";
            enErrorCode result = _apiAdaptor.Post<EditShareLinkRequestDTO, enErrorCode>(url, dto);

            return RedirectToAction("BackEndIndex", "ShareLink");
        }

        //public ActionResult DeleteNews(int NewsId)
        //{
        //    string url = String.Format("api/News/GetNewsContent?NewsID={0}", NewsId);
        //    GetNewsContentReturnDTO result = _apiAdaptor.Get<GetNewsContentReturnDTO>(url);

        //    return View(result);
        //}

        //[HttpPost]
        //public ActionResult DeleteNews(string NewsId)
        //{
        //    string url = "api/News/DeleteNews";
        //    enErrorCode result = _apiAdaptor.Post<int, enErrorCode>(url, int.Parse(NewsId));

        //    return RedirectToAction("BackEndIndex", "ShareLink");
        //}
        #endregion

    }
}
