using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities
{
    public class Broker : Entity<Guid>
    {
        #region Свойства

        public BrokerName Name { get; }

        private readonly ICollection<Client> _client = [];

        #endregion

        #region Конструктор

        protected Broker()
        {

        }

        protected Broker(Guid id, BrokerName name)
            : base(id)
        {
            Name = name ?? throw new ArgumentNullValueException(nameof(name));
        }

        public Broker(BrokerName name)
           : this(Guid.NewGuid(), name)
        {

        }
        #endregion

    }
}
