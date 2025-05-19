using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для доступного денежного баланса. Хранит decimal и проверяет, что значение неотрицательное.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct CashBalance : ValueObject<decimal>
    {
        public CashBalance(decimal value) : base(new CashBalanceValidator(), value) { }
    }
}