using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators
{
    public class MiddleNameValidator : IValidator<string?>
    {
        public static int MAX_LENGTH => 55;

        public void Validate(string? value)
        {
            if (value is null)
                return;

            if (value.Length > MAX_LENGTH)
                throw new MiddleNameTooLongException(value, MAX_LENGTH);
        }
    }
}
