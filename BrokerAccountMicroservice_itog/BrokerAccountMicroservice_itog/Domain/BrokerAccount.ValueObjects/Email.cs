
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
    /// <summary>
    /// Email-адрес клиента.
    /// </summary>
    public class Email(string value)
        : ValueObject<string>(new EmailValidator(), value)
    { 
    
    }
}