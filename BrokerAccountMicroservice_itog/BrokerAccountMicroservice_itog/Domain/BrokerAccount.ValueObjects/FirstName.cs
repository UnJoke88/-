using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для имени клиента. Хранит строку и проверяет её через валидатор.
namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects
{
    public class FirstName : ValueObject<string>
    {
        public FirstName(string value) : base(new FirstNameValidator(), value) { }
    }
}
