using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Portfolio
{
    ///<summary>
    ///Исключение возникает при попытке изменить или продать актив, который не принадлежит клиенту.
    ///</summary>
    public class AssetNotOwnedException : InvalidOperationException
    {
        private readonly Guid _assetId;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="assetId">Идентификатор актива.</param>
        public AssetNotOwnedException(Guid assetId)
            : base($"Актив с идентификатором {assetId} не принадлежит портфелю.")
        {
            _assetId = assetId;
        }

        ///<summary>
        ///Возвращает идентификатор актива, вызвавшего исключение.
        ///</summary>
        public Guid AssetId => _assetId;
    }
}
