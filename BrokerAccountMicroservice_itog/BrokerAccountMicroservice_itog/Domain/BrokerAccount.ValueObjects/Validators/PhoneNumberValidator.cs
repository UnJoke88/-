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
    public class PhoneNumberValidator : IValidator<string>
    {
        public static int REQUIRED_LENGTH => 11;

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(ExceptionMessages.PHONENUMBER_NOT_NULL_OR_WHITE_SPACE, nameof(value));

            if (!value.All(char.IsDigit))
                throw new PhoneNumberFormatException(value);
        }
    }
}
