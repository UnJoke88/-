using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions
{
    ///<summary>
    ///Исключение возникает, если сумма для пополнения или списания отрицательная.
    ///</summary>
    public class NegativeCashAmountException : InvalidOperationException
    {
        private readonly decimal _amount;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="amount">Отрицательная сумма.</param>
        public NegativeCashAmountException(decimal amount)
            : base($"Сумма {amount} не может быть отрицательной.")
        {
            _amount = amount;
        }

        ///<summary>
        ///Возвращает сумму, вызвавшую исключение.
        ///</summary>
        public decimal Amount => _amount;
    }
}

