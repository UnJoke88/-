using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при наличии недопустимых символов в фамилии.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Фамилия с недопустимыми символами.</param>
    internal class LastNameInvalidCharactersException(string paramName, string name)
        : ArgumentException($"Фамилия содержит недопустимые символы: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
