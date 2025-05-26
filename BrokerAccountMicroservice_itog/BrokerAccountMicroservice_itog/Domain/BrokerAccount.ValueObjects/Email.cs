
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для email-адреса клиента. Хранит строку и проверяет формат.
namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects
{
    public class Email : ValueObject<string>
    {
        public Email(string value) : base(new EmailValidator(), value) { }
    }
}