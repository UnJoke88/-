using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для минимальной единицы покупки. Хранит decimal и проверяет, что значение > 0 и <= 1.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct MinimalUnit : ValueObject<decimal>
    {
        public MinimalUnit(decimal value) : base(new MinimalUnitValidator(), value) { }
    }
}
