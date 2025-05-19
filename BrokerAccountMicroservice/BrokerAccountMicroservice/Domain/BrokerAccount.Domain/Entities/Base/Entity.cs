using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities.Base
{
    /// <summary>
    /// Базовая сущность для всех доменных объектов с уникальным идентификатором.
    /// </summary>
    public abstract class Entity<TId>(TId id)
    {
        // Идентификатор сущности
        public TId Id { get; protected set; } = id;
    }

}
