using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions
{
    ///<summary>
    ///Исключение возникает при попытке совершить операцию со счётом, который находится в статусе "заморожен".
    ///</summary>
    public class AccountFrozenException : InvalidOperationException
    {
        private readonly Guid _accountId;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="accountId">Идентификатор заблокированного счёта.</param>
        public AccountFrozenException(Guid accountId)
            : base($"Счёт с ID {accountId} заблокирован и не может быть использован для операций.")
        {
            _accountId = accountId;
        }

        ///<summary>
        ///Возвращает идентификатор заблокированного счёта.
        ///</summary>
        public Guid AccountId => _accountId;
    }
}

