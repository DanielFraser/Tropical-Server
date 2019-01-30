using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace TropicalServer.DAL
{
    public class ReportsDAL
    {
        string connString = Convert.ToString(ConfigurationManager.AppSettings["TropicalServerConnectionString"]);

        /*
         * Insert item description to get the #, description, 
         * pre-price and size of the item           
         */
        public DataSet GetProductByProductCategory_DAL(string newItemDescription)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            DataSet ds = new DataSet();

            parameters[0] = new SqlParameter("@itemDescription", SqlDbType.NVarChar);

            if (newItemDescription.Trim() != string.Empty)
                parameters[0].Value = newItemDescription.Trim();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetProductByProductCategory", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        SqlParameter p = null;
                        foreach (SqlParameter sqlP in parameters)
                        {
                            p = sqlP;
                            if (p != null)
                            {
                                if (p.Direction == ParameterDirection.InputOutput ||
                                   p.Direction == ParameterDirection.Input && p.Value == null)
                                {
                                    p.Value = DBNull.Value;
                                }
                                command.Parameters.Add(p);
                            }
                        }
                    }
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Product Categories - " + ex.Message.ToString());
            }
        }//End of GetProductByProductCategory_DAL method...

        /*
         *Enter a number to populate 
         * the CustSalesRepNumber
         */
        public DataSet GetCustSalesRepNumber_DAL(int newCustSaleRepNum)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            DataSet ds = new DataSet();

            parameters[0] = new SqlParameter("@custSaleRepNum", SqlDbType.Int);

            if (newCustSaleRepNum != 0)
                parameters[0].Value = newCustSaleRepNum;

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetCustSalesRepNumber", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        SqlParameter p = null;
                        foreach (SqlParameter sqlP in parameters)
                        {
                            p = sqlP;
                            if (p != null)
                            {
                                if (p.Direction == ParameterDirection.InputOutput ||
                                   p.Direction == ParameterDirection.Input && p.Value == null)
                                {
                                    p.Value = DBNull.Value;
                                }
                                command.Parameters.Add(p);
                            }
                        }
                    }
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Sales Representative Number - " + ex.Message.ToString());
            }
        }// End of GetCustSalesRepNumber_DAL method...

        /*
         * Select custSalesRepNum on the 
         * side bar to get the route info.
         */
        public DataSet GetRouteInfo_DAL(int newRouteID)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            DataSet ds = new DataSet();

            parameters[0] = new SqlParameter("@roleID", SqlDbType.Int);

            parameters[0].Value = newRouteID;

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetRouteInfo", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        SqlParameter p = null;
                        foreach (SqlParameter sqlP in parameters)
                        {
                            p = sqlP;
                            if (p != null)
                            {
                                if (p.Direction == ParameterDirection.InputOutput ||
                                   p.Direction == ParameterDirection.Input && p.Value == null)
                                {
                                    p.Value = DBNull.Value;
                                }
                                command.Parameters.Add(p);
                            }
                        }
                    }
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }

        }// End of GetRouteInfo_DAL method...

        /*
         * Get the Name,LoginID, password, Role Description
         * of the User who are active(true).
         */
        public DataSet GetUsersSetting_DAL()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetUsersSetting", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }// End of GetRouteInfo_DAL method...

        /*
         * Get the Customers for Setting page.
         */
        public DataSet GetCustomersSetting_DAL()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetCustomersSetting", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }// End of GetCustomersSetting_DAL method...

        /*
         * Get the Price Group Info for Setting page.
         */
        public DataSet GetPriceGroupSetting_DAL()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetPriceGroupSetting", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }// End of GetPriceGroup_DAL method...

        /*public DataSet GetProducts_DAL(String category)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    String select = "select a.ItemNumber, a.ItemDescription, a.PrePrice, CONCAT(a.ItemUnits, ' x ', round(a.ItemWeights * 16, 0), ' oz') as 'Size'";
                    String tables = " from tblItem a";
                    String where = " where a.ItemType = b.ItemTypeNumber and ItemTypeDescription = @cat";
                    connection.Open();
                    SqlCommand command = category == null ? new SqlCommand(select+tables, connection) : new SqlCommand(select+tables+", tblItemType b"+ where, connection);
                    command.CommandType = CommandType.Text;
                    if (category != null)
                        command.Parameters.Add("@cat", SqlDbType.VarChar, 100).Value = category.Trim();
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    System.Diagnostics.Debug.WriteLine(select+"\n" + tables + ", tblItemType b" + "\n where ItemTypeDescription = @cat");
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }*/

        public DataSet GetProducts_DAL(String category)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    String select = "select a.ItemNumber, a.ItemDescription, a.PrePrice, CONCAT(a.ItemUnits, ' x ', round(a.ItemWeights * 16, 0), ' oz') as 'Size', ItemTypeDescription";
                    String rest = " from tblItem a, tblItemType b where a.ItemType = b.ItemTypeNumber";
                    connection.Open();
                    SqlCommand command = new SqlCommand(select + rest, connection);
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }

        public DataSet GetProductsCats_DAL()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                   connection.Open();
                    SqlCommand command = new SqlCommand("select distinct ItemTypeDescription from tblItemType", connection);
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }
        
        public DataSet GetOrders_DAL(int date, int id, String name, String manager)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    // @custID int=null, @custName varchar(200)=null,@managerName varchar(200)=nul
                    connection.Open();
                    SqlCommand command = new SqlCommand("SrchOrders", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 6000;
                    command.Parameters.Add("@orderdate", SqlDbType.Int).Value = date;
                    command.Parameters.Add("@custID", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@custName", SqlDbType.VarChar, 200).Value = name=="" ? null :name;
                    command.Parameters.Add("@managerName", SqlDbType.VarChar,200).Value = manager == "" ? null : manager;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }

        public void DelOrder_DAL(int orderID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("delete from tblOrder where OrderID = @ordID", connection);
                    command.Parameters.Add("@ordID", SqlDbType.Int).Value = orderID;
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 6000;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }

        public DataSet GetCustIds_DAL(String curText)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("searchCustID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 6000;
                    command.Parameters.Add("@id", SqlDbType.VarChar, 100).Value = curText;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }

        public DataSet GetCustNames_DAL(String curText)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("searchCustName", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 6000;
                    command.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = curText;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }

        public void UpdateOrder_DAL(int orderID, string trackingNum, string date, int custID, string custName, string custAddr, int routeNum)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("updateOrder", connection);
                    DateTime dt = DateTime.ParseExact(date, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    command.Parameters.Add("@id", SqlDbType.Int).Value = orderID;
                    command.Parameters.Add("@track", SqlDbType.VarChar, 100).Value = trackingNum;
                    command.Parameters.Add("@date", SqlDbType.DateTime).Value = dt;
                    command.Parameters.Add("@custID", SqlDbType.Int).Value = custID;
                    command.Parameters.Add("@name", SqlDbType.VarChar, 200).Value = custName;
                    command.Parameters.Add("@addr", SqlDbType.VarChar, 200).Value = custAddr;
                    command.Parameters.Add("@route", SqlDbType.Int).Value = routeNum;

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 6000;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }
    }
}
