using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Transaction
{
    ///<summary>
    ///Исключение возникает, если сумма транзакции меньше или равна нулю.
    ///</summary>
    public class InvalidTransactionAmountException : InvalidOperationException
    {
        private readonly decimal _amount;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="amount">Неверная сумма транзакции.</param>
        public InvalidTransactionAmountException(decimal amount)
            : base($"Сумма транзакции {amount} должна быть больше нуля.")
        {
            _amount = amount;
        }

        ///<summary>
        ///Возвращает сумму транзакции, вызвавшую исключение.
        ///</summary>
        public decimal Amount => _amount;
    }
}


