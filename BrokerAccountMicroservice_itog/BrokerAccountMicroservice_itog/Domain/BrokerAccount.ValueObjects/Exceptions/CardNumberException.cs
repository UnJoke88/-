using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при недопустимом формате номера карты.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="cardNumber">Некорректное значение номера карты.</param>
    internal class CardNumberFormatException(string paramName, string cardNumber)
        : FormatException($"Card number имеет недопустимый формат: \"{cardNumber}\".", paramName)
    {
        public string CardNumber => cardNumber;
    }
}
