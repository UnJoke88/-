using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class PhoneNumberValidator : IValidator<string>
    {
        //Проверяет, что номер телефона состоит из + и 10–15 цифр (например, +79001234567)
        private static readonly Regex _phonePattern = new(@"^\+[0-9]{10,15}$", RegexOptions.Compiled);

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainValidationException("Номер телефона не может быть пустым");

            if (!_phonePattern.IsMatch(value))
                throw new DomainValidationException("Неверный формат номера телефона. Пример: +79001234567");
        }
    }
}

