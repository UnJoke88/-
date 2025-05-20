using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Asset
{
    ///<summary>
    ///Исключение возникает, если актив с указанным идентификатором не найден.
    ///</summary>
    public class AssetNotFoundException : InvalidOperationException
    {
        private readonly Guid _assetId;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="assetId">Идентификатор не найденного актива.</param>
        public AssetNotFoundException(Guid assetId)
            : base($"Актив с идентификатором {assetId} не найден.")
        {
            _assetId = assetId;
        }

        ///<summary>
        ///Возвращает идентификатор актива, вызвавшего исключение.
        ///</summary>
        public Guid AssetId => _assetId;
    }
}

1