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
    ///Валидатор имени. Проверяет наличие, длину и символы имени.
    ///</summary>
    public class FirstNameValidator : IValidator<string>
    {
        private const int MinLength = 2;
        private const int MaxLength = 50;
        private static readonly Regex ValidCharacters = new(@"^[a-zA-Zа-яА-ЯёЁ\-]+$");

        ///<summary>
        ///Выполняет валидацию имени.
        ///</summary>
        ///<param name="value">Имя пользователя.</param>
        ///<exception cref="FirstNameEmptyException">Если имя пустое.</exception>
        ///<exception cref="FirstNameTooShortException">Если имя слишком короткое.</exception>
        ///<exception cref="FirstNameTooLongException">Если имя слишком длинное.</exception>
        ///<exception cref="FirstNameInvalidCharactersException">Если имя содержит недопустимые символы.</exception>
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new FirstNameEmptyException(nameof(value), value);

            if (value.Length < MinLength)
                throw new FirstNameTooShortException(nameof(value), value);

            if (value.Length > MaxLength)
                throw new FirstNameTooLongException(nameof(value), value);

            if (!ValidCharacters.IsMatch(value))
                throw new FirstNameInvalidCharactersException(nameof(value), value);
        }
    }
}