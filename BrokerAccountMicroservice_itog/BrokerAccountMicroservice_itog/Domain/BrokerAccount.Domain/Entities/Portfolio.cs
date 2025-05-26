using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities
{
    public class Portfolio : Entity<Guid>
    {
        #region Свойства

        /// <summary>
        /// Получение коллекции активов в портфеле
        /// </summary>
        private readonly ICollection<Transaction> _AssetTransaction = [];

        /// <summary>
        /// Получить общую стоимость портфеля.
        /// </summary>
        public Money TotalValue { get; private set; }

        /// <summary>
        /// Уникальное имя или код портфеля.
        /// </summary>
        public PortfolioCode PortfolioCode { get; private set; }
        #endregion


        #region Конструктор

        protected Portfolio() 
        { 

        }

        protected Portfolio(Guid id, PortfolioCode code)
            : base(id)
        {
            PortfolioCode = code ?? throw new ArgumentNullValueException(nameof(portfolioCode));
            TotalValue = new Money(0); //создаётся портфель с общим балансом = 0
        }

        public Portfolio(PortfolioCode code) : this(Guid.NewGuid(), code)
        {

        }

        #endregion
    }
}
