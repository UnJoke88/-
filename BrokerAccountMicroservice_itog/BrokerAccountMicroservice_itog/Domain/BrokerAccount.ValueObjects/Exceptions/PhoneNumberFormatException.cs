using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при недопустимом формате номера телефона.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="phone">Недопустимый номер телефона.</param>
    internal class PhoneNumberFormatException(string paramName, string phone)
        : ArgumentException($"Номер телефона имеет недопустимый формат: \"{phone}\".", paramName)
    {
        public string Phone => phone;
    }
}
