using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    /// Проверка длины отчества.
    ///</summary>
    internal class MiddleNameTooLongException(string name, int maxLength)
        : ArgumentException($"Отчество превышает допустимую длину в {maxLength} символов: \"{name}\".", nameof(name))
    {
        public string Name => name;
        public int MaxLength => maxLength;
    }
}
