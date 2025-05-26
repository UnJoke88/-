using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при наличии недопустимых символов в имени.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Имя с недопустимыми символами.</param>
    internal class FirstNameInvalidCharactersException(string paramName, string name)
        : FormatException($"Имя содержит недопустимые символы: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}