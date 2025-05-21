using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Enums
{
    ///<summary>
    ///Типы доступных активов в системе.
    ///</summary>
    public enum AssetTypeEnum
    {
        Stock,
        Bond,
        Crypto,
        ETF
    }
}
