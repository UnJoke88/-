using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для комиссии по транзакции. Хранит decimal и проверяет, что значение неотрицательное.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct TransactionFee : ValueObject<decimal>
    {
        public TransactionFee(decimal value) : base(new TransactionFeeValidator(), value) { }
    }
}
