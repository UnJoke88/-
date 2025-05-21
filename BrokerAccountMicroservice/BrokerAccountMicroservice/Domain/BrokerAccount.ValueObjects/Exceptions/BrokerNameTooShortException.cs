using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при слишком коротком имени брокера.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Слишком короткое имя.</param>
    internal class BrokerNameTooShortException(string paramName, string name)
        : ArgumentException($"Имя брокера слишком короткое: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
