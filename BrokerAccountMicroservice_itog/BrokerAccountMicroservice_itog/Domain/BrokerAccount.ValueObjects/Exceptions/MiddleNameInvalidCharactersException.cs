using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при наличии недопустимых символов в отчестве.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Отчество с недопустимыми символами.</param>
    internal class MiddleNameInvalidCharactersException(string paramName, string name)
        : ArgumentException($"Отчество содержит недопустимые символы: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
