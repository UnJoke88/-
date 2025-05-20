using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions
{
    ///<summary>
    ///Исключение возникает, если пытаются заблокировать (заморозить) сумму, превышающую доступный для операций баланс.
    ///</summary>
    public class PendingExceedsBalanceException : InvalidOperationException
    {
        private readonly decimal _requestedAmount;
        private readonly decimal _availableBalance;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="requestedAmount">Запрошенная сумма для блокировки.</param>
        ///<param name="availableBalance">Доступный баланс.</param>
        public PendingExceedsBalanceException(decimal requestedAmount, decimal availableBalance)
            : base($"Запрошенная сумма {requestedAmount} превышает доступный баланс {availableBalance}.")
        {
            _requestedAmount = requestedAmount;
            _availableBalance = availableBalance;
        }

        ///<summary>
        ///Запрошенная сумма для блокировки.
        ///</summary>
        public decimal RequestedAmount => _requestedAmount;

        ///<summary>
        ///Доступный баланс.
        ///</summary>
        public decimal AvailableBalance => _availableBalance;
    }
}

