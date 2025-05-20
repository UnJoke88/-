using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions
{
    ///<summary>
    ///Исключение возникает при попытке совершить операцию со счётом, который закрыт.
    ///</summary>
    public class AccountClosedException : InvalidOperationException
    {
        private readonly Guid _accountId;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="accountId">Идентификатор закрытого счёта.</param>
        public AccountClosedException(Guid accountId)
            : base($"Счёт с ID {accountId} закрыт и не может быть использован для операций.")
        {
            _accountId = accountId;
        }

        ///<summary>
        ///Возвращает идентификатор закрытого счёта.
        ///</summary>
        public Guid AccountId => _accountId;
    }
}

