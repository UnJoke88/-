using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.Abstractions
{
    ///<summary>
    ///Интерфейс репозитория для агрегата "Брокерский счёт".
    ///</summary>
    public interface IBrokerAccountRepository
    {
        ///<summary>
        ///Получает счёт по его идентификатору.
        ///</summary>
        Task<BrokerAccount?> GetByIdAsync(Guid id);

        ///<summary>
        ///Добавляет новый счёт.
        ///</summary>
        Task AddAsync(BrokerAccount account);

        ///<summary>
        ///Обновляет существующий счёт.
        ///</summary>
        Task UpdateAsync(BrokerAccount account);
    }
}
