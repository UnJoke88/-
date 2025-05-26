using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    internal class FirstNameLongValueException(string firstName, int maxLength)
        : FormatException($"First name length {firstName} greated than maximum allowed(допустимая длина) length {maxLength}") // FormatException. Исключение, которое возникает в случае, если формат аргумента недопустим или строка составного формата построена неправильно.  Наследование Object ==> Exception ==> SystemException ==> FormatException
    {
        public string FirstName => firstName;
        public int MaxLength => maxLength;
    }
}
