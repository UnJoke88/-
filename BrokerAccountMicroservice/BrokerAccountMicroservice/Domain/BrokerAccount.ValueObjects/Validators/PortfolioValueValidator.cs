using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор стоимости портфеля. Проверяет, что значение не отрицательное.
    ///</summary>
    public class PortfolioValueValidator : IValidator<decimal>
    {
        ///<summary>
        ///Проверяет допустимость общей стоимости портфеля.
        ///</summary>
        ///<param name="value">Сумма стоимости.</param>
        ///<exception cref="PortfolioValueNegativeException">Если значение меньше нуля.</exception>
        public void Validate(decimal value)
        {
            if (value < 0)
                throw new PortfolioValueNegativeException(nameof(value), value);
        }
    }
}