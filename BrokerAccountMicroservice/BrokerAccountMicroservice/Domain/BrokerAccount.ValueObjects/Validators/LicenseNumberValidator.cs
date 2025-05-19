using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators
{
    public class LicenseNumberValidator : IValidator<string>
    {
        // Проверяет, что номер лицензии содержит только буквы/цифры, длина 5-20 символов
        private static readonly Regex _licensePattern = new(@"^[a-zA-Z0-9]{5,20}$", RegexOptions.Compiled);

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainValidationException("Номер лицензии не может быть пустым");

            if (!_licensePattern.IsMatch(value))
                throw new DomainValidationException("Номер лицензии должен содержать только латинские буквы и цифры (5–20 символов)");
        }
    }
}