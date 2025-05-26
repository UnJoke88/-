using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    internal class FirstNameShortValueException(string firstName, int minLength)
                   : FormatException($"First name length {firstName} less than minimum allowed(допустимая длина) length {minLength}") // FormatException. Исключение, которое возникает в случае, если формат аргумента недопустим или строка составного формата построена неправильно.  Наследование Object ==> Exception ==> SystemException ==> FormatException
    {
        public string FirstName => firstName;
        public int MinLength => minLength;
    }
}
