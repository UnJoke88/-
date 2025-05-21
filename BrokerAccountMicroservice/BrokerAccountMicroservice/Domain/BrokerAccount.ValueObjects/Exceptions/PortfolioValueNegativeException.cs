using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при отрицательной стоимости портфеля.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="value">Недопустимое значение стоимости.</param>
    internal class PortfolioValueNegativeException(string paramName, decimal value)
        : ArgumentException($"Стоимость портфеля не может быть отрицательной: {value}.", paramName)
    {
        public decimal Value => value;
    }
}
