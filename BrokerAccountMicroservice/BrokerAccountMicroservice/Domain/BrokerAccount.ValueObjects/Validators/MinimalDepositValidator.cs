using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор минимального депозита. Проверяет, что значение не отрицательное.
    ///</summary>
    public class MinimalDepositValidator : IValidator<decimal>
    {
        ///<summary>
        ///Проверяет минимально допустимую сумму депозита.
        ///</summary>
        ///<param name="value">Сумма депозита.</param>
        ///<exception cref="MinimalDepositNegativeException">Если значение меньше нуля.</exception>
        public void Validate(decimal value)
        {
            if (value < 0)
                throw new MinimalDepositNegativeException(nameof(value), value);
        }
    }
}