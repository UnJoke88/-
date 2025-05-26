using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities
{
    public class Transaction : Entity<Guid>
    {
        #region Свойства

        /// <summary>
        /// 
        /// </summary>
        public Client Client { get; }
        public DateTime Date { get; private set; }
        public TransactionType Type { get; }
        public Asset? Asset { get; }
        public Money Amount { get; private set; }
        public TransactionStatus Status { get; private set; }

        #endregion

        #region Конструктор
        protected Transaction() 
        { 
        
        }

        protected Transaction(Guid id, Client client, DateTime date, TransactionType type,
                           Asset? asset, Money amount) : base(id)
        {
            Client = client ?? throw new ArgumentNullValueException(nameof(client));
            Date = date;
            Type = type;
            Asset = asset;
            Amount = amount ?? throw new ArgumentNullValueException(nameof(amount));
            Status = status;
        }


        public Transaction(Client client, DateTime date, TransactionType type, Asset? asset, Money amount)
            : this(Guid.NewGuid(), client, date, type, asset, amount)
        {
           
        }
        #endregion
    }
}
