using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Infrastructure.BrokerAccount.Infrastructure.EntityFramework.Configurations
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(x => x.Id); // Устанавливает первичный ключ
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.PortfolioNumber).IsRequired()
                .HasConversion(v => v.Value,v => new PortfolioNumber(v)); // Конвертация ValueObject

            // Игнорируем вычисляемое свойство общей стоимости портфеля (не хранится в БД)
            builder.Ignore(x => x.TotalValue);

            // Игнорируем метод GetAssetStatistics() — EF не должен пытаться сопоставить его
            builder.Ignore(x => x.GetAssetStatistics);

            // Игнорируем метод GetTotalPortfolioValue() — это логика на уровне домена
            builder.Ignore(x => x.GetTotalPortfolioValue);

            // Внутренний словарь _assetHoldings не настраивается как навигация
        }
    }
}
