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
            //if (dataObject is User)
            //    return GetData((User)dataObject, filter);
            //else
            //    if (dataObject is ScriptMD)
            //    return GetData((ScriptMD)dataObject, filter);
            //else
            //    if (dataObject is ActionMD)
            //    return GetData((ActionMD)dataObject, filter);


            return null;
        }

        /// <summary>
        /// Get data objects from BD
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        public static List<IBaseObject> GetDataObjects(this BaseObject dataObject, GetDataFilter filter)
        {
            //if (dataObject is User)
            //    return GetDataList((User)dataObject, filter);
            //else
            //    if (dataObject is ScriptMD)
            //    return GetDataList((ScriptMD)dataObject, filter);
            //else
            //    if (dataObject is ActionMD)
            //    return GetDataList((ActionMD)dataObject, filter);


            return null;
        }
    }
}
