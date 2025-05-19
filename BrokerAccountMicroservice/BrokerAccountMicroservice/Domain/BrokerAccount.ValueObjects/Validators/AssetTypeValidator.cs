using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class AssetTypeValidator : IValidator<string>
    {
        private static readonly HashSet<string> AllowedTypes = new(StringComparer.OrdinalIgnoreCase)
        {
            "Stock",
            "Bond",
            "ETF"
        };

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainValidationException("Тип актива не может быть пустым");

            if (!AllowedTypes.Contains(value))
                throw new DomainValidationException($"Недопустимый тип актива: '{value}'. Допустимые значения: {string.Join(", ", AllowedTypes)}");
        }
    }
}
