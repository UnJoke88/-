using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор номера карты. Проверяет длину и цифровой формат.
    ///</summary>
    public class CardNumberValidator : IValidator<string>
    {
        ///<summary>
        ///Проверяет корректность номера карты.
        ///</summary>
        ///<param name="value">Значение номера карты.</param>
        ///<exception cref="CardNumberFormatException">Если номер карты недопустимого формата.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new CardNumberFormatException(nameof(value), value);

            if (value.Length != 16 || !value.All(char.IsDigit))
                throw new CardNumberFormatException(nameof(value), value);
        }
    }
}

