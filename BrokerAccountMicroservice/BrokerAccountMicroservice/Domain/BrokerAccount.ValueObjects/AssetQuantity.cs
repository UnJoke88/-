using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для количества актива. Хранит int и проверяет, что значение неотрицательное.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct AssetQuantity : ValueObject<int>
    {
        public AssetQuantity(int value) : base(new AssetQuantityValidator(), value) { }
    }
}
