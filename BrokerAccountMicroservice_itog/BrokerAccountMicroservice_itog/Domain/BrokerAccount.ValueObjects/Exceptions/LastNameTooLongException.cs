using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    internal class LastNameTooLongException(string lastName, int maxLength)
          : FormatException($"Last name length {lastName} greated than maximum allowed(допустимая длина) length {maxLength}") // FormatException. Исключение, которое возникает в случае, если формат аргумента недопустим или строка составного формата построена неправильно.  Наследование Object ==> Exception ==> SystemException ==> FormatException
    {
        public string LastName => lastName;
        public int MaxLength => maxLength;
    }
}
