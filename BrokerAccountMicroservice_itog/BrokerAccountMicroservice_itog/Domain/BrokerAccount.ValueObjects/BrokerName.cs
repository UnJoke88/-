using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для названия брокерской компании. Хранит строку и проверяет длину.
namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects
{
    /// <summary>
    /// Название брокерской компании.
    /// </summary>
    public class BrokerName(string value)
        : ValueObject<string>(new BrokerNameValidator(), value)
    { 
    
    }
}