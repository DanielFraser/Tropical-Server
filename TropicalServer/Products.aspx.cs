using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using TropicalServer.BLL;

namespace TropicalServer
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private static string datacat = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Cache["database"] = new ReportsBLL().GetProduct_BLL(null);
                productsgrid.DataSource = Cache["database"];
                productsgrid.DataBind();

                categoryRpt.DataSource = new ReportsBLL().GetProductCats_BLL();
                categoryRpt.DataBind();
            }
        }

        private void modifygrid()
        {
            if (datacat == null)
            {
                productsgrid.DataSource = Cache["database"];
            }
            else
            {
                DataSet temp = (DataSet)Cache["database"];
                DataRow[] temp2 = temp.Tables[0].Select("ItemTypeDescription = '" + datacat + "'");
                productsgrid.DataSource = (temp2.Length > 0) ? temp2.CopyToDataTable() : temp2.Clone();
            }
            productsgrid.DataBind();
        }

        protected void prodgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            modifygrid();
            productsgrid.PageIndex = e.NewPageIndex;
            productsgrid.DataBind();
        }

        protected void changeCat(object sender, EventArgs e)
        {
            string category = (sender as Button).Text;
            datacat = category;
            System.Diagnostics.Debug.WriteLine(category);

            modifygrid();
            //DataSet temp = (DataSet)Cache["database"];
            //DataRow[] temp2 = temp.Tables[0].Select("ItemTypeDescription = '" + category + "'");
            //productsgrid.DataSource = (temp2.Length > 0) ? temp2.CopyToDataTable() : temp2.Clone(); ;
            //productsgrid.DataBind();

            //productsTbl.DataSource = new ReportsBLL().GetProduct_BLL(category);
            //productsTbl.DataBind();
        }
    }
}