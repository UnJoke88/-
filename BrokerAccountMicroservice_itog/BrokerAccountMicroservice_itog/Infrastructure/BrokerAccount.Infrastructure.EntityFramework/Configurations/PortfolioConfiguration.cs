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
            builder.HasKey(x => x.Id); // PK
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.PortfolioNumber).IsRequired()
                .HasConversion(v => v.Value,v => new PortfolioNumber(v)); 

            builder.HasMany<PortfolioEntry>("_entries").WithOne(x => x.Portfolio)
                .HasForeignKey(x => x.PortfolioId)
                .IsRequired(); // связь с PortfolioEntry

            builder.Ignore(x => x.AssetEntries); // геттер, не нужно мапить
            builder.Ignore(x => x.TotalValue);   // вычисляется по ходу
        }
    }
}
