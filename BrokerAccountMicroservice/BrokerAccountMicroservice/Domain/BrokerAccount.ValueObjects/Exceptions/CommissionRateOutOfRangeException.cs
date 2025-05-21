using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при недопустимом значении ставки комиссии.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="rate">Неверная ставка комиссии.</param>
    internal class CommissionRateOutOfRangeException(string paramName, decimal rate)
        : ArgumentException($"Ставка комиссии должна быть от 0 до 1. Получено: {rate}.", paramName)
    {
        public decimal Rate => rate;
    }
}
