using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects
{    
    /// <summary>
    /// Статус пользователя
    /// </summary>
    public enum UserStatus
    {
        [LocalizedName("Не использовал систему")]
        не_использовал_систему = 5,
        [LocalizedName("Протестирован")]
        протестирован = 10,
        [LocalizedName("В процессе обучения")]
        в_процессе_обучения = 15,
        [LocalizedName("Допущен к полету")]
        допущен_к_полету = 20,
        [LocalizedName("Сотрудник")]
        сотрудник = 30            
    }    
}
