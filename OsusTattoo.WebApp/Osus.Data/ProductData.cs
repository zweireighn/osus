﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osus.Core;
using Osus.Core.Enums;

namespace Osus.Data
{
    public class ProductData
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public ProductData()
        {

        }

        #region Load
        private readonly string LoadProduct_Command = @"SELECT TOP (15) Id, Name, Category, DateCreation, ImagePath, PrimaryImage FROM [Product] order by DateCreation desc";

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
                                PrimaryImage = reader["PrimaryImage"].ToString(),
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

        private readonly string LoadProductbyProductId_Command = @"SELECT TOP (1) Id, Name, Category, DateCreation, ImagePath, PrimaryImage FROM [Product] where Id = @ProductId";

        public Product LoadProductbyProductId(int productId)
        {
            Product productResult = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(LoadProductbyProductId_Command, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = productId;

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
                                PrimaryImage = reader["PrimaryImage"].ToString(),
                                ProductionVariationList = LoadProductVariantsByProductId(Convert.ToInt32(reader["Id"]))
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return productResult;
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

        private readonly string LoadProductVariantsById_Command = @"SELECT Id ,Variant ,Quantity ,Price ,MakePrimary ,Discount ,ProductId FROM [ProductVariation] where Id = @Id";

        public ProductVariation LoadProductVariantsById(int id)
        {
            ProductVariation productResult = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(LoadProductVariantsById_Command, connection);
                    connection.Open();

                    command.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = id;

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
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return productResult;
        }

        private readonly string LoadProductVariantsByIds_Command = @"SELECT Id ,Variant ,Quantity ,Price ,MakePrimary ,Discount ,ProductId FROM [ProductVariation] where Id in ({0})";

        public List<ProductVariation> LoadProductVariantsByIds(List<int> ids)
        {
            ProductVariation productResult = null;
            List<ProductVariation> productList = new List<ProductVariation>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(string.Format(LoadProductVariantsByIds_Command, string.Join(",", ids)), connection);
                    connection.Open();

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

        #region Insert
        #endregion
    }
}
