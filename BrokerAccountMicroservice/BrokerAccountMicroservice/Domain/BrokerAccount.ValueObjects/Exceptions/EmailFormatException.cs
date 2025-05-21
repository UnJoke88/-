using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при недопустимом формате email.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="email">Некорректное значение email.</param>
    internal class EmailFormatException(string paramName, string email)
        : ArgumentException($"Email имеет недопустимый формат: \"{email}\".", paramName)
    {
        public string Email => email;
    }
}
