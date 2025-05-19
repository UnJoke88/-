using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class CurrencyValidator : IValidator<string>
    {
        private static readonly HashSet<string> SupportedCurrencies = new(StringComparer.OrdinalIgnoreCase)
        {
            "USD", "EUR", "RUB", "GBP", "JPY", "CNY"
        };

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainValidationException("Валюта не может быть пустой");

            if (!SupportedCurrencies.Contains(value))
                throw new DomainValidationException($"Неподдерживаемая валюта: '{value}'. Поддерживаются: {string.Join(", ", SupportedCurrencies)}");
        }
    }
}