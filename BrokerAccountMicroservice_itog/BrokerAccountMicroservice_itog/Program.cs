using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var asset = new Asset(AssetType.RUB, new MinimalUnit(1), new Money(50));
            //asset.ChangeMinimalUnit(null);

            //var cardNumber = new CardNumber("1234567812345678");
            //var card = new Card(cardNumber);
            //Console.WriteLine($"Баланс карты: {card.CashBalance} RUB");
            //card.Deposit(new Money(100),TransactionType.Replenishment);
            //Console.WriteLine($"Баланс карты: {card.CashBalance} RUB");
            //card.Withdraw(new Money(200), TransactionType.Removing);
            //Console.WriteLine($"Баланс карты: {card.CashBalance} RUB");
            //Console.WriteLine();

            var card2 = new Card(new CardNumber("1111111111111111"));
            var portfolio1 = new Portfolio(new PortfolioNumber("45345345"));
            var Client = new Client(new FirstName("Илья"), new LastName("Субботин"), new MiddleName("Андреевич"),
                new Email("gggooolll228@mail.ru"), new PhoneNumber("78005553535"), card2, portfolio1);

            Console.WriteLine($"{Client.Id} {Client.FirstName} " + $"{Client.LastName} {Client.MiddleName} {Client.Email}" +
                $" {Client.PhoneNumber} {Client.Card.CardNumber} {Client.Portfolio.PortfolioNumber}"); 
        }
    }
}