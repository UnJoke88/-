using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Client
{
    ///<summary>
    ///Исключение возникает при некорректном формате email.
    ///</summary>
    public class EmailFormatException : InvalidOperationException
    {
        private readonly string _email;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="email">Некорректный email.</param>
        public EmailFormatException(string email)
            : base($"Email '{email}' имеет некорректный формат.")
        {
            _email = email;
        }

        ///<summary>
        ///Возвращает некорректный email.
        ///</summary>
        public string Email => _email;
    }
}
