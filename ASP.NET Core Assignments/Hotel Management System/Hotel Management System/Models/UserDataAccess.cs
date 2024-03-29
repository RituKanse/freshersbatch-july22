﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;

namespace Hotel_Management_System.Models
{
    public class UserDataAccess
    {
        public static IConfiguration Configuration { get; set; }

        //To Read ConnectionString from appsettings.json file  
        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            string connectionString = Configuration["ConnectionStrings:HotelManagementSystemContext"];

            return connectionString;

        }

        string connectionString = GetConnectionString();

        //To Register a new user   
        //public string RegisterUser(UserDetails user)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("spRegisterUser", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
        //        cmd.Parameters.AddWithValue("@LastName", user.LastName);
        //        cmd.Parameters.AddWithValue("@UserID", user.UserID);
        //        cmd.Parameters.AddWithValue("@UserPassword", user.Password);

        //        con.Open();
        //        string result = cmd.ExecuteScalar().ToString();
        //        con.Close();

        //        return result;
        //    }
        //}

        //To Validate the login  
        public string ValidateLogin(UserDetails user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spValidateUserLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LoginID", user.UserID);
                cmd.Parameters.AddWithValue("@LoginPassword", user.Password);

                con.Open();
                string result = cmd.ExecuteScalar().ToString();
                con.Close();

                return result;
            }
        }
    }
}
