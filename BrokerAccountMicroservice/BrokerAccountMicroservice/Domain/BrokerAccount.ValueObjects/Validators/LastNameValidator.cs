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
    ///Валидатор фамилии. Проверяет наличие, длину и допустимые символы.
    ///</summary>
    public class LastNameValidator : IValidator<string>
    {
        private const int MinLength = 2;
        private const int MaxLength = 50;
        private static readonly Regex ValidCharacters = new(@"^[a-zA-Zа-яА-ЯёЁ\-]+$");

        ///<summary>
        ///Выполняет валидацию фамилии.
        ///</summary>
        ///<param name="value">Фамилия пользователя.</param>
        ///<exception cref="LastNameEmptyException">Если значение пустое.</exception>
        ///<exception cref="LastNameTooShortException">Если фамилия слишком короткая.</exception>
        ///<exception cref="LastNameTooLongException">Если фамилия слишком длинная.</exception>
        ///<exception cref="LastNameInvalidCharactersException">Если содержит недопустимые символы.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new LastNameEmptyException(nameof(value), value);

            if (value.Length < MinLength)
                throw new LastNameTooShortException(nameof(value), value);

            if (value.Length > MaxLength)
                throw new LastNameTooLongException(nameof(value), value);

            if (!ValidCharacters.IsMatch(value))
                throw new LastNameInvalidCharactersException(nameof(value), value);
        }
    }
}