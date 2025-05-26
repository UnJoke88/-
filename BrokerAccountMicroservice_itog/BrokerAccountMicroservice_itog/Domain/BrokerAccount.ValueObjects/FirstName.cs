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
    /// <summary>
    /// Представляет тип имени сущности (покупателя, администратора и т. д.).
    /// </summary>
    /// <param name="name">Имя сущности.</param>
    public class FirstName(string name) 
        : ValueObject<string>(new FirstNameValidator(), name); // Наследование от базовой сущности. При создании объекта класса, проверяем(валидируем) его 

}
