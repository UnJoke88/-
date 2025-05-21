using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при отрицательном минимальном депозите.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="amount">Отрицательное значение депозита.</param>
    internal class MinimalDepositNegativeException(string paramName, decimal amount)
        : ArgumentException($"Минимальный депозит не может быть отрицательным: {amount}.", paramName)
    {
        public decimal Amount => amount;
    }
}
