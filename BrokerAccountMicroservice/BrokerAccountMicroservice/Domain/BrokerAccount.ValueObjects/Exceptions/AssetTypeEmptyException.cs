using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при отсутствии типа актива.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="type">Пустое значение типа.</param>
    internal class AssetTypeEmptyException(string paramName, string type)
        : ArgumentException($"Тип актива не может быть пустым: \"{type}\".", paramName)
    {
        public string Type => type;
    }
}
