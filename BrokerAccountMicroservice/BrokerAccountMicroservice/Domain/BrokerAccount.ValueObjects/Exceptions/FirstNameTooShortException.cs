using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при слишком коротком имени.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Слишком короткое имя.</param>
    internal class FirstNameTooShortException(string paramName, string name)
        : ArgumentException($"Имя слишком короткое: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
