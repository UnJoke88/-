using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.Abstractions
{
    ///<summary>
    ///Интерфейс репозитория для сущности "Клиент".
    ///</summary>
    public interface IClientRepository
    {
        ///<summary>
        ///Получает клиента по идентификатору.
        ///</summary>
        Task<Client?> GetByIdAsync(Guid id);

        ///<summary>
        ///Добавляет нового клиента.
        ///</summary>
        Task AddAsync(Client client);
    }
}