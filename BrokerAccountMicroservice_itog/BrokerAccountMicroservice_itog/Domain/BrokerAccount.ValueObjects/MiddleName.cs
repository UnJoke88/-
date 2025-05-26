using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для отчества клиента. Хранит строку и проверяет её при наличии.
namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects
{
    /// <summary>
    /// Представляет отчество клиента (может отсутствовать).
    /// </summary>
    public class MiddleName(string? value)
        : ValueObject<string?>(new MiddleNameValidator(), value)
    {
    
    }
}