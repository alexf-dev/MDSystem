using System;

namespace MDSystem.Objects
{
    /// <summary>
    /// Должность
    /// </summary>
    public class Workplace : BaseObject, ISaveObject
    {
        /// <summary>
        /// Идентификатор родительского объекта (подразделение)
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// Наименование 
        /// </summary>
        public string Name { get; set; }        

        public override string ToString()
        {
            return this.Name;
        }
    }
}
