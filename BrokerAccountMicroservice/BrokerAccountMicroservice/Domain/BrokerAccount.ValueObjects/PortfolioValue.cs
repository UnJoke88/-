using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для общей стоимости портфеля. Хранит decimal и проверяет, что значение неотрицательное.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct PortfolioValue : ValueObject<decimal>
    {
        public PortfolioValue(decimal value) : base(new PortfolioValueValidator(), value) { }
    }
}
