using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Exceptions;
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

        /// <summary>
        /// Минимальная единица покупки (например от 1).
        /// </summary>
        public MinimalUnit? Quantity { get; private set; }

        public Money Amount { get; private set; }

    
        public TransactionStatus Status { get; private set; }

        #endregion

        #region Конструктор
        protected Transaction() 
        { 
        
        }

        //Конструктор для Пополнения\снятия карты
        protected Transaction(Guid id, Client client, DateTime date, TransactionType type,
                           Asset? asset, MinimalUnit? quantity, Money amount) : base(id)
        {
            Client = client ?? throw new ArgumentNullValueException(nameof(client));
            Date = date;
            Type = type;
            Asset = asset;
            Quantity = quantity;
            Amount = amount ?? throw new ArgumentNullValueException(nameof(amount));
        }

        //Конструктор для Покупки\Продажи активов
        protected Transaction(Guid id, Client client, DateTime date, TransactionType type,
                      Asset? asset, MinimalUnit? quantity) : base(id)
        {
            Client = client ?? throw new ArgumentNullValueException(nameof(client));
            Date = date;
            Type = type;
            Asset = asset;
            Quantity = quantity;
            Amount = asset.PurchasePrice * Quantity;
        }


        public Transaction(Client client, DateTime date, TransactionType type, Asset? asset, MinimalUnit? quantity, Money amount)
            : this(Guid.NewGuid(), client, date, type, asset, quantity, amount)
        {
           
        }

        public Transaction(Client client, DateTime date, TransactionType type, Asset? asset, MinimalUnit? quantity)
            : this(Guid.NewGuid(), client, date, type, asset, quantity)
        {

        }
        #endregion

        #region Методы

        //Изменение статуса транзакции
        public bool SetTransactionStatus(TransactionStatus transactionStatus) 
        {
            if (Status == transactionStatus) return false;
            Status = transactionStatus;
            return true;
        }

        #endregion
    }
}
