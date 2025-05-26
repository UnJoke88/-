using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при слишком длинном отчестве.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Слишком длинное отчество.</param>
    internal class MiddleNameTooLongException(string paramName, string name)
        : ArgumentException($"Отчество превышает допустимую длину: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
