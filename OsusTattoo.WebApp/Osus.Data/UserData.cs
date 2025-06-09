using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osus.Core;

namespace Osus.Data
{
    public class UserData
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public UserData()
        {
            
        }

        #region Load
        private readonly string LoadUserByUserName_Command = @"SELECT TOP (1) Id, UserName, Password, FirstName, LastName, UserRole FROM [User] where UserName = @UserName";

        public User LoadUserByUserName(string userName)
        {
            User userResult = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(LoadUserByUserName_Command, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = userName;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userResult = new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Firstname = reader["FirstName"].ToString(),
                                Lastname = reader["LastName"].ToString(),
                                Email = reader["UserName"].ToString(),
                                Password = reader["Password"].ToString(),
                                UserRole = (Core.Enums.UserRole)Convert.ToInt16(reader["UserRole"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return userResult;
        }
        #endregion

        #region Insert
        private readonly string SaveUser_Command = @"INSERT INTO [User] (UserName, Password, FirstName, LastName, UserRole) VALUES (@UserName, @Password, @FirstName, @LastName, @UserRole)";

        public bool SaveUser(User user)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string command = SaveUser_Command;
                    using (SqlCommand cmd = new SqlCommand(command, connection))
                    {
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = user.Email;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = user.Password;
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.Firstname;
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = user.Lastname;
                        cmd.Parameters.Add("@UserRole", SqlDbType.TinyInt).Value = user.UserRole;
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
