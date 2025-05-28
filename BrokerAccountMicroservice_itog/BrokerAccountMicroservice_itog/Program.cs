using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

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

            var assetEUR = new Asset(AssetType.EUR, new MinimalUnit(1), new Money(80)); //Указываем цену Eвро за штуку = 80 руб
            var assetGOLD = new Asset(AssetType.GOLD, new MinimalUnit(1), new Money(10000));
            var assetUSD = new Asset(AssetType.USD, new MinimalUnit(1), new Money(60));
            var card2 = new Card(new CardNumber("1111111111111111")); //Указываем номер карты (16 цифр)
            var portfolio1 = new Portfolio(new PortfolioNumber("45345325")); //Указываем номер портфеля (8 цифр)

            //Конструктор для вывода статистики портфеля
            var statistic = portfolio1.GetAssetStatistics(); //В переменную statistic записываем результат метода GetAssetStatistics, который возвращает словарь включенных значений
            foreach (var elem in statistic)
            {
                Console.WriteLine($"{elem.AssetType} {elem.Quantity} {elem.TotalValue}");
            }

            //Создаём клиента со всеми данными
            var Client = new Client(new FirstName("Bella"), new LastName("Rin"), new MiddleName("John"), //Чтобы не указывать отчество пропишем null 
                new Email("gggooolll228@mail.ru"), new PhoneNumber("78005553535"), card2, portfolio1);

            Console.WriteLine($"{Client.Id} {Client.FirstName} " + $"{Client.LastName} {Client.MiddleName} {Client.Email}" +
                $" {Client.PhoneNumber} {Client.Card.CardNumber} {Client.Portfolio.PortfolioNumber}");


            //Проверка баланса карты
            Console.WriteLine($"Баланс карты: {card2.CashBalance} RUB"); //Баланс карты 0 рублей
            Client.MakeDeposit(new Money(1500));//Пополняем карту на 1500 

            Console.WriteLine();


            //Попробуем снять денег больше 1500
            Console.WriteLine("Попробуем снять денег больше 1500 ");
            Client.MakeWithdraw(new Money(2000));
            



            //Активы
            Client.BuyAsset(assetEUR, new Quantity(5)); //Указываем количество актива для покупки
            Client.BuyAsset(assetGOLD, new Quantity(2));
            Client.BuyAsset(assetUSD, new Quantity(2));
            Console.WriteLine($"Баланс карты: {card2.CashBalance} RUB");
            GetPortfelStatistic(portfolio1);

            //Добавляем ещё 5 евро к имеющимся
            Console.WriteLine("Добавляем ещё 5 евро к имеющимся ");
            Client.BuyAsset(assetEUR, new Quantity(5)); //Добавляем 5 евро
            Console.WriteLine();
            GetPortfelStatistic(portfolio1); //Выводим статистику по портфелю
            


            Console.WriteLine();


            Console.WriteLine("Меняем курс евро с 80 на 90 руб ");
            assetEUR.ChangePurchasePrice(new Money(90)); //Меняем цену евро с 80 на 90 руб


            Console.WriteLine("Продажа 5 евро после повышения курса");
            Client.MakeSale(assetEUR, new Quantity(5));//Продаем 5 евро

            GetPortfelStatistic(portfolio1);//Выводит отчёт в портфеле
            ShowTransaction(Client); //Выводит сводную информацию по транзакции

        }

        //Вывод наполнения портфеля
        public static void GetPortfelStatistic(Portfolio portfolio)
        {
            var statistic = portfolio.GetAssetStatistics();
            foreach (var elem in statistic)
            {
                Console.WriteLine($"{elem.AssetType} {elem.Quantity} {elem.TotalValue}");
            }
        }

        //Вывод списка транзакций
        public static void ShowTransaction(Client client) 
        {
            var transactions = client.ShowTransactions;
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Время транзакции: {transaction.Date} \nТип транзакции: {transaction.Type} \n" +
                $"Сумма: {transaction.Amount} \nСтатус: {transaction.Status} \nОстаток на балансе: {transaction.EndBalance} RUB \n");
            }
        }
    }
}