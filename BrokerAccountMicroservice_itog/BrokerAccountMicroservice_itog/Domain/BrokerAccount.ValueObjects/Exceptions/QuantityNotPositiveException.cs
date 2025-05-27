using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    /// Проверка диапазона значения минимальной единицы.
    ///</summary>
    internal class QuantityNotPositiveException(int value)
        : ArgumentOutOfRangeException(nameof(value), value, "Количество не может быть меньше 0.")
    {
        public int Value => value;
    }
}
