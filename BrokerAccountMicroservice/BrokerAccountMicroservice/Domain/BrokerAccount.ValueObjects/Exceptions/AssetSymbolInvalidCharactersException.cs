using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при наличии недопустимых символов в обозначении актива.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="symbol">Недопустимое значение символа.</param>
    internal class AssetSymbolInvalidCharactersException(string paramName, string symbol)
        : ArgumentException($"Символ актива содержит недопустимые символы: \"{symbol}\".", paramName)
    {
        public string Symbol => symbol;
    }
}
