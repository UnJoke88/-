using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities
{
    /// <summary>
    /// Сущность "Баланс карты" — денежные средства, доступные клиенту.
    /// </summary>
    public class CardBalance : Entity<Guid>
    {
        #region Свойства

        public CashBalance CashBalance { get; private set; }
        public PendingCash PendingCash { get; private set; }
        public Currency Currency { get; }

        #endregion

        #region Конструкторы

        protected CardBalance(Guid id, CashBalance cashBalance, PendingCash pendingCash, Currency currency)
            : base(id)
        {
            CashBalance = cashBalance;
            PendingCash = pendingCash;
            Currency = currency;
        }

        public CardBalance(CashBalance cashBalance, PendingCash pendingCash, Currency currency)
            : this(Guid.NewGuid(), cashBalance, pendingCash, currency)
        {
        }

        protected CardBalance() : base(Guid.NewGuid())
        {
        }

        #endregion

        #region Методы

        ///<summary>
        ///Добавляет средства на доступный баланс.
        ///</summary>
        ///<param name="amount">Сумма пополнения.</param>
        public void AddCash(CashBalance amount)
        {
            if (amount.Value < 0)
                throw new NegativeCashAmountException(amount.Value);

            CashBalance = new CashBalance(CashBalance.Value + amount.Value);
        }

        ///<summary>
        ///Списывает средства с доступного баланса.
        ///</summary>
        ///<param name="amount">Сумма списания.</param>
        public void RemoveCash(CashBalance amount)
        {
            if (amount.Value < 0)
                throw new NegativeCashAmountException(amount.Value);

            if (CashBalance.Value < amount.Value)
                throw new InsufficientFundsException(amount.Value, CashBalance.Value);

            CashBalance = new CashBalance(CashBalance.Value - amount.Value);
        }

        ///<summary>
        ///Переводит средства во временно заблокированные (pending).
        ///</summary>
        ///<param name="amount">Сумма для блокировки.</param>
        public void MoveToPending(CashBalance amount)
        {
            if (amount.Value < 0)
                throw new NegativeCashAmountException(amount.Value);

            if (CashBalance.Value < amount.Value)
                throw new PendingExceedsBalanceException(amount.Value, CashBalance.Value);

            CashBalance = new CashBalance(CashBalance.Value - amount.Value);
            PendingCash = new CashBalance(PendingCash.Value + amount.Value);
        }

        #endregion
    }
}
