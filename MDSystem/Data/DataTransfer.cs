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
        public static string ConnectionString = @"HOST=127.0.0.1;PORT=5432;DATABASE=MD;USER ID=postgres;PASSWORD=123;";

        /// <summary>  
        /// get the db connection  
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
