using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums
{
    /// <summary>
    /// Тип транзакции
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Снятие
        /// </summary>
        Removing,

        /// <summary>
        /// Пополнение
        /// </summary>
        Replenishment,

        /// <summary>
        /// Продажа
        /// </summary>
        Sale, 

        /// <summary>
        /// Покупка
        /// </summary>
        Purchase
    }
}
