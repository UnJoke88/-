using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Exceptions
{
    public class AddingAnExistingAssetException(BrokerName name, AssetType assetType) 
        : InvalidOperationException($"Тип актива {assetType} Уже существует в списке брокера {name} ")
        //InvalidOperationException - Исключение, которое выдается при вызове метода, недопустимого для текущего состояния объекта.
    {
        public BrokerName Name => name;
        public AssetType AssetType => assetType;
    }
}
