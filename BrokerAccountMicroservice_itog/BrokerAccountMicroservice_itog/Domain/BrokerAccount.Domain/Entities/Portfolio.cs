using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Exceptions;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities
{
    public class Portfolio : Entity<Guid>
    {
        #region Поля

        private readonly Dictionary<Asset, Quantity> _assetHoldings = new();
        #endregion

        #region Свойства

        ///<summary> Получить общую стоимость портфеля. </summary>
        public Money TotalValue => GetTotalPortfolioValue();

        ///<summary> Уникальное имя или код портфеля. </summary>
        public PortfolioNumber PortfolioNumber { get; private set; }

        #endregion

        #region Конструкторы

        protected Portfolio() { }

        public Portfolio(PortfolioNumber code) : base(Guid.NewGuid())
        {
            PortfolioNumber = code ?? throw new ArgumentNullValueException(nameof(code));
        }

        #endregion

        #region Методы

        /// <summary>
        /// Применить транзакцию к портфелю (учитываются только покупка/продажа активов)
        /// </summary>
        /// <param name="transaction"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void ApplyTransaction(Transaction transaction)
        {
            if (transaction.Asset == null) return;

            if (transaction.Type == TransactionType.Purchase)
            {
                if (_assetHoldings.ContainsKey(transaction.Asset))
                    _assetHoldings[transaction.Asset] += transaction.Quantity;
                else
                    _assetHoldings[transaction.Asset] = transaction.Quantity;
            }
            else if (transaction.Type == TransactionType.Sale)
            {
                if (!_assetHoldings.ContainsKey(transaction.Asset) || _assetHoldings[transaction.Asset] < transaction.Quantity)
                    throw new SellingMoreAssetsThanInPortfolioException(transaction.Id, transaction.Asset.AssetType, transaction.Quantity); //Создать исключение при ПРОДАЖИ БОЛЬШЕГО ЧИСЛА АКТИВА, ЧЕМ В ПОРТФЕЛЕ

                _assetHoldings[transaction.Asset] -= transaction.Quantity;

                if (_assetHoldings[transaction.Asset] == 0)
                    _assetHoldings.Remove(transaction.Asset);
            }
        }

        /// <summary>
        /// Получить статистику по активам в портфеле: тип, количество, общая стоимость.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<(AssetType AssetType, Quantity Quantity, Money TotalValue)> GetAssetStatistics()
        {
            var result = new HashSet<(AssetType, Quantity, Money)>();

            foreach (var entry in _assetHoldings)
            {
                var assetType = entry.Key.AssetType;
                var quantity = entry.Value;

                var totalValue = entry.Key.PurchasePrice * quantity;

                result.Add((assetType, quantity, totalValue));
            }

            return result;
        }


        /// <summary>
        /// Получить общую стоимость портфеля
        /// </summary>
        /// <returns></returns>
        public Money GetTotalPortfolioValue()
        {
            Money total = new(0);
            foreach (var stat in GetAssetStatistics())
            {
                total += stat.TotalValue;
            }
            return total;
        }
        #endregion
    }
}
