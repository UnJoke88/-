using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для типа актива. Хранит строку и проверяет её на допустимые значения.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct AssetType : ValueObject<string>
    {
        public AssetType(string value) : base(new AssetTypeValidator(), value) { }
    }
}
