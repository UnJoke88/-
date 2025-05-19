using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для названия брокерской компании. Хранит строку и проверяет длину.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct BrokerName : ValueObject<string>
    {
        public BrokerName(string value) : base(new BrokerNameValidator(), value) { }
    }
}