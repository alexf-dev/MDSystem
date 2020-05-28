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
            else 
                if (saveObject is ScriptMD)
                    return SaveObject((ScriptMD)saveObject, commandAttribute);
            else
                if (saveObject is ActionMD)
                    return SaveObject((ActionMD)saveObject, commandAttribute);
            else
                if (saveObject is Department)
                    return SaveObject((Department)saveObject, commandAttribute);
            else
                if (saveObject is Workplace)
                    return SaveObject((Workplace)saveObject, commandAttribute);
            else
                if (saveObject is Report)
                    return SaveObject((Report)saveObject, commandAttribute);

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
                                var insertSQL = "INSERT INTO public.t_users (id, firstname, lastname, middlename, workplace_id, department_id, username, password, status, access_level_value, rec_date, del_rec) Values (@Id, @FirstName, @LastName, @MiddleName, @WorkplaceId, @DepartmentId, @UserName, @Password, @Status, @AccessLevelValue, now(), @DelRec);";
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
                                var updateSQL = "UPDATE public.t_users SET workplace_id = @WorkplaceId, department_id = @DepartmentId, username = @UserName, password = @Password, status = @Status, access_level_value = @AccessLevelValue, rec_date, del_rec = @DelRec WHERE id = @Id ;";
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

        /// <summary>
        /// Save object ScriptMD
        /// </summary>
        /// <param name="saveObject"></param>
        /// <param name="commandAttribute"></param>
        /// <returns></returns>
        private static bool SaveObject(ScriptMD saveObject, CommandAttribute commandAttribute)
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
                                var insertSQL = "INSERT INTO public.t_scripts (id, name, code, actions_order_list, script_type, description, reg_date, rec_date, del_rec) Values (@Id, @Name, @Code, @ActionsOrderList, @ScriptType, @Description, @RegDate, now(), @DelRec);";
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

        /// <summary>
        /// Save object ActionMD
        /// </summary>
        /// <param name="saveObject"></param>
        /// <param name="commandAttribute"></param>
        /// <returns></returns>
        private static bool SaveObject(ActionMD saveObject, CommandAttribute commandAttribute)
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
                                var insertSQL = "INSERT INTO public.t_actions (id, parent_id, name, order_value, action_type, time_execution, description, rec_date, del_rec) Values (@Id, @ParentId, @Name, @OrderValue, @ActionType, @TimeExecution, @Description, now(), @DelRec);";
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

        /// <summary>
        /// Save object Department
        /// </summary>
        /// <param name="saveObject"></param>
        /// <param name="commandAttribute"></param>
        /// <returns></returns>
        private static bool SaveObject(Department saveObject, CommandAttribute commandAttribute)
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
                                var insertSQL = "INSERT INTO public.t_departments (id, parent_id, name, rec_date, del_rec) Values (@Id, @ParentId, @Name, now(), @DelRec);";
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

        /// <summary>
        /// Save object Workplace
        /// </summary>
        /// <param name="saveObject"></param>
        /// <param name="commandAttribute"></param>
        /// <returns></returns>
        private static bool SaveObject(Workplace saveObject, CommandAttribute commandAttribute)
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
                                var insertSQL = "INSERT INTO public.t_workplaces (id, parent_id, name, rec_date, del_rec) Values (@Id, @ParentId, @Name, now(), @DelRec);";
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

        /// <summary>
        /// Save object Report
        /// </summary>
        /// <param name="saveObject"></param>
        /// <param name="commandAttribute"></param>
        /// <returns></returns>
        private static bool SaveObject(Report saveObject, CommandAttribute commandAttribute)
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
                                var insertSQL = "INSERT INTO public.t_reports (id, script_id, script_name, user_id, operator_name, actions_amount, time_execution_amount, actions_order_list, description, start_date, rec_date, del_rec) Values (@Id, @ScriptId, @ScriptName, @UserID, @OperatorFullName, @ActionsAmount, @TimeExecutionAmount, @ActionsOrderList, @Description, @StartDate, now(), @DelRec);";
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
                                var updateSQL = "UPDATE INTO public.t_reports (id, firstname, lastname, middlename, rec_date, del_rec) Values (@Id, @FirstName, @LastName, @MiddleName, now(), @DelRec);";
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
