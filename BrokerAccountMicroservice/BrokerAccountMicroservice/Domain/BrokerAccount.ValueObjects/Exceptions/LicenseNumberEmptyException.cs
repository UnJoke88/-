using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при отсутствии номера лицензии.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="number">Пустое значение лицензии.</param>
    internal class LicenseNumberEmptyException(string paramName, string number)
        : ArgumentException($"Номер лицензии не может быть пустым: \"{number}\".", paramName)
    {
        public string Number => number;
    }
}
