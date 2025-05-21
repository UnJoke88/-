using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при недопустимом типе актива.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="type">Недопустимый тип.</param>
    internal class InvalidAssetTypeException(string paramName, string type)
        : ArgumentException($"Недопустимый тип актива: \"{type}\".", paramName)
    {
        public string Type => type;
    }
}
