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
    public class BrokerConfiguration : IEntityTypeConfiguration<Broker>
    {
        public void Configure(EntityTypeBuilder<Broker> builder)
        {
            builder.HasKey(x => x.Id); // Устанавливает первичный ключ
            builder.Property(x => x.Id).ValueGeneratedOnAdd(); //Свойство Id будет автоматически генерироваться базой данных
                                                               //при добавлении новой записи.

            builder.Property(x => x.Name).IsRequired()
                .HasConversion(name => name.Value, value => new BrokerName(value)); // Конвертация ValueObject

            // Настраиваем связь с клиентами. У брокера коллекция _client, у клиента пока нет ссылки на брокера
            builder.HasMany<Client>("_client").WithOne();

            // Настраиваем связь с активами. У брокера коллекция _asset, у актива есть свойство Broker
            builder.HasMany<Asset>("_asset").WithOne(x => x.Broker);

            //Не учитывать это свойство при построении таблицы в базе данных (Не создавать для него колонку или навигацию).
            builder.Ignore(x => x.ShowClients);
            builder.Ignore(x => x.ShowAsset);

           
            builder.Navigation("Clients").AutoInclude();
            builder.Navigation("Assets").AutoInclude();
        }
    }
}
