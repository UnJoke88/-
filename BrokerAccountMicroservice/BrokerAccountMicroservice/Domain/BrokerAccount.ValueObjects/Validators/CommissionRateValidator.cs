using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор для ставки комиссии. Проверяет, что значение от 0 до 1 включительно.
    ///</summary>
    public class CommissionRateValidator : IValidator<decimal>
    {
        ///<summary>
        ///Проверяет допустимость ставки комиссии.
        ///</summary>
        ///<param name="value">Значение комиссии.</param>
        ///<exception cref="CommissionRateOutOfRangeException">Если значение не входит в допустимый диапазон.</exception>
        public void Validate(decimal value)
        {
            if (value < 0 || value > 1)
                throw new CommissionRateOutOfRangeException(nameof(value), value);
        }
    }
}