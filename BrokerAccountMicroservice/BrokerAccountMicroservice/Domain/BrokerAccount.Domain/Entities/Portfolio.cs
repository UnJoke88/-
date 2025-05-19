using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddAsset(Asset asset)
        {
            _assets.Add(asset);
        }

        public void RemoveAsset(Guid assetId)
        {
            var asset = _assets.FirstOrDefault(a => a.Id == assetId);
            if (asset != null)
                _assets.Remove(asset);
        }

        public void Clear()
        {
            _assets.Clear();
        }

        #endregion
    }

}
