using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Portfolio
{
    ///<summary>
    ///Исключение возникает при попытке добавить в портфель актив, который уже существует.
    ///</summary>
    public class AssetAlreadyExistsException : InvalidOperationException
    {
        private readonly Guid _assetId;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="assetId">Идентификатор дублирующегося актива.</param>
        public AssetAlreadyExistsException(Guid assetId)
            : base($"Актив с идентификатором {assetId} уже присутствует в портфеле.")
        {
            _assetId = assetId;
        }

        ///<summary>
        ///Возвращает идентификатор актива, вызвавшего исключение.
        ///</summary>
        public Guid AssetId => _assetId;
    }
}

