using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.ValueObjects;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities
{
    ///<summary>
    ///Сущность "Брокер" — юридическое лицо, управляющее брокерскими счетами клиентов.
    ///</summary>
    public class Broker : Entity<Guid>
    {
        #region Свойства

        public BrokerName Name { get; }
        public LicenseNumber LicenseNumber { get; }
        public decimal CommissionRate { get; private set; }
        public decimal MinimalDeposit { get; }
        public string? Description { get; }

        private readonly List<BrokerAccount> _accounts = new();

        public IReadOnlyCollection<BrokerAccount> Accounts => _accounts.AsReadOnly();

        #endregion

        #region Конструкторы

        protected Broker(
            Guid id,
            BrokerName name,
            LicenseNumber licenseNumber,
            decimal commissionRate,
            decimal minimalDeposit,
            string? description = null
        ) : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            LicenseNumber = licenseNumber ?? throw new ArgumentNullException(nameof(licenseNumber));

            if (commissionRate < 0 || commissionRate > 1)
                throw new InvalidCommissionRateException(commissionRate);

            if (minimalDeposit < 0)
                throw new NegativeCashAmountException(minimalDeposit);

            CommissionRate = commissionRate;
            MinimalDeposit = minimalDeposit;
            Description = description;
        }

        public Broker(
            BrokerName name,
            LicenseNumber licenseNumber,
            decimal commissionRate,
            decimal minimalDeposit,
            string? description = null
        ) : this(Guid.NewGuid(), name, licenseNumber, commissionRate, minimalDeposit, description)
        {
        }

        protected Broker() : base(Guid.NewGuid())
        {
        }

        #endregion

        #region Методы

        ///<summary>
        ///Привязывает счёт к брокеру.
        ///</summary>
        public void AddAccount(BrokerAccount account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            _accounts.Add(account);
        }

        ///<summary>
        ///Возвращает все активные счета.
        ///</summary>
        public IReadOnlyCollection<BrokerAccount> GetActiveAccounts()
        {
            return _accounts.Where(a => a.Status == AccountStatus.Active).ToList().AsReadOnly();
        }

        ///<summary>
        ///Фильтрует счета по статусу.
        ///</summary>
        public IReadOnlyCollection<BrokerAccount> GetAccountsByStatus(AccountStatus status)
        {
            return _accounts.Where(a => a.Status == status).ToList().AsReadOnly();
        }

        ///<summary>
        ///Возвращает общую стоимость всех портфелей клиентов.
        ///</summary>
        public decimal GetTotalPortfolioValue()
        {
            return _accounts.Sum(a => a.GetPortfolioValue());
        }

        ///<summary>
        ///Возвращает общую сумму всех комиссий.
        ///</summary>
        public decimal GetTotalCommissionCharged()
        {
            return _accounts.Sum(a => a.GetTotalCommission());
        }

        ///<summary>
        ///Изменяет ставку комиссии брокера.
        ///</summary>
        public void UpdateCommissionRate(decimal newRate)
        {
            if (newRate < 0 || newRate > 1)
                throw new InvalidCommissionRateException(newRate);

            CommissionRate = newRate;
        }
        #endregion
    }
}
