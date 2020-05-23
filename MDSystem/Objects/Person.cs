using System;

namespace MDSystem.Objects
{
    /// <summary>
    /// Персона
    /// </summary>
    public class Person : BaseObject
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get { return string.Format("{0} {1} {2}", FirstName, LastName, MiddleName); } }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
