using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Enums;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Exceptions
{
    public class AddingAnExistingClientException(BrokerName name, Guid clientId, FirstName firstName, LastName lastName, MiddleName middleName)
        : InvalidOperationException($"Клиент {lastName} {firstName} {middleName} с ID {clientId} Уже существует в списке брокера {name} ")
        //InvalidOperationException - Исключение, которое выдается при вызове метода, недопустимого для текущего состояния объекта.
    {
        public BrokerName Name => name;
        public Guid ClientId => clientId;
        public FirstName FirstName => firstName;
        public LastName LastName => lastName;
        public MiddleName MiddleName => middleName;
    }
}
