using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при отсутствии валюты.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="currency">Пустое значение валюты.</param>
    internal class CurrencyEmptyException(string paramName, string currency)
        : ArgumentException($"Код валюты не может быть пустым: \"{currency}\".", paramName)
    {
        public string Currency => currency;
    }
}
