using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для номера телефона клиента. Хранит строку и проверяет формат.
namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects
{
    public class PhoneNumber : ValueObject<string>
    {
        public PhoneNumber(string value) : base(new PhoneNumberValidator(), value) { }
    }
}
