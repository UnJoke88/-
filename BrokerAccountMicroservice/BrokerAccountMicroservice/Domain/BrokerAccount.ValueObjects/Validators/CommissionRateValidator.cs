using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class CommissionRateValidator : IValidator<decimal>
    {
        public void Validate(decimal value)
        {
            if (value < 0 || value > 1)
                throw new DomainValidationException("Комиссия должна быть от 0 до 1 (например, 0.05 = 5%)");
        }
    }
}