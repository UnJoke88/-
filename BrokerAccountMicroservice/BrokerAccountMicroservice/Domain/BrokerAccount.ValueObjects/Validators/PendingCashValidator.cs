using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор замороженных средств. Проверяет, что значение не меньше нуля.
    ///</summary>
    public class PendingCashValidator : IValidator<decimal>
    {
        ///<summary>
        ///Проверяет допустимость значения pending-средств.
        ///</summary>
        ///<param name="value">Сумма замороженных средств.</param>
        ///<exception cref="PendingCashNegativeException">Если значение отрицательное.</exception>
        public void Validate(decimal value)
        {
            if (value < 0)
                throw new PendingCashNegativeException(nameof(value), value);
        }
    }
}
