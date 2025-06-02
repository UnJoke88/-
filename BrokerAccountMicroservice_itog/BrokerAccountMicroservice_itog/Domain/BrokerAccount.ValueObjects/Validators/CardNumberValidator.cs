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
    public class CardNumberValidator : IValidator<string>
    {
        public static int LENGTH => 16;

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(ExceptionMessages.CARD_NUMBER_NOT_NULL_OR_WHITE_SPACE, nameof(value));

            if (!value.All(char.IsDigit))
                throw new CardNumberFormatException(nameof(value), value);

            if (value.Length != LENGTH)
                throw new CardNumberFormatException(nameof(value), value);
        }
    }
}

