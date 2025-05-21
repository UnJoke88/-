using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при недопустимом коде валюты.
    ///</summary>
    internal class InvalidCurrencyException(string paramName, string currency)
        : ArgumentException($"Код валюты не поддерживается: \"{currency}\".", paramName)
    {
        public string Currency => currency;
    }
}