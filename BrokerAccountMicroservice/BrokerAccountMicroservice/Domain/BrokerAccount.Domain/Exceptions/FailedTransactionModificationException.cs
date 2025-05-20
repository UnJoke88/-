using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Transaction
{
    ///<summary>
    ///Исключение возникает при попытке изменить уже неуспешную (failed) транзакцию.
    ///</summary>
    public class FailedTransactionModificationException : InvalidOperationException
    {
        private readonly Guid _transactionId;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="transactionId">Идентификатор транзакции.</param>
        public FailedTransactionModificationException(Guid transactionId)
            : base($"Транзакция с ID {transactionId} уже помечена как неуспешная и не может быть изменена.")
        {
            _transactionId = transactionId;
        }

        ///<summary>
        ///Возвращает ID транзакции, вызвавшей исключение.
        ///</summary>
        public Guid TransactionId => _transactionId;
    }
}

