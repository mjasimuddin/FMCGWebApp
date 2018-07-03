using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using FMCGWebApp.Models;
using FMCGWebApp.ViewModels;

namespace FMCGWebApp.Gateway
{
    public class SellOrderGateway
    {
        private SqlConnection _connection = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["FMCG_Db"].ConnectionString);

        public int SendSellOrder(SellOrder sellOrder)
        {
            string query = @"INSERT INTO [dbo].[tb_StockOut]
           ([CategoryId]
           ,[ItemId]
           ,[Quentity]
           ,[ShopId]
           ,[AreaId]
           ,[EmployeeId]
           ,[OrderCollectDate]
           ,[Status])
     VALUES
           ('" + sellOrder.CategoryId + "', '" + sellOrder.ItemId + "', '" + sellOrder.Quantity + "', '" +
                           sellOrder.ShopId + "', '" + sellOrder.AreaId + "', '" + sellOrder.EmployeeId + "', '" +
                           sellOrder.EntryDate + "', '" + sellOrder.Status + "')";

            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                _connection.Close();

                return rowAffected;
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

        public int UpdateSendSellOrder(SellOrder sellOrder)
        {
            string query = @"UPDATE [dbo].[tb_StockOut] SET [CategoryId] = '" + sellOrder.CategoryId + "' ,[ItemId] = '" +
                           sellOrder.ItemId + "',[Quentity] = '" + sellOrder.Quantity + "',[ShopId] = '" +
                           sellOrder.ShopId + "',[AreaId] = '" + sellOrder.AreaId + "',[EmployeeId] = '" +
                           sellOrder.EmployeeId + "',[Status] = '" + sellOrder.Status + "'WHERE Id = '" + sellOrder.Id +
                           "'";

            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                _connection.Close();

                return rowAffected;
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

        public bool IsSellOrderExists(SellOrder sellOrder)
        {
            try
            {
                string Query =
                    "SELECT * FROM tb_StockOut WHERE (CategoryId = @CategoryId and ItemId = @ItemId and ShopId =@ShopId and Status = @Status)";
                SqlCommand Command = new SqlCommand(Query, _connection);
                _connection.Open();
                Command.Parameters.Clear();
                Command.Parameters.Add("CategoryId", SqlDbType.Int);
                Command.Parameters["CategoryId"].Value = sellOrder.CategoryId;
                Command.Parameters.Add("ItemId", SqlDbType.Int);
                Command.Parameters["ItemId"].Value = sellOrder.ItemId;
                Command.Parameters.Add("ShopId", SqlDbType.Int);
                Command.Parameters["ShopId"].Value = sellOrder.ShopId;
                Command.Parameters.Add("Status", SqlDbType.VarChar);
                Command.Parameters["Status"].Value = sellOrder.Status;
                SqlDataReader Reader = Command.ExecuteReader();
                Reader.Read();
                bool isExist = Reader.HasRows;
                Reader.Close();
                return isExist;
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

        public List<Shop> GetAllShop(int id)
        {
            string query = "SELECT * FROM tb_ShopInfo Where AreaId = '"+ id +"'";
            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                List<Shop> shopList = new List<Shop>();
                while (dr.Read())
                {
                    Shop shop = new Shop();
                    shop.Id = (int)dr["Id"];
                    shop.ShopName = dr["ShopName"].ToString();
                    shopList.Add(shop);
                }
                dr.Close();
                return shopList;
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

        public List<Category> GetAllCategory()
        {
            string query = "SELECT * FROM tb_Category";
            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                List<Category> categoryList = new List<Category>();
                while (dr.Read())
                {
                    Category category = new Category();
                    category.Id = (int)dr["Id"];
                    category.CategoryName = dr["CategoryName"].ToString();
                    categoryList.Add(category);
                }
                dr.Close();
                return categoryList;
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

        public List<Item> GetAllItem(int id)
        {
            string query = "SELECT * FROM tb_Item Where CategoryId = '"+ id +"'";
            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                List<Item> itemList = new List<Item>();
                while (dr.Read())
                {
                    Item item = new Item();
                    item.Id = (int)dr["Id"];
                    item.ItemName = dr["ItemName"].ToString();
                    itemList.Add(item);
                }
                dr.Close();
                return itemList;
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

        public int GetOrderId(SellOrder sellOrder)
        {
            string query = @"SELECT * FROM tb_StockOut WHERE (CategoryId = '" + sellOrder.CategoryId +
                           "' and ItemId = '" + sellOrder.ItemId + "' and ShopId ='" + sellOrder.ShopId +
                           "' and Status = '" + sellOrder.Status + "')";
            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                List<Shop> orderedId = new List<Shop>();
                while (dr.Read())
                {
                    Shop shop = new Shop();
                    shop.Id = (int)dr["Id"];
                    orderedId.Add(shop);
                }
                dr.Close();
                return orderedId.FirstOrDefault().Id;
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

        public bool IsItemExists(SellOrder sellOrder)
        {
            try
            {
                string Query =
                    "SELECT * FROM tb_StockIn WHERE (CategoryId = @CategoryId and ItemId = @ItemId)";
                SqlCommand Command = new SqlCommand(Query, _connection);
                _connection.Open();
                Command.Parameters.Clear();
                Command.Parameters.Add("CategoryId", SqlDbType.Int);
                Command.Parameters["CategoryId"].Value = sellOrder.CategoryId;
                Command.Parameters.Add("ItemId", SqlDbType.Int);
                Command.Parameters["ItemId"].Value = sellOrder.ItemId;
                SqlDataReader Reader = Command.ExecuteReader();
                Reader.Read();
                bool isExist = Reader.HasRows;
                Reader.Close();
                return isExist;
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

        public List<SellOrder> GetAllSellOrder()
        {
            string query = @"SELECT [AreaId]
      ,[ShopId]
      ,[CategoryId]
      ,[ItemId]
      ,[Quentity]
  FROM [dbo].[AddToSendOrder]";
            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                List<SellOrder> itemList = new List<SellOrder>();
                while (dr.Read())
                {
                    SellOrder item = new SellOrder();
                    item.AreaId = (int)dr["AreaId"];
                    item.ShopId = (int)dr["ShopId"];
                    item.CategoryId = (int)dr["CategoryId"];
                    item.ItemId = (int)dr["ItemId"];
                    item.Quantity = (int)dr["Quentity"];
                    itemList.Add(item);
                }
                dr.Close();
                return itemList;
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

        public int ClearHistory()
        {
            string query = @"DELETE FROM [dbo].[AddToSendOrder]";

            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                _connection.Close();

                return rowAffected;
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

        public int AddSellOrder(SellOrder sellOrder)
        {
            string query = @"INSERT INTO [dbo].[AddToSendOrder]
           ([AreaId]
           ,[ShopId]
           ,[CategoryId]
           ,[ItemId]
           ,[Quentity])
     VALUES
           ('" + sellOrder.AreaId + "', '" + sellOrder.ShopId + "', '" + sellOrder.CategoryId + "', '" +
                           sellOrder.ItemId + "', '" + sellOrder.Quantity + "')";

            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                _connection.Close();

                return rowAffected;
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

        public List<SellOrderInfo> GetAllOrder()
        {
            string query = @"Select o.Quentity, a.AreaName, s.ShopName, c.CategoryName, i.ItemName
FROM AddToSendOrder o
INNER JOIN tb_Area a on o.AreaId = a.Id
INNER JOIN tb_ShopInfo s on o.ShopId = s.Id
INNER JOIN tb_Category c on o.CategoryId = c.Id
INNER JOIN tb_Item i on o.ItemId = i.Id";
            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                List<SellOrderInfo> itemList = new List<SellOrderInfo>();
                int number = 1;
                while (dr.Read())
                {
                    SellOrderInfo item = new SellOrderInfo();
                    item.Id = number;
                    item.AreaName = dr["AreaName"].ToString();
                    item.ShopName = dr["ShopName"].ToString();
                    item.CategoryName = dr["CategoryName"].ToString();
                    item.ItemName = dr["ItemName"].ToString();
                    item.Quentity = (int)dr["Quentity"];
                    itemList.Add(item);
                    number++;
                }
                dr.Close();
                return itemList;
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