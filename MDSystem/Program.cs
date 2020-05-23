using Dapper;
using MDSystem.Objects;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MDSystem
{
    class Program
    {
        static string _connStr = @"HOST=127.0.0.1;PORT=5432;DATABASE=MD;USER ID=postgres;PASSWORD=123;";

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            //if (args.Contains("-debug"))
            //    ApplicationSettings.IsDeveloper = true;

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            Console.WriteLine("Hello Alex!");

            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Петров",
                LastName = "Петр",
                MiddleName = "Петрович",
                BirthDate = new DateTime(1977, 8, 11, 0, 0, 0)
,
            };

            //1. Insert  
            var insertSQL = "INSERT INTO public.t_person (id, firstname, lastname, middlename, birthdate, rec_date, del_rec) Values (@Id, @FirstName, @LastName, @MiddleName, @BirthDate, now(), @DelRec);";
            using (var conn = OpenConnection(_connStr))
            {
                //var affectedRows = conn.Execute(insertSQL, person);
                //Console.WriteLine(affectedRows > 0 ? "insert successfully!" : "insert failure");
                var customer = conn.Query<Person>("Select * FROM public.t_person WHERE firstname = @PersonFirstName",  new { PersonFirstName = person.FirstName}).ToList();

                //                insertSQL = string.Format(@"
                //INSERT INTO public.t_person(id, firstname, lastname, middlename, birthdate, rec_date, del_rec) 
                //VALUES('{0}', '{1}', '{2}','{3}', '{4}', '{5}', '{6}');", person.Id, person.FirstName, person.LastName, person.MiddleName, person.BirthDate, DateTime.Now, person.DelRec);
                //var res = conn.Execute(insertSQL);
                //Console.WriteLine(res > 0 ? "insert successfully!" : "insert failure");
                //PrintData();
            }

            //            //2.update  
            //            using (var conn = OpenConnection(_connStr))
            //            {
            //                var updateSQL = string.Format(@"
            //UPDATE public.customer 
            //SET email='{0}' 
            //WHERE id={1};", "catcher_hwq@163.com", GetMaxId());
            //                var res = conn.Execute(updateSQL);
            //                Console.WriteLine(res > 0 ? "update successfully!" : "update failure");
            //                PrintData();
            //            }

            //            //3.delete  
            //            using (var conn = OpenConnection(_connStr))
            //            {
            //                var deleteSQL = string.Format(@"
            //DELETE FROM public.customer 
            //WHERE id={0};", GetMaxId());
            //                var res = conn.Execute(deleteSQL);
            //                Console.WriteLine(res > 0 ? "delete successfully!" : "delete failure");
            //                PrintData();
            //            }

            Console.ReadLine();
        }

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

        /// <summary>  
        /// print the data  
        /// </summary>  
        public static void PrintData()
        {
            IList<Person> list;
            //2.query  
            using (var conn = OpenConnection(_connStr))
            {
                var querySQL = @"SELECT id, firstname, lastname, middlename, birthdate, rec_date, del_rec FROM public.t_person;";
                list = conn.Query<Person>(querySQL).ToList();
            }
            if (list.Count > 0)
            {
                foreach (var item in list)
                {//print  
                    Console.WriteLine($"{item.FirstName}'s Birthday is {item.BirthDate}");
                }
            }
            else
            {
                Console.WriteLine("the table is empty!");
            }
        }
    }
}
