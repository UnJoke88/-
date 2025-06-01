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
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(x => x.Id); // Устанавливает первичный ключ
            builder.Property(x => x.Id).ValueGeneratedOnAdd(); // Property - поле в таблице

            builder.Property(x => x.AssetType).IsRequired();

            builder.Property(x => x.MinimalUnit).IsRequired()
                .HasConversion(unit => unit.Value, value => new MinimalUnit(value));

            builder.Property(x => x.PurchasePrice).IsRequired()
                .HasConversion(price => price.Value,value => new Money(value));

            //Подключаем владелеца актива Broker и этот актив содержится в списке брокера
            builder.HasOne(x => x.Broker).WithMany("_asset");

            //Пример автозагрузки навигации (автоматически добавит a => a.Broker даже если он не указал явно)
            builder.Navigation(x => x.Broker).AutoInclude();
        }
    }
}
