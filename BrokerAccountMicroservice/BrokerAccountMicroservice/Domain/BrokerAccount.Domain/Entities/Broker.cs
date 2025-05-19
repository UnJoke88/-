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
        // Используется внутри и для создания через public-конструктор
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
        // Упрощённый вызов — Guid генерируется автоматически
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
        // Используется Entity Framework при загрузке сущности из БД
        protected Client() : base(Guid.NewGuid())
        {
        }
        #endregion

        #region Методы брокера

        ///<summary>
        ///Выполняет транзакцию от имени клиента.
        ///</summary>
        ///<param name="account">Брокерский счёт клиента.</param>
        ///<param name="transaction">Готовая транзакция.</param>
        public void ExecuteTransaction(BrokerAccount account, Transaction transaction)
        {
            account.ExecuteTransaction(transaction);
        }

        ///<summary>
        ///Списывает фиксированную комиссию с брокерского счёта клиента.
        ///</summary>
        ///<param name="account">Брокерский счёт клиента.</param>
        ///<param name="feeAmount">Сумма комиссии.</param>
        public void ChargeFee(BrokerAccount account, decimal feeAmount)
        {
            account.SettleFee(feeAmount);
        }

        ///<summary>
        ///Рассчитывает комиссию по ставке брокера и списывает её со счёта клиента.
        ///</summary>
        ///<param name="account">Брокерский счёт клиента.</param>
        ///<param name="baseAmount">Сумма, с которой рассчитывается комиссия.</param>
        public void ChargeCommission(BrokerAccount account, decimal baseAmount)
        {
            account.SettleCommission(baseAmount, CommissionRate);
        }

        ///<summary>
        ///Возвращает текущую стоимость портфеля клиента.
        ///</summary>
        ///<param name="account">Брокерский счёт клиента.</param>
        ///<returns>Суммарная стоимость активов.</returns>
        public decimal GetPortfolioValue(BrokerAccount account)
        {
            return account.GetPortfolioValue();
        }

        ///<summary>
        ///Возвращает объединённую историю всех транзакций клиента.
        ///</summary>
        ///<param name="account">Брокерский счёт клиента.</param>
        ///<returns>История транзакций по счёту и портфелю.</returns>
        public IReadOnlyCollection<Transaction> GetAllTransactions(BrokerAccount account)
        {
            return account.GetAllTransactions();
        }

        ///<summary>
        ///Фильтрует счета по заданному статусу.
        ///</summary>
        ///<param name="status">Статус счёта (Active, Closed и т.д.).</param>
        ///<returns>Список подходящих счетов.</returns>
        public IReadOnlyCollection<BrokerAccount> GetAccountsByStatus(AccountStatus status)
        {
            return _accounts.Where(a => a.Status == status).ToList().AsReadOnly();
        }

        ///<summary>
        ///Возвращает общую сумму комиссий, списанных со счёта клиента.
        ///</summary>
        ///<param name="account">Брокерский счёт клиента.</param>
        ///<returns>Сумма всех комиссий.</returns>
        public decimal GetTotalCommissionCharged(BrokerAccount account)
        {
            return account.GetTotalCommission();
        }

        #endregion
    }
}
