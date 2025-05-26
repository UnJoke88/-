using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities
{
    public class Asset : Entity<Guid>
    {

        #region Свойства

        /// <summary>
        /// Тип актива
        /// </summary>
        public AssetType AssetType { get; }

        /// <summary>
        /// Минимальная единица покупки (например от 1).
        /// </summary>
        public MinimalUnit MinimalUnit { get; }

        /// <summary>
        /// Минимальная цена покупки за единицу
        /// </summary>
        public Money PurchasePrice { get; private set; }

        #endregion

        #region Конструктор
        
        protected Asset() 
        {
            
        }

        protected Asset(Guid id, AssetType assetType, MinimalUnit minimalUnit, Money purchasePrice)
            : base(id)
        {
            AssetType = assetType;
            MinimalUnit = minimalUnit ?? throw new ArgumentNullValueException(nameof(minimalUnit));
            PurchasePrice = purchasePrice ?? throw new ArgumentNullValueException(nameof(purchasePrice));
        }

        public Asset(AssetType assetType, MinimalUnit minimalUnit, Money purchasePrice)
            : this(Guid.NewGuid(), assetType, minimalUnit, purchasePrice) 
        { 
        
        }

        #endregion
    }
}
