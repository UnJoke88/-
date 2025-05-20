using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Transaction;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities
{
    /// <summary>
    /// Сущность "Транзакция" — отражает одну операцию со счётом клиента.
    /// </summary>
    public class Transaction : Entity<Guid>
    {
        #region Свойства

        public BrokerAccount Account { get; }
        public DateTime Date { get; private set; }
        public TransactionType Type { get; }
        public Asset? Asset { get; }
        public TransactionAmount Amount { get; private set; }
        public TransactionFee Fee { get; private set; }
        public TransactionStatus Status { get; private set; }

        #endregion

        #region Конструкторы

        protected Transaction(
            Guid id,
            BrokerAccount account,
            DateTime date,
            TransactionType type,
            Asset? asset,
            TransactionAmount amount,
            TransactionFee fee,
            TransactionStatus status
        ) : base(id)
        {
            Account = account ?? throw new ArgumentNullException(nameof(account));

            if (amount == null || amount.Value <= 0)
                throw new InvalidTransactionAmountException(amount?.Value ?? 0);

            if (date > DateTime.UtcNow)
                throw new InvalidTransactionDateException(date);

            Date = date;
            Type = type;
            Asset = asset;
            Amount = amount;
            Fee = fee;
            Status = status;
        }

        public Transaction(
            BrokerAccount account,
            DateTime date,
            TransactionType type,
            Asset? asset,
            TransactionAmount amount,
            TransactionFee fee,
            TransactionStatus status
        ) : this(Guid.NewGuid(), account, date, type, asset, amount, fee, status)
        {
        }

        protected Transaction() : base(Guid.NewGuid())
        {
        }

        #endregion

        #region Методы

        ///<summary>
        ///Завершает транзакцию, если она ещё не завершена.
        ///</summary>
        public void Complete()
        {
            if (Status == TransactionStatus.Completed)
                throw new CompletedTransactionModificationException(Id);

            Status = TransactionStatus.Completed;
        }

        ///<summary>
        ///Помечает транзакцию как неуспешную.
        ///</summary>
        public void Fail()
        {
            if (Status == TransactionStatus.Failed)
                throw new FailedTransactionModificationException(Id);

            Status = TransactionStatus.Failed;
        }

        ///<summary>
        ///Обновляет сумму транзакции.
        ///</summary>
        ///<param name="newAmount">Новая сумма.</param>
        public void UpdateAmount(TransactionAmount newAmount)
        {
            if (Status == TransactionStatus.Completed)
                throw new CompletedTransactionModificationException(Id);

            if (newAmount == null || newAmount.Value <= 0)
                throw new InvalidTransactionAmountException(newAmount?.Value ?? 0);

            Amount = newAmount;
        }

        ///<summary>
        ///Обновляет комиссию для транзакции.
        ///</summary>
        ///<param name="newFee">Новая комиссия.</param>
        public void UpdateFee(TransactionFee newFee)
        {
            if (Status == TransactionStatus.Completed)
                throw new CompletedTransactionModificationException(Id);

            Fee = newFee;
        }

        ///<summary>
        ///Обновляет дату транзакции.
        ///</summary>
        ///<param name="newDate">Новая дата.</param>
        public void UpdateDate(DateTime newDate)
        {
            if (newDate > DateTime.UtcNow)
                throw new InvalidTransactionDateException(newDate);

            Date = newDate;
        }

        #endregion
    }
}
