using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects.Models
{
    public class UserModel
    {
        public UserModel(
            Guid id,
            string firstName,
            string lastName,
            string middleName,
            string userName,
            int accessLevelValue
            )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            UserName = userName;
            AccessLevelValue = accessLevelValue;
        }

        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Guid Id { get; set; }

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
        /// Логин пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Уровень доступа
        /// </summary>
        public int AccessLevelValue { get; set; }

        /// <summary>
        /// Уровень доступа (наименование)
        /// </summary>
        public string AccessLevelName => AccessLevel.Name;

        /// <summary>
        /// Уровень доступа
        /// </summary>
        public AccessLevel AccessLevel { get; set; }


        public ICollection<ScriptModel> OperatorScripts { get; set; } = new List<ScriptModel>();        

        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get { return string.Format("{0} {1} {2}", FirstName, LastName, MiddleName); } }

        public override string ToString()
        {
            return FullName;
        }
    }
}
