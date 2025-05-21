using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при слишком длинной фамилии.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Слишком длинная фамилия.</param>
    internal class LastNameTooLongException(string paramName, string name)
        : ArgumentException($"Фамилия превышает допустимую длину: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
