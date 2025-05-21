using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор для тикера актива. Проверяет, что тикер не пустой, не слишком длинный и содержит только допустимые символы.
    ///</summary>
    public class AssetSymbolValidator : IValidator<string>
    {
        private const int MaxLength = 10;

        ///<summary>
        ///Проверяет значение тикера актива.
        ///</summary>
        ///<param name="value">Значение тикера.</param>
        ///<exception cref="InvalidAssetSymbolException">Если тикер пустой или null.</exception>
        ///<exception cref="AssetSymbolTooLongException">Если длина превышает допустимое значение.</exception>
        ///<exception cref="AssetSymbolInvalidCharactersException">Если содержатся недопустимые символы.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidAssetSymbolException(nameof(value), value);

            if (value.Length > MaxLength)
                throw new AssetSymbolTooLongException(nameof(value), value);

            if (value.Any(c => !char.IsLetterOrDigit(c)))
                throw new AssetSymbolInvalidCharactersException(nameof(value), value);
        }
    }
}