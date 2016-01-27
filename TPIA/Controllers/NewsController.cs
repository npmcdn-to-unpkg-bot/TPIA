using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPIA.Common.DTO.News;

namespace TPIA.Controllers
{
    /// <summary>
    /// 最新消息 - Web
    /// </summary>
    public class NewsController : Controller
    {
        private TPIA.Common.Adaptor.TLApiAdaptor _apiAdaptor = new TPIA.Common.Adaptor.TLApiAdaptor();
                
        /// <summary>
        /// 取得 最新消息內文 - Web
        /// </summary>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetNewsContent(int NewsId)
        {
            string url = "News/GetNewsTitleList";
            GetNewsContentReturnDTO result = _apiAdaptor.Get<GetNewsContentReturnDTO>(url);
            return View();
        }
    }
}
