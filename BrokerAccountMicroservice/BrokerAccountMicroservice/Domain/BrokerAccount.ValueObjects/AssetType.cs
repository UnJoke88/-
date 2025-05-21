using System;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Enums;
using BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    ///<summary>
    ///ValueObject, представляющий тип актива, основанный на перечислении.
    ///</summary>
    public class AssetType : ValueObject<AssetType>
    {
        public AssetType(AssetType value) : base(value) { }

        ///<summary>
        ///Создаёт тип актива из строки.
        ///</summary>
        ///<param name="type">Строковое значение типа.</param>
        ///<returns>Объект AssetType.</returns>
        ///<exception cref="InvalidAssetTypeException">Если значение не входит в допустимый enum.</exception>
        public static AssetType FromString(string type)
        {
            if (!Enum.TryParse<AssetType>(type, true, out var parsed))
                throw new InvalidAssetTypeException(nameof(type), type);

            return new AssetType(parsed);
        }

        public override string ToString() => Value.ToString();
    }
}