using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при превышении допустимой длины символа актива.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="symbol">Слишком длинный символ.</param>
    internal class AssetSymbolTooLongException(string paramName, string symbol)
        : ArgumentException($"Символ актива слишком длинный: \"{symbol}\".", paramName)
    {
        public string Symbol => symbol;
    }
}
