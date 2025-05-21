using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при отрицательной текущей цене актива.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="price">Отрицательная цена.</param>
    internal class CurrentPriceNegativeException(string paramName, decimal price)
        : ArgumentException($"Текущая цена не может быть отрицательной: {price}.", paramName)
    {
        public decimal Price => price;
    }
}
