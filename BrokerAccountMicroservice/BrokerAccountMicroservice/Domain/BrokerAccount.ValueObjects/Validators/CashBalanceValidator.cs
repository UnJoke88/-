using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор для денежного баланса. Проверяет, что значение не отрицательное.
    ///</summary>
    public class CashBalanceValidator : IValidator<decimal>
    {
        ///<summary>
        ///Проверяет, что баланс не отрицательный.
        ///</summary>
        ///<param name="value">Значение баланса.</param>
        ///<exception cref="CashBalanceNegativeException">Если значение меньше 0.</exception>
        public void Validate(decimal value)
        {
            if (value < 0)
                throw new CashBalanceNegativeException(nameof(value), value);
        }
    }
}
