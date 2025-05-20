using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Client
{
    ///<summary>
    ///Исключение возникает при некорректном формате номера телефона.
    ///</summary>
    public class PhoneNumberFormatException : InvalidOperationException
    {
        private readonly string _phoneNumber;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="phoneNumber">Некорректный номер телефона.</param>
        public PhoneNumberFormatException(string phoneNumber)
            : base($"Номер телефона '{phoneNumber}' имеет некорректный формат.")
        {
            _phoneNumber = phoneNumber;
        }

        ///<summary>
        ///Возвращает некорректный номер телефона.
        ///</summary>
        public string PhoneNumber => _phoneNumber;
    }
}

