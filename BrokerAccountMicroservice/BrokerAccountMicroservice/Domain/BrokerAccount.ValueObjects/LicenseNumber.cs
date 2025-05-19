using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для номера лицензии брокера. Хранит строку и проверяет формат.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct LicenseNumber : ValueObject<string>
    {
        public LicenseNumber(string value) : base(new LicenseNumberValidator(), value) { }
    }
}
