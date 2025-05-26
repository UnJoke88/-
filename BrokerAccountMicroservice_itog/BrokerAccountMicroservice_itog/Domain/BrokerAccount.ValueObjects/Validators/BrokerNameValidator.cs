using AuctionTrading.Domain.ValueObjects.Exceptions;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators
namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators
{
    public class BrokerNameValidator : IValidator<string>
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 100;

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(ExceptionMessages.BROKER_NAME_NOT_NULL_OR_WHITE_SPACE, nameof(value));

            if (value.Length < MIN_LENGTH)
                throw new BrokerNameTooShortException(value, MIN_LENGTH);

            if (value.Length > MAX_LENGTH)
                throw new BrokerNameTooLongException(value, MAX_LENGTH);
        }
    }
}