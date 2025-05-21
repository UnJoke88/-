using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при пустом имени.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Пустое значение имени.</param>
    internal class FirstNameEmptyException(string paramName, string name)
        : ArgumentException($"Имя не может быть пустым или состоять только из пробелов: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
