using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для суммы транзакции. Хранит decimal и проверяет, что значение больше нуля.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct TransactionAmount : ValueObject<decimal>
    {
        public TransactionAmount(decimal value) : base(new TransactionAmountValidator(), value) { }
    }
}
