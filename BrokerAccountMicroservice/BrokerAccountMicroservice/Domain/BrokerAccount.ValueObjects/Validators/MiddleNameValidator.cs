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
    ///Валидатор отчества. Проверяет длину и допустимые символы, если значение указано.
    ///</summary>
    public class MiddleNameValidator : IValidator<string?>
    {
        private const int MaxLength = 50;
        private static readonly Regex ValidCharacters = new(@"^[a-zA-Zа-яА-ЯёЁ\-]+$");

        ///<summary>
        ///Проверяет корректность отчества.
        ///</summary>
        ///<param name="value">Отчество пользователя (может быть null).</param>
        ///<exception cref="MiddleNameTooLongException">Если значение превышает длину.</exception>
        ///<exception cref="MiddleNameInvalidCharactersException">Если содержит недопустимые символы.</exception>
        public void Validate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            if (value.Length > MaxLength)
                throw new MiddleNameTooLongException(nameof(value), value);

            if (!ValidCharacters.IsMatch(value))
                throw new MiddleNameInvalidCharactersException(nameof(value), value);
        }
    }
}
