using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class MiddleNameValidator : IValidator<string?>
    {
        public static int MAX_LENGTH => 50;

        public void Validate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return; // Отчество может быть пустым

            if (value.Length > MAX_LENGTH)
                throw new DomainValidationException($"Отчество слишком длинное. Максимум {MAX_LENGTH} символов.");

            if (value.Any(c => !char.IsLetter(c)))
                throw new DomainValidationException("Отчество может содержать только буквы");
        }
    }
}
