using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions
{
    ///<summary>
    ///Исключение возникает при попытке выполнить операцию на неактивном счёте.
    ///</summary>
    public class AccountNotActiveException : InvalidOperationException
    {
        private readonly Guid _accountId;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="accountId">Идентификатор счёта.</param>
        public AccountNotActiveException(Guid accountId)
            : base($"Счёт с идентификатором {accountId} не активен для выполнения операции.")
        {
            _accountId = accountId;
        }

        ///<summary>
        ///Возвращает идентификатор счёта, вызвавшего исключение.
        ///</summary>
        public Guid AccountId => _accountId;
    }
}
