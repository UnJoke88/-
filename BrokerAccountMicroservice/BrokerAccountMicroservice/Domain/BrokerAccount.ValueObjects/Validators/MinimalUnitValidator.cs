using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class MinimalUnitValidator : IValidator<decimal>
    {
        public void Validate(decimal value)
        {
            if (value <= 0 || value > 1)
                throw new DomainValidationException("Минимальная единица должна быть больше 0 и не больше 1");
        }
    }
}