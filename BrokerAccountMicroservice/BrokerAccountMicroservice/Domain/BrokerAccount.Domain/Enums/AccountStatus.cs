using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Статус брокерского счёта
/// </summary>
namespace BrokerAccountMicroservice.Domain.BrokerAccount.Enums
{
    public enum AccountStatus
    {
        /// <summary>
        /// Счёт активен и доступен для операций
        /// </summary>
        Active = 0,

        /// <summary>
        /// Счёт временно заморожен (например, по требованию безопасности)
        /// </summary>
        Frozen = 1,

        /// <summary>
        /// Счёт закрыт и недоступен для использования
        /// </summary>
        Closed = 2
    }
}
