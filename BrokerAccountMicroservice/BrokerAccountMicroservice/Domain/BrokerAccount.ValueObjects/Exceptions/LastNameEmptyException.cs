using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при пустой фамилии.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Пустое значение фамилии.</param>
    internal class LastNameEmptyException(string paramName, string name)
        : ArgumentException($"Фамилия не может быть пустой или состоять только из пробелов: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
