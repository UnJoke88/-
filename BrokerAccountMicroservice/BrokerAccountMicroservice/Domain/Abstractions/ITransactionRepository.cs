using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.Abstractions
{
    ///<summary>
    ///Интерфейс репозитория для работы с транзакциями.
    ///</summary>
    public interface ITransactionRepository
    {
        ///<summary>
        ///Возвращает транзакции по счёту.
        ///</summary>
        Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId);

        ///<summary>
        ///Добавляет транзакцию.
        ///</summary>
        Task AddAsync(Transaction transaction);
    }
}
