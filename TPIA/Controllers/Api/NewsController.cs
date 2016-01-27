using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TPIA.Common.DTO.News;
using TPIA.Entiy;

namespace TPIA.Controllers.Api
{
    /// <summary>
    /// 最新消息 - Api
    /// </summary>
    public class NewsController : ApiController
    {        
        /// <summary>
        /// 取得 最新消息標題清單
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetNewsListReturnDTO> GetNewsTitleList()
        {
            IEnumerable<GetNewsListReturnDTO> returnDto = null;

            NewsEntities newsEn = new NewsEntities();
            returnDto = newsEn.GetNewsList();

            return returnDto;
        }
       
    }
}
