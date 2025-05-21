using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор комиссии за транзакцию. Проверяет, что значение не меньше нуля.
    ///</summary>
    public class TransactionFeeValidator : IValidator<decimal>
    {
        ///<summary>
        ///Проверяет корректность комиссии.
        ///</summary>
        ///<param name="value">Сумма комиссии.</param>
        ///<exception cref="TransactionFeeNegativeException">Если комиссия меньше нуля.</exception>
        public void Validate(decimal value)
        {
            if (value < 0)
                throw new TransactionFeeNegativeException(nameof(value), value);
        }
    }
}
