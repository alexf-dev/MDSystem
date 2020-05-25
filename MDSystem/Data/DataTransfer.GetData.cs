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
        public static IBaseObject GetDataObject(this BaseObject dataObject, GetDataFilter filter)
        {
            if (dataObject is User)
                return GetData((User)dataObject, filter);
            else
                if (dataObject is ScriptMD)
                return GetData((ScriptMD)dataObject, filter);
            else
                if (dataObject is ActionMD)
                return GetData((ActionMD)dataObject, filter);


            return null;
        }

        private static IBaseObject GetData(User dataObject, GetDataFilter filter)
        {
            int affectedRows = 0;
            var customer = new List<User>();
            using (var conn = OpenConnection(ConnectionString))
            {
                if (!string.IsNullOrWhiteSpace(filter.Name))
                    customer = conn.Query<User>("Select * FROM public.t_users WHERE firstname = @PersonFirstName", new { PersonFirstName = filter.Name }).ToList();
                //else
                //    if (filter.AllObjects)
                //        customer = conn.Query<User>("Select * FROM public.t_users").ToList();
            }

            return customer.First();
        }

        private static IBaseObject GetData(ScriptMD dataObject, GetDataFilter filter)
        {
            int affectedRows = 0;
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

        private static IBaseObject GetData(ActionMD dataObject, GetDataFilter filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get data objects from BD
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        public static List<IBaseObject> GetDataObjects(this BaseObject dataObject, GetDataFilter filter)
        {
            if (dataObject is User)
                return GetDataList((User)dataObject, filter);
            else
                if (dataObject is ScriptMD)
                return GetDataList((ScriptMD)dataObject, filter);
            else
                if (dataObject is ActionMD)
                return GetDataList((ActionMD)dataObject, filter);


            return null;
        }

        private static List<IBaseObject> GetDataList(User dataObject, GetDataFilter filter)
        {
            List<IBaseObject> data = new List<IBaseObject>();

            var customer = new List<User>();
            using (var conn = OpenConnection(ConnectionString))
            {
                if (filter.AllObjects)
                {
                    customer = conn.Query<User>("Select * FROM public.t_users").ToList();
                }

                data.AddRange(customer);
            }

            return data;
        }

        private static List<IBaseObject> GetDataList(ScriptMD dataObject, GetDataFilter filter)
        {
            List<IBaseObject> data = new List<IBaseObject>();

            var customer = new List<ScriptMD>();
            using (var conn = OpenConnection(ConnectionString))
            {
                if (filter.AllObjects)
                {
                    customer = conn.Query<ScriptMD>("Select * FROM public.t_scripts").ToList();
                }

                data.AddRange(customer);
            }

            return data;
        }

        private static List<IBaseObject> GetDataList(ActionMD dataObject, GetDataFilter filter)
        {
            List<IBaseObject> data = new List<IBaseObject>();

            var customer = new List<ActionMD>();
            using (var conn = OpenConnection(ConnectionString))
            {
                if (filter.AllObjects)
                {
                    customer = conn.Query<ActionMD>("Select * FROM public.t_actions").ToList();
                }
                else if (filter.ParentId != Guid.Empty)
                {
                    customer = conn.Query<ActionMD>("Select * FROM public.t_actions WHERE parent_id = @ParentId", new { ParentId = filter.ParentId }).ToList();
                }
                else if (filter.ParentIds != null)
                {
                    customer = conn.Query<ActionMD>("Select * FROM public.t_actions WHERE parent_id in (@ParentIds)", new { ParentIds = "'" + string.Join("', '", filter.ParentIds.Select(it => it.ToString())) + "'" }).ToList();
                }

                data.AddRange(customer);
            }

            return data;
        }
    }
}
