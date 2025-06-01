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
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.Id); // Устанавливает первичный ключ
            builder.Property(x => x.Id).ValueGeneratedOnAdd(); 

            builder.Property(x => x.CardNumber).IsRequired()
                .HasConversion(number => number.Value,value => new CardNumber(value)); 

            builder.Property(x => x.CashBalance).IsRequired()
                .HasConversion(balance => balance.Value,value => new Money(value));
        } 
    }
}
