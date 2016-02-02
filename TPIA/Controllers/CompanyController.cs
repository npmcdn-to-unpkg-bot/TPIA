using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPIA.Common.DTO.Company;
using TPIA.Common.Enumeration;

namespace TPIA.Controllers
{
    public class CompanyController : Controller
    {
        private TPIA.Common.Adaptor.TLApiAdaptor _apiAdaptor = new TPIA.Common.Adaptor.TLApiAdaptor();

        #region [ FrondEnd]

        public ActionResult Index()
        {
            string url = "api/Company/GetCompanyList";
            List<GetCompanyListReturnDTO> resultDto = _apiAdaptor.Get<List<GetCompanyListReturnDTO>>(url);
            return View(resultDto);
        }

        /// <summary>
        /// 取得 最新消息內文 - Web
        /// </summary>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetCompayDetail(int CId)
        {
            string url = String.Format("api/Company/GetCompayDetail?CID={0}", CId);
            GetCompayDetailReturnDTO result = _apiAdaptor.Get<GetCompayDetailReturnDTO>(url);
            return View(result);
        }
        [HttpGet]
        public ActionResult GetCompayDetailShow(int CID)
        {
            string url = String.Format("api/Company/GetCompayDetail?CID={0}", CID);
            GetCompayDetailReturnDTO resultShow = _apiAdaptor.Get<GetCompayDetailReturnDTO>(url);
            return View(resultShow);
        }

        #endregion

        #region [ BackEnd ]

        public ActionResult BackEndIndex()
        {
            string url = "api/Company/GetCompanyList";
            List<GetCompanyListReturnDTO> resultDto = _apiAdaptor.Get<List<GetCompanyListReturnDTO>>(url);
            return View(resultDto);
        }

        public ActionResult AddCompayInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCompayInfo(AddCompanyInfoRequestDTO dto)
        {
            string url = "api/Company/AddCompayInfo";
            enErrorCode result = _apiAdaptor.Post<AddCompanyInfoRequestDTO, enErrorCode>(url, dto);

            return RedirectToAction("BackEndIndex", "Company");
        }

        public ActionResult EditCompanyInfo(int CId)
        {
            string url = String.Format("api/Company/GetCompayInfo?CID={0}", CId);
            GetCompayInfoReturnDTO result = _apiAdaptor.Get<GetCompayInfoReturnDTO>(url);

            EditCompanyInfoRequestDTO dto = new EditCompanyInfoRequestDTO()
            {
                CID = result.CID,
                CompanyName = result.CompanyName,
                Manager = result.Manager,
                Sales = result.Sales,
                AboutUs = result.AboutUs,
                Address = result.Address,
                Phone = result.Phone,
                Tax = result.Tax,
                EMail = result.EMail,
                MainProducts = result.MainProducts,
                SiteURL = result.SiteURL
            };
            return View(dto);
        }

        [HttpPost]
        public ActionResult EditCompanyInfo(EditCompanyInfoRequestDTO dto)
        {
            string url = "api/Company/EditCompayInfo";
            enErrorCode result = _apiAdaptor.Post<EditCompanyInfoRequestDTO, enErrorCode>(url, dto);

            return RedirectToAction("BackEndIndex", "Company");
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

        //    return RedirectToAction("Index", "Company");
        //}
        #endregion

    }
}
