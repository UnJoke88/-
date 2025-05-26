using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    /// Проверка формата номера карты.
    ///</summary>
    internal class CardNumberFormatException(string paramName, string cardNumber)
        : ArgumentException($"Номер карты имеет недопустимый формат: \"{cardNumber}\".", paramName)
    {
        public string CardNumber => cardNumber;
    }
}
