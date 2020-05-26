using System;

namespace MDSystem.Objects
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : BaseObject, ISaveObject
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
        /// Должность 
        /// </summary>
        public Workplace Workplace { get; set; }

        /// <summary>
        /// Подразделение 
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Статус пользователя
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// Уровень доступа
        /// </summary>
        public AccessLevel AccessLevel { get; set; }

        /// <summary>
        /// Дата изменения записи в БД
        /// </summary>
        public DateTime RecDate { get; set; }

        public Guid WorkplaceId { get { return Workplace.Id; } }

        public Guid DepartmentId { get { return Department.Id; } }

        public int AccessLevelValue { get; set; }
    }
}
