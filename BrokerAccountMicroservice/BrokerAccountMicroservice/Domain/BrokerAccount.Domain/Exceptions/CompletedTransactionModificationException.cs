using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Transaction
{
    ///<summary>
    ///Исключение возникает при попытке изменить уже завершённую транзакцию.
    ///</summary>
    public class CompletedTransactionModificationException : InvalidOperationException
    {
        private readonly Guid _transactionId;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="transactionId">Идентификатор транзакции.</param>
        public CompletedTransactionModificationException(Guid transactionId)
            : base($"Транзакция с ID {transactionId} уже завершена и не может быть изменена.")
        {
            _transactionId = transactionId;
        }

        ///<summary>
        ///Возвращает ID транзакции, вызвавшей исключение.
        ///</summary>
        public Guid TransactionId => _transactionId;
    }
}
