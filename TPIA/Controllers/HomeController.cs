using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPIA.Common.DTO.News;

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
            string url = "api/News/GetNewsTitleList";
            List<GetNewsListReturnDTO> resultDto = _apiAdaptor.Get<List<GetNewsListReturnDTO>>(url);
            return View(resultDto);
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
