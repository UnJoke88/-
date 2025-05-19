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
    public class EmailValidator : IValidator<string>
    {
        //Проверяет, что строка выглядит как email: что-то@что-то.что-то 
        private static readonly Regex _emailPattern = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainValidationException("Email не может быть пустым");

            if (!_emailPattern.IsMatch(value))
                throw new DomainValidationException("Неверный формат email-адреса");
        }
    }
}
