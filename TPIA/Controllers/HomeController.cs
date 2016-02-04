using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPIA.Common.DTO.News;
using TPIA.Common.DTO.ShareLink;

namespace TPIA.Controllers
{
    /// <summary>
    /// 首頁功能
    /// </summary>
    public class HomeController : Controller
    {
        private TPIA.Common.Adaptor.TLApiAdaptor _apiAdaptor = new TPIA.Common.Adaptor.TLApiAdaptor();

        /// <summary>
        /// 首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string Nurl = "api/News/GetNewsTitleList";
            List<GetNewsListReturnDTO> NresultDto = _apiAdaptor.Get<List<GetNewsListReturnDTO>>(Nurl);
            ViewBag.NewsList = NresultDto.Take(10);

            string Lurl = "api/Link/GetShareLinkList";
            List<GetShareLinkListReturnDTO> LresultDto = _apiAdaptor.Get<List<GetShareLinkListReturnDTO>>(Lurl);
            ViewBag.LinkList = LresultDto.Take(5);

            return View();
        }

        /// <summary>
        /// 後臺首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult BackEndIndex()
        {
            return View();
        }
    }
}
