using Dapper;
using MDSystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Data
{
    public static partial class DataTransfer
    {
        /// <summary>
        /// Get data object from BD
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        public static IBaseObject GetDataObject<T>(GetDataFilter filter)
        {
            if (typeof(T).Equals(typeof(User)))
                return GetData((GetDataFilterUser)filter);
            else 
                if (typeof(T).Equals(typeof(Department)))
                    return GetData((GetDataFilterDepartment)filter);
            else
                if (typeof(T).Equals(typeof(ScriptMD)))
                    return GetData((GetDataFilterScriptMD)filter);
            else
                if (typeof(T).Equals(typeof(ActionMD)))
                    return GetData((GetDataFilterActionMD)filter);

            return null;
        }

        private static IBaseObject GetData(GetDataFilterDepartment filter)
        {
            throw new NotImplementedException();
        }

        private static IBaseObject GetData(GetDataFilterUser filter)
        {
            var customer = new List<User>();
            using (var conn = OpenConnection(ConnectionString))
            {
                string query = @"SELECT id as Id, firstname as FirstName, lastname as LastName, middlename as MiddleName, workplace_id as WorkplaceId, department_id as DepartmentId, username as UserName, password as Password, status as Status, access_level_value as AccessLevelValue, rec_date as RecDate, del_rec as @DelRec  FROM public.t_users WHERE true ";
                string queryFilter = "";
                if (!string.IsNullOrWhiteSpace(filter.FirstName))
                    queryFilter += " AND firstname = @FirstName ";
                if (!string.IsNullOrWhiteSpace(filter.LastName))
                    queryFilter += " AND lastname = @LastName ";
                if (!string.IsNullOrWhiteSpace(filter.MiddleName))
                    queryFilter += " AND middlename = @MiddleName ";

                query += queryFilter;

                customer = conn.Query<User>(query, new { FirstName = filter.FirstName, LastName = filter.LastName, MiddleName = filter.MiddleName }).ToList();
            }

            return customer.First();
        }

        private static IBaseObject GetData(GetDataFilterScriptMD filter)
        {
            var customer = new List<ScriptMD>();
            using (var conn = OpenConnection(ConnectionString))
            {
                if (!string.IsNullOrWhiteSpace(filter.Name))
                    customer = conn.Query<ScriptMD>("Select * FROM public.t_scripts WHERE name = @Name", new { Name = filter.Name }).ToList();
                //else
                //    if (filter.AllObjects)
                //        customer = conn.Query<User>("Select * FROM public.t_users").ToList();
            }

            return customer.First();
        }

        private static IBaseObject GetData(GetDataFilterActionMD filter)
        {
            var customer = new List<ActionMD>();
            using (var conn = OpenConnection(ConnectionString))
            {
                if (!string.IsNullOrWhiteSpace(filter.Name))                
                    customer = conn.Query<ActionMD>("Select id as Id, parent_id as ParentId, name as Name, order_value as OrderValue, action_type as ActionType, time_execution as TimeExecution, description as Description, rec_date as RecDate, del_rec as DelRec FROM public.t_scripts WHERE name = @Name", new { Name = filter.Name }).ToList();                
            }

            return customer.First();
        }

        /// <summary>
        /// Get data objects from BD
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        public static List<IBaseObject> GetDataObjects<T>(GetDataFilter filter)
        {
            if (typeof(T).Equals(typeof(User)))
                return GetDataList((GetDataFilterUser)filter);
            else 
                if (typeof(T).Equals(typeof(Department)))
                    return GetDataList((GetDataFilterDepartment)filter);
            else
                if (typeof(T).Equals(typeof(Workplace)))
                    return GetDataList((GetDataFilterWorkplace)filter);
            else
                if (typeof(T).Equals(typeof(ScriptMD)))
                    return GetDataList((GetDataFilterScriptMD)filter);
            else
                if (typeof(T).Equals(typeof(ActionMD)))
                    return GetDataList((GetDataFilterActionMD)filter);

            return null;
        }

        /// <summary>
        /// Get List<Department> from DB
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private static List<IBaseObject> GetDataList(GetDataFilterDepartment filter)
        {
            var customer = new List<Department>();
            using (var conn = OpenConnection(ConnectionString))
            {
                if (filter.AllObjects)
                {
                    customer = conn.Query<Department>("Select * FROM public.t_departments").ToList();
                }
            }

            return customer.Cast<IBaseObject>().ToList();
        }

        /// <summary>
        /// Get List<Workplace> from DB
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private static List<IBaseObject> GetDataList(GetDataFilterWorkplace filter)
        {
            var customer = new List<Workplace>();
            using (var conn = OpenConnection(ConnectionString))
            {
                if (filter.AllObjects)
                {
                    customer = conn.Query<Workplace>("Select * FROM public.t_workplaces").ToList();
                }
                else if (filter.ParentId != Guid.Empty)
                {
                    customer = conn.Query<Workplace>("Select * FROM public.t_workplaces WHERE parent_id = @ParentId", new { ParentId = filter.ParentId }).ToList();
                }
            }

            return customer.Cast<IBaseObject>().ToList();
        }

        /// <summary>
        /// Get List<User> from DB
        /// </summary>
        /// <param name="dataObject"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private static List<IBaseObject> GetDataList(GetDataFilterUser filter)
        {
            var customer = new List<User>();
            using (var conn = OpenConnection(ConnectionString))
            {
                if (filter.AllObjects)
                {
                    customer = conn.Query<User>("SELECT id as Id, firstname as FirstName, lastname as LastName, middlename as MiddleName, workplace_id as WorkplaceId, department_id as DepartmentId, username as UserName, password as Password, status as Status, access_level_value as AccessLevelValue, rec_date as RecDate, del_rec as @DelRec FROM public.t_users").ToList();                  
                }
            }

            return customer.Cast<IBaseObject>().ToList();
        }

        /// <summary>
        /// Get List<ScriptMD> from DB
        /// </summary>
        /// <param name="dataObject"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private static List<IBaseObject> GetDataList(GetDataFilterScriptMD filter)
        {
            var customer = new List<ScriptMD>();
            using (var conn = OpenConnection(ConnectionString))
            {
                if (filter.AllObjects)
                {
                    customer = conn.Query<ScriptMD>("Select * FROM public.t_scripts").ToList();
                }
            }

            return customer.Cast<IBaseObject>().ToList();
        }

        /// <summary>
        /// Get List<ActionMD> from DB
        /// </summary>
        /// <param name="dataObject"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private static List<IBaseObject> GetDataList(GetDataFilterActionMD filter)
        {
            var customer = new List<ActionMD>();
            using (var conn = OpenConnection(ConnectionString))
            {
                if (filter.AllObjects)
                {
                    customer = conn.Query<ActionMD>("Select id as Id, parent_id as ParentId, name as Name, order_value as OrderValue, action_type as ActionType, time_execution as TimeExecution, description as Description, rec_date as RecDate, del_rec as DelRec FROM public.t_actions").ToList();
                }
                else if (filter.ParentId != Guid.Empty)
                {
                    customer = conn.Query<ActionMD>("Select id as Id, parent_id as ParentId, name as Name, order_value as OrderValue, action_type as ActionType, time_execution as TimeExecution, description as Description, rec_date as RecDate, del_rec as DelRec FROM public.t_actions WHERE parent_id = @ParentId", new { ParentId = filter.ParentId }).ToList();
                }
                else if (filter.ParentIds != null)
                {
                    customer = conn.Query<ActionMD>("Select id as Id, parent_id as ParentId, name as Name, order_value as OrderValue, action_type as ActionType, time_execution as TimeExecution, description as Description, rec_date as RecDate, del_rec as DelRec FROM public.t_actions WHERE parent_id in (@ParentIds)", new { ParentIds = "'" + string.Join("', '", filter.ParentIds.Select(it => it.ToString())) + "'" }).ToList();
                }
            }

            return customer.Cast<IBaseObject>().ToList();
        }
    }
}
