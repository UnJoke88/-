using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при недопустимом значении минимальной единицы измерения.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="unit">Недопустимое значение единицы.</param>
    internal class InvalidMinimalUnitException(string paramName, decimal unit)
        : ArgumentException($"Минимальная единица измерения должна быть положительной: {unit}.", paramName)
    {
        public decimal Unit => unit;
    }
}