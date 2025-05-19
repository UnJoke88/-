using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class AssetSymbolValidator : IValidator<string>
    {
        public static int MAX_LENGTH => 10;

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainValidationException("Тикер не может быть пустым");

            if (value.Length > MAX_LENGTH)
                throw new DomainValidationException($"Тикер слишком длинный. Максимум {MAX_LENGTH} символов.");

            if (value.Any(c => !char.IsLetterOrDigit(c)))
                throw new DomainValidationException("Тикер может содержать только латинские буквы и цифры");
        }
    }
}