using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при некорректной сумме транзакции.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="amount">Недопустимая сумма транзакции.</param>
    internal class TransactionAmountInvalidException(string paramName, decimal amount)
        : ArgumentException($"Сумма транзакции должна быть больше нуля: {amount}.", paramName)
    {
        public decimal Amount => amount;
    }
}
