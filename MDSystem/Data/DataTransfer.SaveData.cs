using Dapper;
using MDSystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSystem.Data
{
    public static partial class DataTransfer
    {
        /// <summary>
        /// Save object to DB
        /// </summary>
        /// <param name="saveObject"></param>
        /// <returns></returns>
        public static bool Save(this ISaveObject saveObject, CommandAttribute commandAttribute)
        {
            if (saveObject is User)
                return SaveObject((User)saveObject, commandAttribute);

            return false;
        }

        /// <summary>
        /// Save object User
        /// </summary>
        /// <param name="saveObject"></param>
        /// <param name="commandAttribute"></param>
        /// <returns></returns>
        private static bool SaveObject(User saveObject, CommandAttribute commandAttribute)
        {
            int affectedRows = 0;

            using (var conn = OpenConnection(ConnectionString))
            {
                switch (commandAttribute)
                {
                    case CommandAttribute.INSERT:
                        {
                            try
                            {
                                var insertSQL = "INSERT INTO public.t_users (id, firstname, lastname, middlename, workplace_id, department_id, username, password, status, rec_date, del_rec) Values (@Id, @FirstName, @LastName, @MiddleName, @WorkplaceId, @DepartmentId, @UserName, @Password, @Status, now(), @DelRec);";
                                affectedRows = conn.Execute(insertSQL, saveObject);
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show("Ошибка записи в БД: " + Environment.NewLine + exc.Message);
                            }
                        }
                        break;
                    case CommandAttribute.UPDATE:
                        {
                            try
                            {
                                var updateSQL = "UPDATE INTO public.t_users (id, firstname, lastname, middlename, rec_date, del_rec) Values (@Id, @FirstName, @LastName, @MiddleName, now(), @DelRec);";
                                affectedRows = conn.Execute(updateSQL, saveObject);
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show("Ошибка обновления записи в БД: " + Environment.NewLine + exc.Message);
                            }                            
                        }
                        break;
                    case CommandAttribute.DELETE:
                        {
                            try
                            {
                                var deleteSQL = "DELETE FROM public.t_users WHERE id = @Id;";
                                affectedRows = conn.Execute(deleteSQL, saveObject);
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show("Ошибка удаления записи в БД: " + Environment.NewLine + exc.Message);
                            }                            
                        }
                        break;
                    default:
                        break;
                }
            }

            if (affectedRows > 0)
                return true;

            return false;
        }       
    }
}
