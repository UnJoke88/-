using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор для количества актива. Проверяет, что значение больше нуля.
    ///</summary>
    public class AssetQuantityValidator : IValidator<int>
    {
        ///<summary>
        ///Проверяет, что количество больше 0.
        ///</summary>
        ///<param name="value">Значение количества.</param>
        ///<exception cref="AssetQuantityOutOfRangeException">Выбрасывается, если значение меньше или равно нулю.</exception>
        public void Validate(int value)
        {
            if (value <= 0)
                throw new AssetQuantityOutOfRangeException(nameof(value), value);
        }
    }
}
