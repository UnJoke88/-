using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions
{
    ///<summary>
    ///Исключение возникает при установке некорректной ставки комиссии (меньше 0 или больше 1).
    ///</summary>
    public class InvalidCommissionRateException : InvalidOperationException
    {
        private readonly decimal _rate;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="rate">Некорректная ставка комиссии.</param>
        public InvalidCommissionRateException(decimal rate)
            : base($"Ставка комиссии {rate} некорректна. Допустимый диапазон: от 0 до 1.")
        {
            _rate = rate;
        }

        ///<summary>
        ///Возвращает некорректную ставку комиссии.
        ///</summary>
        public decimal Rate => _rate;
    }
}
1