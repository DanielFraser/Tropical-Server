using System;
using System.Data;
using TropicalServer.DAL;

namespace TropicalServer.BLL
{
    public class ReportsBLL
    {
        public DataSet GetProductByProductCategory_BLL(string newItemDescription)
        {
            return (new ReportsDAL().GetProductByProductCategory_DAL(newItemDescription));
        }

        public DataSet GetCustSalesRepNumber_BLL(int newCustSaleRepNum)
        {
            return (new ReportsDAL().GetCustSalesRepNumber_DAL(newCustSaleRepNum));
        }

        public DataSet GetUsersSetting_BLL()
        {
            return (new ReportsDAL().GetUsersSetting_DAL());
        }

        public DataSet GetCustomersSetting_BLL()
        {
            return (new ReportsDAL().GetCustomersSetting_DAL());
        }

        public DataSet GetPriceGroupSetting_BLL()
        {
            return (new ReportsDAL().GetPriceGroupSetting_DAL());
        }

        public DataSet GetRouteInfo_BLL(int newRouteID)
        {
            return (new ReportsDAL().GetRouteInfo_DAL(newRouteID));
        }

        public DataSet GetProduct_BLL(String category)
        {
            return (new ReportsDAL().GetProducts_DAL(category));
        }

        public DataSet GetProductCats_BLL()
        {
            return (new ReportsDAL().GetProductsCats_DAL());
        }

        public DataSet getOrders_BLL(int date, int custID, String custName, String manName)
        {
            return (new ReportsDAL().GetOrders_DAL(date, custID, custName, manName));
        }

        public void delOrder_BLL(int id)
        {
            new ReportsDAL().DelOrder_DAL(id);
        }

        public void updateOrder_BLL(int orderID, string trackingNum, string date, int custID, string custName, string custAddr, int routeNum)
        {
            new ReportsDAL().UpdateOrder_DAL(orderID, trackingNum, date, custID, custName, custAddr, routeNum);
        }

        public DataSet getCustIDs(String curText)
        {
            return (new ReportsDAL().GetCustIds_DAL(curText));
        }

        public DataSet getCustNames(String curText)
        {
            return (new ReportsDAL().GetCustNames_DAL(curText));
        }
    }
}
