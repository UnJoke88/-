using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class CurrentPriceValidator : IValidator<decimal>
    {
        public void Validate(decimal value)
        {
            if (value < 0)
                throw new DomainValidationException("Текущая цена не может быть отрицательной");
        }
    }
}
