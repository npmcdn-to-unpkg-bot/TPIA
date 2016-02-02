using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPIA.Controllers
{
    public class DecreeReproducedController : Controller
    {
        //
        // GET: /DecreeReproduced/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 政府公告
        /// </summary>
        /// <returns></returns>
        public ActionResult GovernmentNotice()
        {
            return View();
        }

        /// <summary>
        /// 常用法令
        /// </summary>
        /// <returns></returns>
        public ActionResult CommonDecree()
        {
            return View();
        }

        /// <summary>
        /// 統計資料
        /// </summary>
        /// <returns></returns>
        public ActionResult DataStatistics()
        {
            return View();
        }

    }
}
