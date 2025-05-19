using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для тикера актива. Хранит строку и проверяет допустимость.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct AssetSymbol : ValueObject<string>
    {
        public AssetSymbol(string value) : base(new AssetSymbolValidator(), value) { }
    }
}
