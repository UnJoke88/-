using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор для текущей рыночной цены актива.
    ///Проверяет, что цена не является отрицательной.
    ///</summary>
    public class CurrentPriceValidator : IValidator<decimal>
    {
        ///<summary>
        ///Выполняет проверку текущей цены.
        ///</summary>
        ///<param name="value">Значение текущей цены.</param>
        ///<exception cref="CurrentPriceNegativeException">Если цена меньше 0.</exception>
        public void Validate(decimal value)
        {
            if (value < 0)
                throw new CurrentPriceNegativeException(nameof(value), value);
        }
    }
}
