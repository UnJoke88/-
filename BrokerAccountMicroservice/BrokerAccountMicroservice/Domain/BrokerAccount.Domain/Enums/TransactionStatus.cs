using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Enums
{
    /// <summary>
    /// Статус транзакции
    /// </summary>
    public enum TransactionStatus
    {
        /// <summary>
        /// Транзакция в процессе обработки
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Транзакция успешно завершена
        /// </summary>
        Completed = 1,

        /// <summary>
        /// Транзакция не удалась (ошибка, отмена и т.д.)
        /// </summary>
        Failed = 2
    }
}

