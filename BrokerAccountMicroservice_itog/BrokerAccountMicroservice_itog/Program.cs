using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Exceptions;
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
            var card3 = new Card(new CardNumber("1111111122222222")); //Указываем номер карты (16 цифр)
            var portfolio1 = new Portfolio(new PortfolioNumber("45345325")); //Указываем номер портфеля (8 цифр)
            var portfolio2 = new Portfolio(new PortfolioNumber("86576434")); //Указываем номер портфеля (8 цифр)

            //Создаём Брокера
            var Broker = new Broker(new BrokerName("jOKER"));

            //Создаём Клиента со всеми данными
            var Client = new Client(new FirstName("Bella"), new LastName("Rin"), new MiddleName("John"), //Чтобы не указывать отчество пропишем null 
                new Email("gggooolll228@mail.ru"), new PhoneNumber("78005553535"), card2, portfolio1);

            var Client2 = new Client(new FirstName("Tim"), new LastName("Reyet"), new MiddleName("Lenon"), //Чтобы не указывать отчество пропишем null 
                new Email("fdssdfdfd@gmail.com"), new PhoneNumber("78222222225"), card3, portfolio2);

            //Добавляем клиентов под контроль брокера
            Broker.AddClient(Client);
            Broker.AddClient(Client2);

            Console.WriteLine($"{Client.Id} {Client.FirstName} " + $"{Client.LastName} {Client.MiddleName} {Client.Email}" +
                $" {Client.PhoneNumber} {Client.Card.CardNumber} {Client.Portfolio.PortfolioNumber}");

            Console.WriteLine($"{Client2.Id} {Client2.FirstName} " + $"{Client2.LastName} {Client2.MiddleName} {Client2.Email}" +
                $" {Client2.PhoneNumber} {Client2.Card.CardNumber} {Client2.Portfolio.PortfolioNumber}");


            Console.WriteLine();

            //Проверка баланса карты
            Console.WriteLine($"Баланс карты: {card2.CashBalance} RUB"); //Баланс карты 0 рублей


            Console.WriteLine();
            Console.WriteLine("==== История операций портфеля ==== ");
            

            Client.MakeDeposit(new Money(1500));//Пополняем карту на 1500 
            //Попробуем снять денег больше 1500
            Client.MakeWithdraw(new Money(2000));


            Console.WriteLine();


            //Активы
            Client.BuyAsset(assetEUR, new Quantity(5)); //Указываем количество актива для покупки
            Client.BuyAsset(assetGOLD, new Quantity(2));
            Client.BuyAsset(assetUSD, new Quantity(2));
            GetPortfelStatistic(portfolio1);//Выводит отчёт в портфеле

            Console.WriteLine();

            //Добавляем ещё 5 евро к имеющимся
            Client.BuyAsset(assetEUR, new Quantity(5)); //Добавляем 5 евро
            GetPortfelStatistic(portfolio1);//Выводит отчёт в портфеле

            Console.WriteLine();


            //Меняем курс евро с 80 на 90 руб 
            Broker.SetPrice(assetEUR, new Money(90)); //Меняем цену евро с 80 на 90 руб
            GetPortfelStatistic(portfolio1);//Выводит отчёт в портфеле

            Console.WriteLine();


            //Продажа 5 евро после повышения курса
            //Client.MakeSale(assetEUR, new Quantity(11));//Продаем 5 евро


            Client2.MakeDeposit(new Money(10000));
            Client2.MakeWithdraw(new Money(4000));
            Client2.MakeDeposit(new Money(10000));

            Client2.BuyAsset(assetGOLD, new Quantity(1));
            Broker.SetPrice(assetGOLD, new Money(12000));
            Client2.MakeSale(assetGOLD, new Quantity(1));


            ShowTransaction(Client); //Выводит сводную информацию по транзакции
            GetPortfelStatistic(portfolio1);//Выводит отчёт в портфеле

            ShowTransaction(Client2); //Выводит сводную информацию по транзакции
            GetPortfelStatistic(portfolio2);//Выводит отчёт в портфеле

            ShowClients(Broker);
            //Broker.AddAsset(assetEUR); //--Создан метод и исключение для более точечной настройки списка активов для брокера (реалезуема при расширении логики с рынком)
            //Broker.AddAsset(assetEUR); - Для вызова ошибки (проверка)

        }

        //Вывод наполнения портфеля
        public static void GetPortfelStatistic(Portfolio portfolio) //В переменную statistic записываем результат метода GetAssetStatistics,
                                                                    //который возвращает словарь включенных значений
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
                if (transaction.Asset == null)
                {
                    Console.WriteLine($"\nИмя клиента: {transaction.Client.FirstName} \nФамилия клиента: {transaction.Client.LastName} " +
                        $"\nВремя транзакции: {transaction.Date} \nТип транзакции: {transaction.Type} \n" +
                        $"Тип актива: Не указан \n Сумма: {transaction.Amount} \nСтатус: {transaction.Status} \nОстаток на балансе: {transaction.EndBalance} RUB \n");
                }
                else
                {
                    Console.WriteLine($"\nИмя клиента: {transaction.Client.FirstName} \nФамилия клиента: {transaction.Client.LastName} \nВремя транзакции: {transaction.Date} \nТип транзакции: {transaction.Type} \n" +
                        $"Тип актива: {transaction.Asset.AssetType.ToString()}\n" +
                        $"Сумма: {transaction.Amount} \nСтатус: {transaction.Status} \nОстаток на балансе: {transaction.EndBalance} RUB \n");
                }

            }
        }

        //Вывод списка клиентов
        public static void ShowClients(Broker broker)
        {
            var Clients = broker.ShowClients;
            foreach (var elem in Clients)
            {
                Console.WriteLine($"\n==== ДАННЫЕ О КЛИЕНТЕ ==== \nИмя:{elem.FirstName} \nФамилия: {elem.LastName} Отчество: {elem.MiddleName} \nПочта: {elem.Email}" +
                    $"\nТелефон: {elem.PhoneNumber} \nНомер карты: {elem.Card.CardNumber} \nБаланс карты: {elem.Card.CashBalance} RUB" +
                    $"\nНомер портфеля: {elem.Portfolio.PortfolioNumber} \nОбщая стоимость портфеля: {elem.Portfolio.TotalValue} RUB \n");
            }
        }
    }
}