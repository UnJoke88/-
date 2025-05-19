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

        ///<summary>
        ///Пополняет счёт на указанную сумму.
        ///</summary>
        ///<param name="amount">Сумма пополнения.</param>
        public void Deposit(decimal amount)
        {
            CardBalance.AddCash(new CashBalance(amount));

            var transaction = new Transaction(
                this,
                DateTime.UtcNow,
                TransactionType.Deposit,
                null,
                new TransactionAmount(amount),
                new TransactionFee(0),
                TransactionStatus.Completed
            );

            AddCardTransaction(transaction);
        }

        ///<summary>
        ///Снимает указанную сумму со счёта.
        ///</summary>
        ///<param name="amount">Сумма для снятия.</param>
        public void Withdraw(decimal amount)
        {
            CardBalance.RemoveCash(new CashBalance(amount));

            var transaction = new Transaction(
                this,
                DateTime.UtcNow,
                TransactionType.Withdrawal,
                null,
                new TransactionAmount(amount),
                new TransactionFee(0),
                TransactionStatus.Completed
            );

            AddCardTransaction(transaction);
        }

        ///<summary>
        ///Покупает актив и добавляет его в портфель.
        ///</summary>
        ///<param name="asset">Покупаемый актив.</param>
        public void BuyAsset(Asset asset)
        {
            Portfolio.AddAsset(asset);

            var amount = asset.PurchasePrice.Value * asset.Quantity.Value;
            var transaction = new Transaction(
                this,
                DateTime.UtcNow,
                TransactionType.Buy,
                asset,
                new TransactionAmount(amount),
                new TransactionFee(1),
                TransactionStatus.Completed
            );

            AddPortfolioTransaction(transaction);
        }

        ///<summary>
        ///Продаёт актив по его идентификатору.
        ///</summary>
        ///<param name="assetId">Идентификатор актива.</param>
        public void SellAsset(Guid assetId)
        {
            var asset = Portfolio.Assets.FirstOrDefault(a => a.Id == assetId);
            if (asset is null)
                throw new InvalidOperationException("Актив не найден.");

            Portfolio.RemoveAsset(assetId);

            var amount = asset.CurrentPrice.Value * asset.Quantity.Value;
            var transaction = new Transaction(
                this,
                DateTime.UtcNow,
                TransactionType.Sell,
                asset,
                new TransactionAmount(amount),
                new TransactionFee(1),
                TransactionStatus.Completed
            );

            AddPortfolioTransaction(transaction);
        }

        ///<summary>
        ///Добавляет транзакцию вручную (используется брокером).
        ///</summary>
        ///<param name="transaction">Готовая транзакция.</param>
        public void ExecuteTransaction(Transaction transaction)
        {
            if (transaction.Type is TransactionType.Deposit or TransactionType.Withdrawal or TransactionType.Fee)
                AddCardTransaction(transaction);
            else
                AddPortfolioTransaction(transaction);
        }

        ///<summary>
        ///Списывает фиксированную комиссию.
        ///</summary>
        ///<param name="feeAmount">Сумма комиссии.</param>
        public void SettleFee(decimal feeAmount)
        {
            CardBalance.RemoveCash(new CashBalance(feeAmount));

            var transaction = new Transaction(
                this,
                DateTime.UtcNow,
                TransactionType.Fee,
                null,
                new TransactionAmount(feeAmount),
                new TransactionFee(feeAmount),
                TransactionStatus.Completed
            );

            AddCardTransaction(transaction);
        }

        ///<summary>
        ///Рассчитывает и списывает комиссию по заданной ставке.
        ///</summary>
        ///<param name="baseAmount">Базовая сумма операции.</param>
        ///<param name="rate">Процент комиссии.</param>
        public void SettleCommission(decimal baseAmount, decimal rate)
        {
            var fee = baseAmount * rate;
            SettleFee(fee);
        }

        ///<summary>
        ///Возвращает текущий доступный баланс.
        ///</summary>
        ///<returns>Сумма денежных средств на счёте.</returns>
        public decimal GetBalance()
        {
            return CardBalance.CashBalance.Value;
        }

        ///<summary>
        ///Возвращает суммарную стоимость портфеля.
        ///</summary>
        ///<returns>Общая стоимость всех активов клиента.</returns>
        public decimal GetPortfolioValue()
        {
            return Portfolio.TotalValue.Value;
        }

        ///<summary>
        ///Возвращает объединённую историю всех транзакций.
        ///</summary>
        ///<returns>Список всех транзакций по счёту и активам.</returns>
        public IReadOnlyCollection<Transaction> GetAllTransactions()
        {
            return _cardTransactions
                .Concat(_portfolioTransactions)
                .OrderByDescending(t => t.Date)
                .ToList()
                .AsReadOnly();
        }

        ///<summary>
        ///Возвращает сумму всех комиссий, списанных со счёта.
        ///</summary>
        ///<returns>Суммарная комиссия.</returns>
        public decimal GetTotalCommission()
        {
            return _cardTransactions
                .Where(t => t.Type == TransactionType.Fee)
                .Sum(t => t.Fee.Value);
        }

        ///<summary>
        ///Добавляет транзакцию пополнения или снятия.
        ///</summary>
        ///<param name="transaction">Транзакция по счёту.</param>
        public void AddCardTransaction(Transaction transaction)
        {
            _cardTransactions.Add(transaction);
        }

        ///<summary>
        ///Добавляет транзакцию покупки или продажи.
        ///</summary>
        ///<param name="transaction">Транзакция по портфелю.</param>
        public void AddPortfolioTransaction(Transaction transaction)
        {
            _portfolioTransactions.Add(transaction);
        }

        ///<summary>
        ///Возвращает историю транзакций по балансу.
        ///</summary>
        ///<returns>Список транзакций по карте.</returns>
        public IReadOnlyCollection<Transaction> GetCardTransactions()
        {
            return _cardTransactions.ToList().AsReadOnly();
        }

        ///<summary>
        ///Возвращает историю операций с активами.
        ///</summary>
        ///<returns>Список транзакций по портфелю.</returns>
        public IReadOnlyCollection<Transaction> GetPortfolioTransactions()
        {
            return _portfolioTransactions.ToList().AsReadOnly();
        }

        #endregion


        #endregion

    }

}
