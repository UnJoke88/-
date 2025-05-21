using System;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Enums;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    ///<summary>
    ///ValueObject, представляющий валюту.
    ///</summary>
    public class Currency : ValueObject<CurrencyEnum>
    {
        public Currency(CurrencyEnum value) : base(value) { }

        ///<summary>
        ///Создаёт валюту из строки.
        ///</summary>
        ///<param name="value">Строка валюты.</param>
        ///<returns>Объект Currency.</returns>
        ///<exception cref="InvalidCurrencyException">Если значение не входит в enum.</exception>
        public static Currency FromString(string value)
        {
            if (!Enum.TryParse<CurrencyEnum>(value, true, out var parsed))
                throw new InvalidCurrencyException(nameof(value), value);

            return new Currency(parsed);
        }

        public override string ToString() => Value.ToString();
    }
}
