using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPIA.Controllers
{
    public class GuildRegulationController : Controller
    {
        //
        // GET: /GuildRegulation/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 公會規章
        /// </summary>
        /// <returns></returns>
        public ActionResult GuildRegulation()
        {
            return View();
        }

        /// <summary>
        /// 公會章程
        /// </summary>
        /// <returns></returns>
        public ActionResult GuildConstitution()
        {
            return View();
        }

        /// <summary>
        /// 會員入會須知
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberEnrollmentNotice()
        {
            return View();
        }

        /// <summary>
        /// 入、退費暨繳費細則
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberEnrollmentWithdrawalDetails()
        {
            return View();
        }

    }
}
