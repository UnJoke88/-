using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    /// Проверка допустимости символов номера телефона.
    ///</summary>
    internal class PhoneNumberFormatException(string phone)
        : ArgumentException($"Номер телефона имеет недопустимый формат: \"{phone}\".", nameof(phone))
    {
        public string Phone => phone;
    }
}
