using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities
{
    /// <summary>
    /// Сущность "Актив" — ценная бумага или инструмент в портфеле клиента.
    /// </summary>
    public class Asset : Entity<Guid>
    {
        #region Свойства

        public AssetSymbol Symbol { get; }
        public AssetType Type { get; }
        public AssetQuantity Quantity { get; private set; }
        public MinimalUnit MinimalUnit { get; }
        public PurchasePrice PurchasePrice { get; private set; }
        public CurrentPrice CurrentPrice { get; private set; }
        public Currency Currency { get; }

        #endregion

        #region Конструкторы

        protected Asset(
            Guid id,
            AssetSymbol symbol,
            AssetType type,
            AssetQuantity quantity,
            MinimalUnit minimalUnit,
            PurchasePrice purchasePrice,
            CurrentPrice currentPrice,
            Currency currency
        ) : base(id)
        {
            Symbol = symbol;
            Type = type;
            Quantity = quantity;
            MinimalUnit = minimalUnit;
            PurchasePrice = purchasePrice;
            CurrentPrice = currentPrice;
            Currency = currency;
        }

        public Asset(
            AssetSymbol symbol,
            AssetType type,
            AssetQuantity quantity,
            MinimalUnit minimalUnit,
            PurchasePrice purchasePrice,
            CurrentPrice currentPrice,
            Currency currency
        ) : this(Guid.NewGuid(), symbol, type, quantity, minimalUnit, purchasePrice, currentPrice, currency)
        {
        }

        protected Asset() : base(Guid.NewGuid())
        {
        }

        #endregion

        #region Методы

        public void UpdateCurrentPrice(CurrentPrice newPrice)
        {
            CurrentPrice = newPrice;
        }

        public void UpdatePurchasePrice(PurchasePrice newPrice)
        {
            PurchasePrice = newPrice;
        }

        public void ChangeQuantity(AssetQuantity newQuantity)
        {
            Quantity = newQuantity;
        }

        #endregion
    }
}
