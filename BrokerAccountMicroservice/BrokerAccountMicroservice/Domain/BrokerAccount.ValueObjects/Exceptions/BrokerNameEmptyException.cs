using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при отсутствии имени брокера.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Пустое значение имени.</param>
    internal class BrokerNameEmptyException(string paramName, string name)
        : ArgumentException($"Имя брокера не может быть пустым или состоять только из пробелов: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
