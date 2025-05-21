using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при недопустимом формате номера лицензии.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="number">Неверный формат лицензии.</param>
    internal class LicenseNumberInvalidFormatException(string paramName, string number)
        : ArgumentException($"Номер лицензии имеет недопустимый формат: \"{number}\".", paramName)
    {
        public string Number => number;
    }
}
