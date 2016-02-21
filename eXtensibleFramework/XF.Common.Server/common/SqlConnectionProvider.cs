﻿// <copyright company="eXtensoft LLC" file="SqlConnectionProvider.cs">
// Copyright © 2015 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class SqlConnectionProvider 
    {

        public static SqlConnection GetConnection(string key = "")
        {
            string s = GetConnectionString(key);
            return new SqlConnection(s);
        }

        public static string GetConnectionString(string key)
        {
            string s = (!String.IsNullOrEmpty(key)) ? key : "default";
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[s];
            return (settings != null) ? settings.ConnectionString : String.Empty;
        }
    }
}
