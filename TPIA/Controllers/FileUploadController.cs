using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPIA.Controllers
{
    /// <summary>
    /// 檔案上傳
    /// </summary>
    public class FileUploadController : Controller
    {
        /// <summary>
        /// ckeditor上傳圖片
        /// </summary>
        /// <param name="upload">預設參數叫upload</param>
        /// <param name="CKEditorFuncNum"></param>
        /// <param name="CKEditor"></param>
        /// <param name="langCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadPicture(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string result = "";
            if (upload != null && upload.ContentLength > 0)
            {
                string extension = Path.GetExtension(upload.FileName);
                string ImgName = String.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), extension);
                //儲存圖片至Server
                upload.SaveAs(Server.MapPath("~/FileUpload/Images/" + ImgName));

                var imageUrl = Url.Content("~/FileUpload/Images/" + ImgName);

                var vMessage = string.Empty;

                result = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + imageUrl + "\", \"" + vMessage + "\");</script></body></html>";

            }

            return Content(result);
        }

    }
}
