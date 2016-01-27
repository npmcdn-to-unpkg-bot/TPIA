using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPIA.Common.Convertor;
using TPIA.Common.DTO.News;

namespace TPIA.FrondEnd
{
    public partial class NewsClass : System.Web.UI.Page
    {
        private TPIA.Common.Adaptor.TLApiAdaptor _apiAdaptor = new TPIA.Common.Adaptor.TLApiAdaptor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

        private void GetData() {
            string url = "api/News/GetNewsTitleList";
            List<GetNewsListReturnDTO> resultDto = _apiAdaptor.Get<List<GetNewsListReturnDTO>>(url);

            DataTable dt = new DataTable();
            dt = ListToDataTable.ConvertToDataTable(resultDto);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


    }
}