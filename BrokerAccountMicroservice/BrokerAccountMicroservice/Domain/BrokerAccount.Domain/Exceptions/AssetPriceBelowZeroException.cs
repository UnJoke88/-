using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Asset
{
    ///<summary>
    ///Исключение возникает, если цена актива меньше нуля.
    ///</summary>
    public class AssetPriceBelowZeroException : InvalidOperationException
    {
        private readonly decimal _price;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="price">Некорректная цена актива.</param>
        public AssetPriceBelowZeroException(decimal price)
            : base($"Цена актива {price} не может быть меньше нуля.")
        {
            _price = price;
        }

        ///<summary>
        ///Возвращает цену актива, вызвавшую исключение.
        ///</summary>
        public decimal Price => _price;
    }
}

