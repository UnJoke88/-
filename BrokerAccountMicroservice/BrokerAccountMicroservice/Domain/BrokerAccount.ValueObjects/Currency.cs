using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для валюты. Хранит строку и проверяет, что это поддерживаемый ISO-код.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct Currency : ValueObject<string>
    {
        public Currency(string value) : base(new CurrencyValidator(), value) { }
    }
}
