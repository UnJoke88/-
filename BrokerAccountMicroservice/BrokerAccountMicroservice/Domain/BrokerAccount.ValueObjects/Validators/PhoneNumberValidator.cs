using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор номера телефона. Проверяет формат и допустимые символы.
    ///</summary>
    public class PhoneNumberValidator : IValidator<string>
    {
        private static readonly Regex Pattern = new(@"^\+?[0-9]{10,15}$");

        ///<summary>
        ///Выполняет валидацию номера телефона.
        ///</summary>
        ///<param name="value">Номер телефона.</param>
        ///<exception cref="PhoneNumberFormatException">Если номер не соответствует формату.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !Pattern.IsMatch(value))
                throw new PhoneNumberFormatException(nameof(value), value);
        }
    }
}
