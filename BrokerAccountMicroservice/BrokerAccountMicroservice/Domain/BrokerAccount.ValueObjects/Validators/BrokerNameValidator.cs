using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class BrokerNameValidator : IValidator<string>
    {
        public static int MIN_LENGTH => 2;
        public static int MAX_LENGTH => 100;

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainValidationException("Название брокера не может быть пустым");

            if (value.Length < MIN_LENGTH)
                throw new DomainValidationException($"Слишком короткое название брокера. Минимум {MIN_LENGTH} символа");

            if (value.Length > MAX_LENGTH)
                throw new DomainValidationException($"Слишком длинное название брокера. Максимум {MAX_LENGTH} символов");
        }
    }
}