// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 5:18 PM 2018/7/10
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public abstract class LoadQuestions
    {
        public const string CONNECTION_STRING = @"Data Source=DESKTOP-R7EB7OG\SQLEXPRESS;Initial Catalog=abi_db;Integrated Security=True";
        public const string CONNECTION_STRING_C = @"Data Source=DESKTOP-O33GLSQ\SQLEXPRESS;Initial Catalog=abi_db;Integrated Security=True";        
        SqlConnection conn;

        public SqlConnection Initialize()
        {
            conn = new SqlConnection();
            conn.ConnectionString =
                CONNECTION_STRING;
                //GetConnectionString();
            conn.Open();
            return conn;
        }

        public static string GetConnectionString()
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
                return settings[0].ConnectionString;
            return null;
        }

        public void Close()
        {
            conn.Close();
        }
    }
}
