using System;

namespace MDSystem.Objects
{
    /// <summary>
    /// Должность
    /// </summary>
    public class Workplace : BaseObject
    {
        /// <summary>
        /// Идентификатор родительского объекта (подразделение)
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// Наименование 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Уровень доступа
        /// </summary>
        public AccessLevel AccessLevel { get; set; }
    }
}
