using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор минимальной единицы актива. Проверяет, что значение положительное.
    ///</summary>
    public class MinimalUnitValidator : IValidator<decimal>
    {
        ///<summary>
        ///Проверяет корректность минимальной единицы.
        ///</summary>
        ///<param name="value">Значение минимальной единицы.</param>
        ///<exception cref="InvalidMinimalUnitException">Если значение не положительное.</exception>
        public void Validate(decimal value)
        {
            if (value <= 0)
                throw new InvalidMinimalUnitException(nameof(value), value);
        }
    }
}