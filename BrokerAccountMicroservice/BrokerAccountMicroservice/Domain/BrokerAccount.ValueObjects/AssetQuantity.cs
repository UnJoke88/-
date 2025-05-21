using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class AssetQuantityValidator : IValidator<int>
    {
        public void Validate(int value)
        {
            if (value <= 0)
                throw new AssetQuantityOutOfRangeException(nameof(value), value);
        }
    }
}
