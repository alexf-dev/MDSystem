using Npgsql;
using System;
using System.Data;

namespace MDSystem.Data
{
    /// <summary>
    /// Класс работы с данными
    /// </summary>
    public static partial class DataTransfer
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBStringConnection"].ConnectionString; 

        /// <summary>  
        /// Get the db connection  
        /// </summary>  
        /// <param name="connStr"></param>  
        /// <returns></returns>  
        public static IDbConnection OpenConnection(string connStr)
        {
            var conn = new NpgsqlConnection(connStr);
            conn.Open();
            return conn;
        }
    }
}
