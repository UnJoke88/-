using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при попытке установить отрицательную замороженную сумму.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="amount">Недопустимое значение pending-средств.</param>
    internal class PendingCashNegativeException(string paramName, decimal amount)
        : ArgumentException($"Замороженные средства не могут быть отрицательными: {amount}.", paramName)
    {
        public decimal Amount => amount;
    }
}
