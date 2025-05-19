using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Enums;



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

        public void Complete()
        {
            Status = TransactionStatus.Completed;
        }

        public void Fail()
        {
            Status = TransactionStatus.Failed;
        }

        public void UpdateDate(DateTime date)
        {
            Date = date;
        }

        public void UpdateAmount(TransactionAmount amount)
        {
            Amount = amount;
        }

        public void UpdateFee(TransactionFee fee)
        {
            Fee = fee;
        }

        #endregion
    }
}

