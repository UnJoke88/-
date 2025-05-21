using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор для имени брокера. Проверяет пустоту, длину и корректность имени.
    ///</summary>
    public class BrokerNameValidator : IValidator<string>
    {
        private const int MinLength = 3;
        private const int MaxLength = 50;

        ///<summary>
        ///Выполняет проверку имени брокера.
        ///</summary>
        ///<param name="value">Значение имени.</param>
        ///<exception cref="BrokerNameEmptyException">Если имя пустое или null.</exception>
        ///<exception cref="BrokerNameTooShortException">Если имя короче минимального значения.</exception>
        ///<exception cref="BrokerNameTooLongException">Если имя превышает допустимую длину.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BrokerNameEmptyException(nameof(value), value);

            if (value.Length < MinLength)
                throw new BrokerNameTooShortException(nameof(value), value);

            if (value.Length > MaxLength)
                throw new BrokerNameTooLongException(nameof(value), value);
        }
    }
}