using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для текущей цены актива. Хранит decimal и проверяет, что значение неотрицательное.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct CurrentPrice : ValueObject<decimal>
    {
        public CurrentPrice(decimal value) : base(new CurrentPriceValidator(), value) { }
    }
}
