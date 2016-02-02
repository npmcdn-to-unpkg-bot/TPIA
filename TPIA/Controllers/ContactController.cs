using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPIA.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 連絡我們
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            return View();
        }

    }
}
