using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System.Security.Cryptography.X509Certificates;

namespace BrokerAccountMicroservice_itog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var asset = new Asset(AssetType.RUB, new MinimalUnit(1), new Money(50));
            asset.ChangeMinimalUnit(new MinimalUnit(1));

            //var cardNumber = new CardNumber("1234567812345678");
            //var card = new Card(cardNumber);
            //Console.WriteLine($"Баланс карты: {card.CashBalance} RUB");
            //card.Deposit(new Money(100), TransactionType.Replenishment);
            //Console.WriteLine($"Баланс карты: {card.CashBalance} RUB");
            //card.Withdraw(new Money(200), TransactionType.Removing);
            //Console.WriteLine($"Баланс карты: {card.CashBalance} RUB");
            //Console.WriteLine();

            var assetEUR = new Asset(AssetType.EUR, new MinimalUnit(1), new Money(80));
            var assetGOLD = new Asset(AssetType.GOLD, new MinimalUnit(1), new Money(10000));
            var assetUSD = new Asset(AssetType.USD, new MinimalUnit(1), new Money(60));
            var card2 = new Card(new CardNumber("1111111111111111"));
            var portfolio1 = new Portfolio(new PortfolioNumber("45345345"));

            //Конструктор для вывода статистики портфеля
            var statistic = portfolio1.GetAssetStatistics(); //В переменную statistic записываем результат метода GetAssetStatistics, который возвращает словарь включенных значений
            foreach (var elem in statistic)
            {
                Console.WriteLine($"{elem.AssetType} {elem.Quantity} {elem.TotalValue}");
            }

            var Client = new Client(new FirstName("Илья"), new LastName("Субботин"), new MiddleName("Андреевич"),
                new Email("gggooolll228@mail.ru"), new PhoneNumber("78005553535"), card2, portfolio1);

            Console.WriteLine($"{Client.Id} {Client.FirstName} " + $"{Client.LastName} {Client.MiddleName} {Client.Email}" +
                $" {Client.PhoneNumber} {Client.Card.CardNumber} {Client.Portfolio.PortfolioNumber}");

            Console.WriteLine($"Баланс карты: {card2.CashBalance} RUB");
            Console.WriteLine($"Портфель : {portfolio1.GetTotalPortfolioValue()} RUB");
            Client.MakeDeposit(new Money(1500)); //вызывать от клиента а не от карты
            Console.WriteLine($"Баланс карты: {card2.CashBalance} RUB");
            Client.BuyAsset(assetEUR,new Quantity(5));
            Client.BuyAsset(assetGOLD, new Quantity(2));
            Client.BuyAsset(assetUSD, new Quantity(2));
            Console.WriteLine($"Баланс карты: {card2.CashBalance} RUB");

            GetPortfelStatistic(portfolio1);
            Client.BuyAsset(assetEUR, new Quantity(5));
            //Console.WriteLine($"Портфель : {portfolio1.GetAssetStatistics()} RUB");
            Console.WriteLine();
            GetPortfelStatistic(portfolio1);
            Console.WriteLine($"Портфель : {portfolio1.GetTotalPortfolioValue()} RUB");
        }
        public static void GetPortfelStatistic(Portfolio portfolio)
        {
            var statistic = portfolio.GetAssetStatistics();
            foreach (var elem in statistic)
            {
                Console.WriteLine($"{elem.AssetType} {elem.Quantity} {elem.TotalValue}");
            }
        }
    }
}