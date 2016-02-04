using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPIA.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/
        /// <summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 印刷會訊
        /// </summary>
        /// <returns></returns>
        public ActionResult PrintNewsletter()
        {
            return View();
        }

        /// <summary>
        /// 出版品訂購
        /// </summary>
        /// <returns></returns>
        public ActionResult Order()
        {
            return View();
        }

    }
}
