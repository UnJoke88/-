using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Client
{
    ///<summary>
    ///Исключение возникает при попытке получить или изменить несуществующего клиента.
    ///</summary>
    public class ClientNotFoundException : InvalidOperationException
    {
        private readonly Guid _clientId;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="clientId">Идентификатор клиента.</param>
        public ClientNotFoundException(Guid clientId)
            : base($"Клиент с идентификатором {clientId} не найден.")
        {
            _clientId = clientId;
        }

        ///<summary>
        ///Возвращает идентификатор клиента, вызвавшего исключение.
        ///</summary>
        public Guid ClientId => _clientId;
    }
}
