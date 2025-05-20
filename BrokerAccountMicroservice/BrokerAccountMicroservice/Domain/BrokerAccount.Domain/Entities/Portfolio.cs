using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Asset;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities
{
    /// <summary>
    /// Сущность "Портфель" — содержит инвестиционные активы клиента.
    /// </summary>
    public class Portfolio : Entity<Guid>
    {
        #region Поля

        private readonly ICollection<Asset> _assets = new List<Asset>();

        #endregion

        #region Свойства

        public IReadOnlyCollection<Asset> Assets => _assets.ToList().AsReadOnly();

        public PortfolioValue TotalValue => new PortfolioValue(_assets.Sum(a => a.CurrentPrice.Value * a.Quantity.Value));

        #endregion

        #region Конструкторы

        protected Portfolio(Guid id) : base(id)
        {
        }

        public Portfolio() : base(Guid.NewGuid())
        {
        }

        #endregion

        #region Методы

        ///<summary>
        ///Добавляет актив в портфель.
        ///</summary>
        ///<param name="asset">Актив для добавления.</param>
        public void AddAsset(Asset asset)
        {
            if (_assets.Any(a => a.Id == asset.Id))
                throw new AssetAlreadyExistsException(asset.Id);

            _assets.Add(asset);
        }

        ///<summary>
        ///Удаляет актив из портфеля по идентификатору.
        ///</summary>
        ///<param name="assetId">Идентификатор актива.</param>
        public void RemoveAsset(Guid assetId)
        {
            var asset = _assets.FirstOrDefault(a => a.Id == assetId);
            if (asset == null)
                throw new AssetNotFoundException(assetId);

            _assets.Remove(asset);
        }

        ///<summary>
        ///Обновляет цену актива в портфеле.
        ///</summary>
        ///<param name="assetId">Идентификатор актива.</param>
        ///<param name="newPrice">Новая рыночная цена.</param>
        public void UpdateAssetPrice(Guid assetId, CurrentPrice newPrice)
        {
            if (newPrice == null || newPrice.Value < 0)
                throw new AssetPriceBelowZeroException(newPrice?.Value ?? 0);

            var asset = _assets.FirstOrDefault(a => a.Id == assetId);
            if (asset == null)
                throw new AssetNotFoundException(assetId);

            asset.UpdatePrice(newPrice);
        }

        ///<summary>
        ///Обновляет количество для конкретного актива.
        ///</summary>
        ///<param name="assetId">Идентификатор актива.</param>
        ///<param name="newQuantity">Новое количество.</param>
        public void ChangeAssetQuantity(Guid assetId, AssetQuantity newQuantity)
        {
            if (newQuantity == null || newQuantity.Value <= 0)
                throw new AssetQuantityOutOfRangeException(newQuantity?.Value ?? 0);

            var asset = _assets.FirstOrDefault(a => a.Id == assetId);
            if (asset == null)
                throw new AssetNotFoundException(assetId);

            asset.ChangeQuantity(newQuantity);
        }

        ///<summary>
        ///Обновляет цену покупки для конкретного актива.
        ///</summary>
        ///<param name="assetId">Идентификатор актива.</param>
        ///<param name="newPrice">Новая цена покупки.</param>
        public void UpdateAssetPurchasePrice(Guid assetId, PurchasePrice newPrice)
        {
            if (newPrice == null || newPrice.Value < 0)
                throw new AssetPriceBelowZeroException(newPrice?.Value ?? 0);

            var asset = _assets.FirstOrDefault(a => a.Id == assetId);
            if (asset == null)
                throw new AssetNotFoundException(assetId);

            asset.UpdatePurchasePrice(newPrice);
        }

        ///<summary>
        ///Рассчитывает общую стоимость всех активов в портфеле.
        ///</summary>
        ///<returns>Суммарная стоимость портфеля.</returns>
        public PortfolioValue TotalValue
        {
            get
            {
                var total = _assets.Sum(a => a.GetTotalValue());
                return new PortfolioValue(total);
            }
        }

        ///<summary>
        ///Возвращает копию всех активов в портфеле.
        ///</summary>
        ///<returns>Список активов клиента.</returns>
        public IReadOnlyCollection<Asset> GetAssets()
        {
            return _assets.ToList().AsReadOnly();
        }

        #endregion
    }
}
