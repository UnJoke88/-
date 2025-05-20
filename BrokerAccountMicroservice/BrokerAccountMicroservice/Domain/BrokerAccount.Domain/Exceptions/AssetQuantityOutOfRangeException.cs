using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Asset
{
    ///<summary>
    ///Исключение возникает, если количество актива меньше или равно нулю.
    ///</summary>
    public class AssetQuantityOutOfRangeException : InvalidOperationException
    {
        private readonly decimal _quantity;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="quantity">Некорректное количество актива.</param>
        public AssetQuantityOutOfRangeException(decimal quantity)
            : base($"Количество актива {quantity} должно быть больше нуля.")
        {
            _quantity = quantity;
        }

        ///<summary>
        ///Возвращает количество актива, вызвавшее исключение.
        ///</summary>
        public decimal Quantity => _quantity;
    }
}

