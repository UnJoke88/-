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
    /// <summary>
    /// Представляет карту клиента для операций с балансом.
    /// </summary>
    public class Card : Entity<Guid>
    {
        #region Свойства

        /// <summary>
        /// Уникальный номер или название карты.
        /// </summary>
        public CardNumber CardNumber { get; private set; }

        /// <summary>
        /// Получить денежный баланс клиента.
        /// </summary>
        public Money CashBalance { get; }

        #endregion


        #region Конструктор
        protected Card() 
        { 
        
        }

        protected Card(Guid id, CardNumber cardNumber, Money cashBalance)
            : base(id)
        {
            CardNumber = cardNumber ?? throw new ArgumentNullValueException(nameof(cardNumber));
            CashBalance = cashBalance ?? throw new ArgumentNullValueException(nameof(cashBalance));
        }

        public Card(CardNumber cardNumber,Money cashBalance) 
            : this(Guid.NewGuid(), cardNumber,cashBalance)
        { 

        }

        #endregion
    }
}
