using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при недопустимом или неподдерживаемом коде валюты.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="currency">Неподдерживаемое значение валюты.</param>
    internal class UnsupportedCurrencyException(string paramName, string currency)
        : ArgumentException($"Код валюты не поддерживается: \"{currency}\".", paramName)
    {
        public string Currency => currency;
    }
}
