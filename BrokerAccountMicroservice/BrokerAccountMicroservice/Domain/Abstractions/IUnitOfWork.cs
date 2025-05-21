using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.Abstractions
{
    ///<summary>
    ///Интерфейс для управления операциями транзакции.
    ///</summary>
    public interface IUnitOfWork
    {
        ///<summary>
        ///Фиксирует изменения.
        ///</summary>
        Task CommitAsync();

        ///<summary>
        ///Откатывает изменения.
        ///</summary>
        Task RollbackAsync();
    }
}