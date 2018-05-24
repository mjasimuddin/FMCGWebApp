using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using FMCGWebApp.Models;
using FMCGWebApp.ViewModels;

namespace FMCGWebApp.Gateway
{
    public class WhInchargeGateway
    {
        private SqlConnection _connection = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["FMCGDB"].ConnectionString);

        public List<Stockout> SellOrderList()
        {
            string query = "SELECT * FROM tb_StockOut Where Status = '" + "Ordered" + "'";
            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                List<Stockout> stockoutList = new List<Stockout>();
                while (dr.Read())
                {
                    Stockout stockout = new Stockout();
                    stockout.Id = (int)dr["Id"];
                    stockoutList.Add(stockout);
                }
                dr.Close();
                return stockoutList;
            }
            catch (Exception exception)
            {

                throw new Exception("Unable to connect Server", exception);
            }
            finally
            {
                _connection.Close();
            }
        }

    }
}