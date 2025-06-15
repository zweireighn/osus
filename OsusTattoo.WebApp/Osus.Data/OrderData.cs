using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osus.Core.Enums;
using Osus.Core;
using System.Configuration;

namespace Osus.Data
{
    public class OrderData
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public OrderData() 
        {

        }

        #region Load
        private readonly string LoadOrderByVariantId_Command = @"SELECT TOP(1) [Id] ,[Quantity] ,[TotalAmount] ,[CreationDateTime] ,[Status] ,[DeliveredDate] ,[TrackingNumber] ,
                                                                [UserId] ,[ProductVariationId] ,[SessionId] FROM [Order] 
                                                                where ProductVariationId = @ProductVariationId and (UserId = @UserId or SessionId = @SessionId)";

        public Order LoadOrderByVariantId(int variantId, int? userId, string sessionId)
        {
            Order orderResult = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(LoadOrderByVariantId_Command, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@ProductVariationId", SqlDbType.Int).Value = variantId;
                    if (userId == null)
                    {
                        command.Parameters.AddWithValue("@UserId", SqlDbType.Int).Value =  DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@UserId", SqlDbType.Int).Value = userId;
                    }

                    command.Parameters.AddWithValue("@SessionId", SqlDbType.NVarChar).Value = sessionId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderResult = new Order
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                                CreationDateTime = Convert.ToDateTime(reader["CreationDateTime"].ToString()),
                                OrderStatus = (OrderStatus)Convert.ToInt16(reader["Status"]),
                                DeliveredDate = reader["DeliveredDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DeliveredDate"].ToString()),
                                TrackingNumber = reader["TrackingNumber"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["TrackingNumber"]),
                                UserId = reader["UserId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["UserId"].ToString()),
                                ProductVariationId = reader["ProductVariationId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ProductVariationId"].ToString()),
                                SessionId = reader["SessionId"].ToString(),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return orderResult;
        }

        private readonly string LoadOrderBySessionId_Command = @"SELECT [Id] ,[Quantity] ,[TotalAmount] ,[CreationDateTime] ,[Status] ,[DeliveredDate] ,[TrackingNumber] ,
                                                                [UserId] ,[ProductVariationId] ,[SessionId] FROM [Order] 
                                                                where SessionId = @SessionId";

        public List<Order> LoadOrderBySessionId(string sessionId)
        {
            List<Order> orderList = new List<Order>();
            Order orderResult = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(LoadOrderBySessionId_Command, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@SessionId", SqlDbType.NVarChar).Value = sessionId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderResult = new Order
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                                CreationDateTime = Convert.ToDateTime(reader["CreationDateTime"].ToString()),
                                OrderStatus = (OrderStatus)Convert.ToInt16(reader["Status"]),
                                DeliveredDate = reader["DeliveredDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DeliveredDate"].ToString()),
                                TrackingNumber = reader["TrackingNumber"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["TrackingNumber"]),
                                UserId = reader["UserId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["UserId"].ToString()),
                                ProductVariationId = reader["ProductVariationId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ProductVariationId"].ToString()),
                                SessionId = reader["SessionId"].ToString(),
                            };

                            orderList.Add(orderResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return orderList;
        }

        private readonly string LoadOrderByUserId_Command = @"SELECT [Id] ,[Quantity] ,[TotalAmount] ,[CreationDateTime] ,[Status] ,[DeliveredDate] ,[TrackingNumber] ,
                                                                [UserId] ,[ProductVariationId] ,[SessionId] FROM [Order] 
                                                                where UserId = @UserId";

        public List<Order> LoadOrderByUserId(string sessionId)
        {
            List<Order> orderList = new List<Order>();
            Order orderResult = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(LoadOrderByUserId_Command, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@UserId", SqlDbType.NVarChar).Value = sessionId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderResult = new Order
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString()),
                                CreationDateTime = Convert.ToDateTime(reader["CreationDateTime"].ToString()),
                                OrderStatus = (OrderStatus)Convert.ToInt16(reader["Status"]),
                                DeliveredDate = reader["DeliveredDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DeliveredDate"].ToString()),
                                TrackingNumber = reader["TrackingNumber"] == DBNull.Value ? (long?)null : Convert.ToInt64(reader["TrackingNumber"]),
                                UserId = reader["UserId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["UserId"].ToString()),
                                ProductVariationId = reader["ProductVariationId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ProductVariationId"].ToString()),
                                SessionId = reader["SessionId"].ToString(),
                            };

                            orderList.Add(orderResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return orderList;
        }
        #endregion

        #region Insert
        private readonly string AddToCartOrderInsert_Command = @"INSERT INTO [dbo].[Order] ([Quantity] ,[TotalAmount] ,[CreationDateTime] ,[Status] ,[DeliveredDate] ,[TrackingNumber] ,[UserId] ,[ProductVariationId], [SessionId]) VALUES (@Quantity, @TotalAmount, @CreationDateTime, @Status, @DeliveredDate, @TrackingNumber, @UserId, @ProductVariationId, @SessionId)";

        public bool AddToCartOrderInsert(ProductVariation productVariation)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string command = AddToCartOrderInsert_Command;
                    using (SqlCommand cmd = new SqlCommand(command, connection))
                    {
                        cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = productVariation.Quantity;
                        cmd.Parameters.Add("@TotalAmount", SqlDbType.NVarChar).Value = productVariation.Price;
                        cmd.Parameters.Add("@CreationDateTime", SqlDbType.DateTime).Value = DateTime.UtcNow;
                        cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = OrderStatus.AddedToCart;
                        cmd.Parameters.Add("@DeliveredDate", SqlDbType.DateTime).Value = DBNull.Value;
                        cmd.Parameters.Add("@TrackingNumber", SqlDbType.BigInt).Value = DBNull.Value;
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = DBNull.Value;
                        cmd.Parameters.Add("@ProductVariationId", SqlDbType.Int).Value = productVariation.Id;
                        cmd.Parameters.Add("@SessionId", SqlDbType.NVarChar).Value = productVariation.SessionId;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }

                isSuccess = true;
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }

            return isSuccess;
        }
        #endregion
    }
}
