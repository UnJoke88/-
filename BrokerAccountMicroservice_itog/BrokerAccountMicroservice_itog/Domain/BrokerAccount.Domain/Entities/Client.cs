using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Exceptions;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities
{
    public class Client : Entity<Guid>
    {
        #region Свойства

        public FirstName FirstName { get; }
        public LastName LastName { get; }
        public MiddleName? MiddleName { get; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

        public Card Card { get; }

        public Portfolio Portfolio { get; }

        private readonly ICollection<Transaction> _transactions = [];


        #endregion

        #region Конструктор
        protected Client() 
        {
        
        }

        protected Client(Guid id, FirstName firstName, LastName lastName, MiddleName? middleName,
                      Email email, PhoneNumber phoneNumber, Card card, Portfolio portfolio)
            : base(id)
        {
            FirstName = firstName ?? throw new ArgumentNullValueException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullValueException(nameof(lastName));
            MiddleName = middleName;
            Email = email ?? throw new ArgumentNullValueException(nameof(email));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullValueException(nameof(phoneNumber));
            Card = card ?? throw new ArgumentNullValueException(nameof(card));
            Portfolio = portfolio ?? throw new ArgumentNullValueException(nameof(portfolio));
        }

        public Client(FirstName firstName, LastName lastName, MiddleName? middleName,
                      Email email, PhoneNumber phoneNumber, Card card, Portfolio portfolio)
            : this(Guid.NewGuid(), firstName, lastName, middleName, email, phoneNumber, card, portfolio)//Guid.NewGuid() - формирует id и передаёт в Guid id(protected) далее base(id)
        {

        }
        #endregion

        #region Методы
        
        //Покупка Актива
        public void BuyAsset(Asset asset, MinimalUnit quantity)
        {
            var amount = asset.PurchasePrice * quantity;
            if(!this.Card.Withdraw(amount,TransactionType.Purchase))
            {
                var incorectTransaction = TransactionStatus.Failed;
            }
            var transaction = new Transaction(this, DateTime.Now, TransactionType.Purchase, asset, quantity);
            transaction.SetTransactionStatus(TransactionStatus.Completed);
            _transactions.Add(transaction);
            if(transaction.Status == TransactionStatus.Completed)
            {
                Portfolio.ApplyTransaction(transaction);
            }
        }

        public IReadOnlyCollection<Transaction> Transactions =>
            _transactions.ToList().AsReadOnly();
        

        #endregion
    }
}