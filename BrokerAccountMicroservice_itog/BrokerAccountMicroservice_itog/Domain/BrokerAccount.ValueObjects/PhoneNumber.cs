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
    /// <summary>
    /// Номер телефона клиента.
    /// </summary>
    public class PhoneNumber(string value)
        : ValueObject<string>(new PhoneNumberValidator(), value)
    {
    
    }
}
