using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор суммы транзакции. Проверяет, что значение больше нуля.
    ///</summary>
    public class TransactionAmountValidator : IValidator<decimal>
    {
        ///<summary>
        ///Проверяет корректность суммы транзакции.
        ///</summary>
        ///<param name="value">Сумма транзакции.</param>
        ///<exception cref="TransactionAmountInvalidException">Если сумма меньше или равна нулю.</exception>
        public void Validate(decimal value)
        {
            if (value <= 0)
                throw new TransactionAmountInvalidException(nameof(value), value);
        }
    }
}