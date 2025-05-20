using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.ValueObjects;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities
{
    ///<summary>
    ///Сущность "Клиент" — владелец брокерского счёта.
    ///</summary>
    public class Client : Entity<Guid>
    {
        #region Свойства

        public FirstName FirstName { get; }
        public LastName LastName { get; }
        public MiddleName? MiddleName { get; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public BrokerAccount Account { get; private set; }

        #endregion

        #region Конструкторы

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

        protected Client() : base(Guid.NewGuid())
        {
        }

        #endregion

        #region Методы

        ///<summary>
        ///Обновляет контактную информацию клиента.
        ///</summary>
        ///<param name="email">Новый email.</param>
        ///<param name="phone">Новый номер телефона.</param>
        public void UpdateContactInfo(Email email, PhoneNumber phone)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            if (phone == null)
                throw new ArgumentNullException(nameof(phone));

            Email = email;
            PhoneNumber = phone;
        }

        ///<summary>
        ///Привязывает брокерский счёт к клиенту.
        ///</summary>
        ///<param name="account">Созданный счёт.</param>
        public void AttachAccount(BrokerAccount account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            Account = account;
        }

        ///<summary>
        ///Возвращает ФИО клиента.
        ///</summary>
        ///<returns>Полное имя.</returns>
        public string GetFullName()
        {
            return MiddleName is not null
                ? $"{LastName.Value} {FirstName.Value} {MiddleName.Value}"
                : $"{LastName.Value} {FirstName.Value}";
        }

        ///<summary>
        ///Пополняет счёт клиента.
        ///</summary>
        ///<param name="amount">Сумма пополнения.</param>
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new NegativeCashAmountException(amount);

            Account.Deposit(amount);
        }

        ///<summary>
        ///Снимает средства со счёта клиента.
        ///</summary>
        ///<param name="amount">Сумма снятия.</param>
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new NegativeCashAmountException(amount);

            Account.Withdraw(amount);
        }

        ///<summary>
        ///Покупает актив через брокерский счёт.
        ///</summary>
        ///<param name="asset">Актив.</param>
        public void BuyAsset(Asset asset)
        {
            if (asset == null)
                throw new ArgumentNullException(nameof(asset));

            Account.BuyAsset(asset);
        }

        ///<summary>
        ///Продаёт актив по идентификатору.
        ///</summary>
        ///<param name="assetId">ID актива.</param>
        public void SellAsset(Guid assetId)
        {
            Account.SellAsset(assetId);
        }

        ///<summary>
        ///Просматривает текущий баланс клиента.
        ///</summary>
        ///<returns>Сумма средств.</returns>
        public decimal ViewBalance()
        {
            return Account.GetBalance();
        }

        ///<summary>
        ///Просматривает стоимость портфеля.
        ///</summary>
        ///<returns>Суммарная стоимость активов.</returns>
        public decimal ViewPortfolioValue()
        {
            return Account.GetPortfolioValue();
        }

        ///<summary>
        ///История транзакций по счёту.
        ///</summary>
        public IReadOnlyCollection<Transaction> GetCardTransactionHistory()
        {
            return Account.GetCardTransactions();
        }

        ///<summary>
        ///История операций с активами.
        ///</summary>
        public IReadOnlyCollection<Transaction> GetPortfolioTransactionHistory()
        {
            return Account.GetPortfolioTransactions();
        }

        #endregion
    }
}
