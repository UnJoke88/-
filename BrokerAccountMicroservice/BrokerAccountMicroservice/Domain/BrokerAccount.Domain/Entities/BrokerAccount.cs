using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities
{
    ///<summary>
    ///Сущность "Брокерский счёт" — управляет активами и средствами клиента.
    ///</summary>
    public class BrokerAccount : Entity<Guid>
    {
        #region Свойства

        public Client Owner { get; }
        public AccountStatus Status { get; private set; }
        public DateTime OpeningDate { get; private set; }
        public CardBalance CardBalance { get; private set; }
        public Portfolio Portfolio { get; private set; }

        //создаём закрытую коллекцию транзакций, которую можно заполнять, но нельзя переопределить
        private readonly ICollection<Transaction> _cardTransactions = new List<Transaction>();
        private readonly ICollection<Transaction> _portfolioTransactions = new List<Transaction>();

        //возвращается ссылка на внутреннюю коллекцию (чтение)
        public IReadOnlyCollection<Transaction> CardTransactions => (IReadOnlyCollection<Transaction>)_cardTransactions;
        public IReadOnlyCollection<Transaction> PortfolioTransactions => (IReadOnlyCollection<Transaction>)_portfolioTransactions;
        #endregion

        #region Конструкторы

        protected BrokerAccount(
            Guid id,
            Client owner,
            AccountStatus status,
            DateTime openingDate,
            CardBalance cardBalance,
            Portfolio portfolio
        ) : base(id)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Status = status;
            OpeningDate = openingDate;
            CardBalance = cardBalance ?? throw new ArgumentNullException(nameof(cardBalance));
            Portfolio = portfolio ?? throw new ArgumentNullException(nameof(portfolio));
        }

        public BrokerAccount(
            Client owner,
            AccountStatus status,
            DateTime openingDate,
            CardBalance cardBalance,
            Portfolio portfolio
        ) : this(Guid.NewGuid(), owner, status, openingDate, cardBalance, portfolio)
        {
        }

        protected BrokerAccount() : base(Guid.NewGuid())
        {
        }
        #endregion

        #region Методы

        public void AddCardTransaction(Transaction transaction)
        {
            _cardTransactions.Add(transaction);
        }

        public void AddPortfolioTransaction(Transaction transaction)
        {
            _portfolioTransactions.Add(transaction);
        }

        public void ChangeStatus(AccountStatus status)
        {
            Status = status;
        }
        #endregion
    }

}
