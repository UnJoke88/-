using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccountMicroservice_itog.Infrastructure.BrokerAccount.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BrokerAccountMicroservice_itog

{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Добавляем данные сервера и БД
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BrokerDB;Username=postgres;Password=dusha2005");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
