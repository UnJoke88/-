using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор цены покупки. Проверяет, что значение не отрицательное.
    ///</summary>
    public class PurchasePriceValidator : IValidator<decimal>
    {
        ///<summary>
        ///Проверяет допустимость цены покупки актива.
        ///</summary>
        ///<param name="value">Цена покупки.</param>
        ///<exception cref="PurchasePriceNegativeException">Если цена меньше нуля.</exception>
        public void Validate(decimal value)
        {
            if (value < 0)
                throw new PurchasePriceNegativeException(nameof(value), value);
        }
    }
}
