using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при попытке создать отрицательный денежный баланс.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="amount">Отрицательное значение суммы.</param>
    internal class CashBalanceNegativeException(string paramName, decimal amount)
        : ArgumentException($"Баланс не может быть отрицательным: {amount}.", paramName)
    {
        public decimal Amount => amount;
    }
}
