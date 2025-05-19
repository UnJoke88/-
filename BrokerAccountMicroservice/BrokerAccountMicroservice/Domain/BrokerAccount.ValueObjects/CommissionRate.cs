using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для комиссии брокера. Хранит decimal и проверяет, что значение от 0 до 1 (например, 0.05).
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct CommissionRate : ValueObject<decimal>
    {
        public CommissionRate(decimal value) : base(new CommissionRateValidator(), value) { }
    }
}
