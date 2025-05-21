using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при недопустимом количестве актива.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="quantity">Недопустимое значение количества.</param>
    internal class AssetQuantityOutOfRangeException(string paramName, int quantity)
        : ArgumentException($"Количество актива не может быть меньше или равно нулю: {quantity}.", paramName)
    {
        public int Quantity => quantity;
    }
}
