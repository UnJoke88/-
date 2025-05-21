using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при отсутствии или пустом символе актива.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="symbol">Недопустимое значение символа.</param>
    internal class InvalidAssetSymbolException(string paramName, string symbol)
        : ArgumentException($"Символ актива не может быть пустым или состоять только из пробелов: \"{symbol}\".", paramName)
    {
        public string Symbol => symbol;
    }
}