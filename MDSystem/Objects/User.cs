using System;

namespace MDSystem.Objects
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : BaseObject
    {
        /// <summary>
        /// Персона 
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// ФИО персоны
        /// </summary>
        public string FullName { get { return Person.FullName; } }

        /// <summary>
        /// Должность 
        /// </summary>
        public Workplace Workplace { get; set; }

        /// <summary>
        /// Подразделение 
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Статус пользователя
        /// </summary>
        public UserStatus Status { get; set; }
    }
}
