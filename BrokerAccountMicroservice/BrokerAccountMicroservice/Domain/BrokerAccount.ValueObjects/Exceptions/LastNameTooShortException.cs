using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при слишком короткой фамилии.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Слишком короткая фамилия.</param>
    internal class LastNameTooShortException(string paramName, string name)
        : ArgumentException($"Фамилия слишком короткая: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
