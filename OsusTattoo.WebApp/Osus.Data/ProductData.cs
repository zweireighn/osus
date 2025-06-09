using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osus.Core;

namespace Osus.Data
{
    public class ProductData
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public ProductData()
        {

        }

        #region Load
        private readonly string LoadProduct_Command = @"SELECT TOP (15) Id, Name, Category, DateCreation, ImagePath FROM [Product] order by DateCreation desc";

        public List<Product> LoadProduct()
        {
            Product productResult = null;
            List<Product> productList = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(LoadProduct_Command, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productResult = new Product
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Category = (Core.Enums.Category)Convert.ToInt16(reader["Category"]),
                                DateCreation = Convert.ToDateTime(reader["DateCreation"].ToString()),
                                ImagePath = reader["ImagePath"].ToString(),
                                ProductionVariationList = LoadProductVariantsByProductId(Convert.ToInt32(reader["Id"]))
                            };

                            productList.Add(productResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return productList;
        }

        private readonly string LoadProductVariantsByProductId_Command = @"SELECT Id ,Variant ,Quantity ,Price ,MakePrimary ,Discount ,ProductId FROM [ProductVariation] where ProductId = @ProductId";

        public List<ProductVariation> LoadProductVariantsByProductId(int productId)
        {
            ProductVariation productResult = null;
            List<ProductVariation> productList = new List<ProductVariation>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(LoadProductVariantsByProductId_Command, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@ProductId", SqlDbType.NVarChar).Value = productId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productResult = new ProductVariation
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Variant = reader["Variant"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Price = Convert.ToDecimal(reader["Price"].ToString()),
                                MakePrimary = Convert.ToBoolean(reader["MakePrimary"]),
                                Discount = Convert.ToInt32(reader["Discount"]),
                                ProductId = Convert.ToInt32(reader["ProductId"])
                            };

                            productList.Add(productResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return productList;
        }
        #endregion
    }
}
