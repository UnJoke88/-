using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators
{
    public class PortfolioNumberValidator : IValidator<string>
    {
        public static int LENGTH => 8;

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(ExceptionMessages.PORTFOLIO_NUMBER_NOT_NULL_OR_WHITE_SPACE, nameof(value));

            if (!value.All(char.IsDigit))
                throw new PortfolioNumberFormatException(nameof(value), value);

            if (value.Length != LENGTH)
                throw new PortfolioNumberLengthException(value, LENGTH);
        }
    }
}
