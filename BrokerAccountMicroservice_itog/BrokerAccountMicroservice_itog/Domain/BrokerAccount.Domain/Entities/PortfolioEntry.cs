using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities
{
    public class PortfolioEntry : Entity<Guid>
    {
        public Asset Asset { get; set; }
        public Guid AssetId { get; set; }

        public Quantity Quantity { get; set; }

        public Portfolio Portfolio { get; set; }
        public Guid PortfolioId { get; set; }
    }
}