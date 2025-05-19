using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class LastNameValidator : IValidator<string>
    {
        public static int MIN_LENGTH => 1;
        public static int MAX_LENGTH => 50;

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainValidationException("Фамилия не может быть пустой или состоять только из пробелов");

            if (value.Length < MIN_LENGTH)
                throw new DomainValidationException($"Фамилия слишком короткая. Минимум {MIN_LENGTH} символ.");

            if (value.Length > MAX_LENGTH)
                throw new DomainValidationException($"Фамилия слишком длинная. Максимум {MAX_LENGTH} символов.");

            if (value.Any(c => !char.IsLetter(c)))
                throw new DomainValidationException("Фамилия может содержать только буквы");
        }
    }
}