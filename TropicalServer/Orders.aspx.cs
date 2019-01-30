using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;
using System.Web.UI.WebControls;
using TropicalServer.BLL;

namespace TropicalServer
{
    public partial class Orders : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Cache["dateNum"] = 0;
                Cache["custID"] = -1;
                Cache["custName"] = "";
                Cache["manName"] = "";
                String[] temp = new ReportsBLL().getCustNames("").Tables[0].AsEnumerable().Select(x => x.Field<string>("CustName")).ToArray();
                foreach (string item in temp)
                {
                    manager.Items.Add(new ListItem(item, item));
                }
                updateGrid();
            }
        }

        protected void ordgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            updateGrid();
            ordersgrid.PageIndex = e.NewPageIndex;
            ordersgrid.DataBind();
        }

        private void updateGrid()
        {
            int dateNum = (int) Cache["dateNum"], custID = (int)Cache["custID"];
            String custName = (String) Cache["custName"], manName = (String)Cache["manName"];
            //System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3}",dateNum, custID, custName, manName);
            ordersgrid.DataSource = new ReportsBLL().getOrders_BLL(dateNum, custID, custName, manName);
            ordersgrid.DataBind();
        }

        protected void dateDLChange(object sender, EventArgs e)
        {
            Cache["dateNum"] = Int32.Parse(dateDL.SelectedValue);
            updateGrid();
        }
        protected void custIDChange(object sender, EventArgs e)
        {
            Cache["custID"] = custid.Text == "" ? -1 : Int32.Parse(custid.Text);
            System.Diagnostics.Debug.WriteLine("{0}", Cache["custID"]);
            updateGrid();
        }

        protected void custNameChange(object sender, EventArgs e)
        {
            Cache["custName"] = custname.Text;
            updateGrid();
        }

        protected void manNameDLChange(object sender, EventArgs e)
        {
            Cache["manName"] = manager.SelectedValue.ToString();
            updateGrid();
        }

        protected void DelOrder(object sender, EventArgs e)
        {
            int orderID = Int32.Parse(((LinkButton)sender).CommandArgument.ToString());
            new ReportsBLL().delOrder_BLL(orderID);
            //System.Diagnostics.Debug.WriteLine("Deleted: " + orderID);
            updateGrid();
        }

        protected void OrderGridUpdate(object sender, GridViewEditEventArgs e)
        {
            // Write here code for edit Rows 
        }

        protected void orderItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                string id = e.CommandArgument.ToString();
                //set the index of the row to edit (GridView.EditIndex Property)
                int rowInsert = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                ordersgrid.EditIndex = rowInsert;

                ordersgrid.DataBind();
                updateGrid();
            }

            if (e.CommandName == "CancelUpdate")
            {
                ordersgrid.EditIndex = -1;
                updateGrid();
            }

            if (e.CommandName == "UpdateRow")
            {
                int rowInsert = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                int orderID = Convert.ToInt32(e.CommandArgument);
                string trackingNum = ((TextBox)ordersgrid.Rows[rowInsert].Cells[1].Controls[0]).Text;
                string date = ((TextBox)ordersgrid.Rows[rowInsert].Cells[2].Controls[0]).Text;
                System.Diagnostics.Debug.WriteLine(((TextBox)ordersgrid.Rows[rowInsert].Cells[6].Controls[0]).Text);
                int custID = Int32.Parse(((TextBox)ordersgrid.Rows[rowInsert].Cells[3].Controls[0]).Text);
                string custName = ((TextBox)ordersgrid.Rows[rowInsert].Cells[4].Controls[0]).Text;
                string custAddr = ((TextBox)ordersgrid.Rows[rowInsert].Cells[5].Controls[0]).Text;
                string temp = ((TextBox)ordersgrid.Rows[rowInsert].Cells[6].Controls[0]).Text;
                int routeNum = temp =="" ? -1 : Int32.Parse(temp);
                
                new ReportsBLL().updateOrder_BLL(orderID, trackingNum, date, custID, custName, custAddr, routeNum);

                ordersgrid.EditIndex = -1;
                updateGrid();
            }
        }

        [WebMethod]
        public static List<string> GetCustIDs(string prefixText, int count)
        {
            DataSet ds = new ReportsBLL().getCustIDs(prefixText);
            List<string> custIDs = new List<string>();
            custIDs = ds.Tables[0].AsEnumerable().Select(x => x.Field<int>("CustID").ToString()).ToList();
            //System.Diagnostics.Debug.WriteLine("A: "+custIDs.LongCount());
            return custIDs.Where(x => x.StartsWith(prefixText)).ToList().Take(10).ToList();
        }

        [WebMethod]
        public static List<string> GetCustNames(string prefixText, int count)
        {
            DataSet ds = new ReportsBLL().getCustNames(prefixText);
            List<string> custNames = new List<string>();
            custNames = ds.Tables[0].AsEnumerable().Select(x => x.Field<string>("CustName")).ToList();
            System.Diagnostics.Debug.WriteLine("A: " + custNames.LongCount());
            return custNames.Take(10).ToList();
        }
    }
}