using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddCash(CashBalance amount)
        {
            CashBalance = new CashBalance(CashBalance.Value + amount.Value);
        }

        public void RemoveCash(CashBalance amount)
        {
            CashBalance = new CashBalance(CashBalance.Value - amount.Value);
        }

        public void MoveToPending(CashBalance amount)
        {
            CashBalance = new CashBalance(CashBalance.Value - amount.Value);
            PendingCash = new PendingCash(PendingCash.Value + amount.Value);
        }

        #endregion
    }

}
