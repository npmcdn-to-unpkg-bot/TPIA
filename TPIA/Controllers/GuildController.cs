using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPIA.Controllers
{
    public class GuildController : Controller
    {
        //
        // GET: /Guild/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 關於公會
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutGuild()
        {
            return View();
        }

        /// <summary>
        /// 公會沿革
        /// </summary>
        /// <returns></returns>
        public ActionResult GuildHistory()
        {
            return View();
        }

        /// <summary>
        /// 公會簡介
        /// </summary>
        /// <returns></returns>
        public ActionResult GuildBriefInt()
        {
            return View();
        }

        /// <summary>
        /// 公會組織
        /// </summary>
        /// <returns></returns>
        public ActionResult GuildForm()
        {
            return View();
        }

        /// <summary>
        /// 會務發展
        /// </summary>
        /// <returns></returns>
        public ActionResult GuildBusiness()
        {
            return View();
        }

        /// <summary>
        /// 公會組織圖
        /// </summary>
        /// <returns></returns>
        public ActionResult GuildFormDraw()
        {
            return View();
        }
    }
}
