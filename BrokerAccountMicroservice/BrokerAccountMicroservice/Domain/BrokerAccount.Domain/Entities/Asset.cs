using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Asset;
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

        ///<summary>
        ///Обновляет текущую рыночную цену актива.
        ///</summary>
        ///<param name="newPrice">Новая цена.</param>
        public void UpdatePrice(CurrentPrice newPrice)
        {
            if (newPrice == null || newPrice.Value < 0)
                throw new AssetPriceBelowZeroException(newPrice?.Value ?? 0);

            CurrentPrice = newPrice;
        }

        ///<summary>
        ///Обновляет цену покупки.
        ///</summary>
        ///<param name="newPrice">Цена покупки при сделке.</param>
        public void UpdatePurchasePrice(PurchasePrice newPrice)
        {
            if (newPrice == null || newPrice.Value < 0)
                throw new AssetPriceBelowZeroException(newPrice?.Value ?? 0);

            PurchasePrice = newPrice;
        }

        ///<summary>
        ///Устанавливает новое количество актива.
        ///</summary>
        ///<param name="newQuantity">Обновлённое количество.</param>
        public void ChangeQuantity(AssetQuantity newQuantity)
        {
            if (newQuantity == null || newQuantity.Value <= 0)
                throw new AssetQuantityOutOfRangeException(newQuantity?.Value ?? 0);

            Quantity = newQuantity;
        }

        ///<summary>
        ///Рассчитывает текущую стоимость актива.
        ///</summary>
        ///<returns>Произведение количества на текущую цену.</returns>
        public decimal GetTotalValue()
        {
            return CurrentPrice.Value * Quantity.Value;
        }

        ///<summary>
        ///Возвращает строковое описание актива.
        ///</summary>
        ///<returns>Например: "AAPL (Stock) × 5".</returns>
        public string GetAssetDetails()
        {
            return $"{Symbol.Value} ({Type}) × {Quantity.Value}";
        }

        #endregion
    }
}
