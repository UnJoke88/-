using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators
{
    public class QuantityValidator : IValidator<int>
    {
        public void Validate(int value)
        {
            if (value < 0)
                throw new QuantityNotPositiveException(value);
        }
    }
}




