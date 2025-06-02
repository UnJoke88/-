using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities
{
    /// <summary>
    /// Вспомогательная сущность для вывода статистики актива в БД
    /// </summary>
    public class PortfolioEntry : Entity<Guid> 
    {
        public Guid AssetId { get; set; }             // Foreign Key
        public Asset Asset { get; set; }              // Навигация

        public Quantity Quantity { get; set; }        // Значение

        public Guid PortfolioId { get; set; }         // Foreign Key
        public Portfolio Portfolio { get; set; }      // Навигация
    }
}