using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для отчества клиента. Хранит строку и проверяет её при наличии.
namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects
{
    public readonly record struct MiddleName : ValueObject<string?>
    {
        public MiddleName(string? value) : base(new MiddleNameValidator(), value) { }
    }
}