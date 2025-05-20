using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Common
{
    ///<summary>
    ///Универсальное исключение, возникает при отсутствии сущности по идентификатору.
    ///</summary>
    public class EntityNotFoundException : InvalidOperationException
    {
        private readonly Guid _entityId;
        private readonly string _entityName;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="entityId">Идентификатор сущности.</param>
        ///<param name="entityName">Имя сущности.</param>
        public EntityNotFoundException(Guid entityId, string entityName)
            : base($"Сущность '{entityName}' с идентификатором {entityId} не найдена.")
        {
            _entityId = entityId;
            _entityName = entityName;
        }

        ///<summary>
        ///Возвращает идентификатор сущности, вызвавшей исключение.
        ///</summary>
        public Guid EntityId => _entityId;

        ///<summary>
        ///Возвращает имя сущности.
        ///</summary>
        public string EntityName => _entityName;
    }
}

