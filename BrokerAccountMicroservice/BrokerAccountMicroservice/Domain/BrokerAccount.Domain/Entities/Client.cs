using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities
{
    /// <summary>
    /// Сущность "Клиент" — инвестор, владеющий брокерским счётом.
    /// </summary>
    public class Client : Entity<Guid>
    {
        #region Свойства

        public FirstName FirstName { get; }
        public LastName LastName { get; }
        public MiddleName? MiddleName { get; }
        public Email Email { get; }
        public PhoneNumber PhoneNumber { get; }
        public DateTime RegistrationDate { get; private set; }
        public BrokerAccount Account { get; private set; }

        #endregion

        #region Основной конструктор

        protected Client(
            Guid id,
            FirstName firstName,
            LastName lastName,
            MiddleName? middleName,
            Email email,
            PhoneNumber phoneNumber,
            DateTime registrationDate
        ) : base(id)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            MiddleName = middleName;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            RegistrationDate = registrationDate;
        }

        #endregion

        #region Публичный конструктор

        public Client(
            FirstName firstName,
            LastName lastName,
            MiddleName? middleName,
            Email email,
            PhoneNumber phoneNumber,
            DateTime registrationDate
        ) : this(Guid.NewGuid(), firstName, lastName, middleName, email, phoneNumber, registrationDate)
        {
        }

        #endregion

        #region Конструктор для ORM

        protected Client() : base(Guid.NewGuid())
        {
        }

        #endregion


        #region Методы

        ///<summary>
        ///Пополняет брокерский счёт клиента.
        ///</summary>
        ///<param name="amount">Сумма пополнения.</param>
        public void Deposit(decimal amount)
        {
            Account.Deposit(amount);
        }

        ///<summary>
        ///Снимает денежные средства со счёта клиента.
        ///</summary>
        ///<param name="amount">Сумма для снятия.</param>
        public void Withdraw(decimal amount)
        {
            Account.Withdraw(amount);
        }

        ///<summary>
        ///Покупает актив и добавляет его в портфель.
        ///</summary>
        ///<param name="asset">Актив для покупки.</param>
        public void BuyAsset(Asset asset)
        {
            Account.BuyAsset(asset);
        }

        ///<summary>
        ///Продаёт актив по его идентификатору.
        ///</summary>
        ///<param name="assetId">Идентификатор актива.</param>
        public void SellAsset(Guid assetId)
        {
            Account.SellAsset(assetId);
        }

        ///<summary>
        ///Возвращает текущий доступный баланс клиента.
        ///</summary>
        ///<returns>Сумма денежных средств.</returns>
        public decimal ViewBalance()
        {
            return Account.GetBalance();
        }

        ///<summary>
        ///Возвращает текущую стоимость портфеля клиента.
        ///</summary>
        ///<returns>Суммарная стоимость всех активов.</returns>
        public decimal ViewPortfolioValue()
        {
            return Account.GetPortfolioValue();
        }

        ///<summary>
        ///История пополнений и снятий.
        ///</summary>
        ///<returns>Список транзакций по счёту.</returns>
        public IReadOnlyCollection<Transaction> GetCardTransactionHistory()
        {
            return Account.GetCardTransactions();
        }

        ///<summary>
        ///История операций с активами (покупка, продажа).
        ///</summary>
        ///<returns>Список транзакций по портфелю.</returns>
        public IReadOnlyCollection<Transaction> GetPortfolioTransactionHistory()
        {
            return Account.GetPortfolioTransactions();
        }

        #endregion
    }
}
