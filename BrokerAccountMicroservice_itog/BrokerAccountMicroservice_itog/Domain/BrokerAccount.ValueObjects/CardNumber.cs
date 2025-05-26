using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects
{
    ///<summary>
    ///Объект-значение для номера карты клиента. Хранит строку и проверяет формат.
    ///</summary>
    public class CardNumber : ValueObject<string>
    {
        public CardNumber(string value) : base(new CardNumberValidator(), value) 
        {
        
        }
    }
}

