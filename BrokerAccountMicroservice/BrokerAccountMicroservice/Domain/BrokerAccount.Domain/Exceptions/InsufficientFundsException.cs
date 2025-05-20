using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions
{
    ///<summary>
    ///Исключение возникает при попытке снять или использовать сумму, превышающую баланс.
    ///</summary>
    public class InsufficientFundsException : InvalidOperationException
    {
        private readonly decimal _requestedAmount;
        private readonly decimal _availableAmount;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="requestedAmount">Запрошенная сумма.</param>
        ///<param name="availableAmount">Доступная сумма на счёте.</param>
        public InsufficientFundsException(decimal requestedAmount, decimal availableAmount)
            : base($"Недостаточно средств: запрошено {requestedAmount}, доступно {availableAmount}.")
        {
            _requestedAmount = requestedAmount;
            _availableAmount = availableAmount;
        }

        ///<summary>
        ///Запрошенная сумма.
        ///</summary>
        public decimal RequestedAmount => _requestedAmount;

        ///<summary>
        ///Доступная сумма.
        ///</summary>
        public decimal AvailableAmount => _availableAmount;
    }
}
