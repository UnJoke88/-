using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    /// Проверка формата email-адреса.
    ///</summary>
    internal class EmailFormatException(string paramName, string email)
        : ArgumentException($"Email имеет недопустимый формат: \"{email}\".", paramName)
    {
        public string Email => email;
    }
}
