using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при слишком длинном имени брокера.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Слишком длинное имя.</param>
    internal class BrokerNameTooLongException(string paramName, string name)
        : ArgumentException($"Имя брокера превышает допустимую длину: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
