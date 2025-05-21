using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор номера лицензии. Проверяет, что значение не пустое и соответствует формату.
    ///</summary>
    public class LicenseNumberValidator : IValidator<string>
    {
        private static readonly Regex Format = new(@"^[A-Z0-9\-]{6,20}$");

        ///<summary>
        ///Проверяет номер лицензии.
        ///</summary>
        ///<param name="value">Значение лицензии.</param>
        ///<exception cref="LicenseNumberEmptyException">Если значение пустое.</exception>
        ///<exception cref="LicenseNumberInvalidFormatException">Если не соответствует допустимому шаблону.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new LicenseNumberEmptyException(nameof(value), value);

            if (!Format.IsMatch(value))
                throw new LicenseNumberInvalidFormatException(nameof(value), value);
        }
    }
}