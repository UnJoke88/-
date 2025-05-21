using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при отрицательной цене покупки актива.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="price">Отрицательная цена покупки.</param>
    internal class PurchasePriceNegativeException(string paramName, decimal price)
        : ArgumentException($"Цена покупки не может быть отрицательной: {price}.", paramName)
    {
        public decimal Price => price;
    }
}