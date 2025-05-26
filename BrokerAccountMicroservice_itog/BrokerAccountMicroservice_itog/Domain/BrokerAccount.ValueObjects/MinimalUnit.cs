using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Объект-значение для минимальной единицы покупки. Хранит decimal и проверяет, что значение > 0 и <= 1.
namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects
{
    /// <summary>
    /// Минимальная единица покупки актива.
    /// </summary>
    public class MinimalUnit(int value)
        : ValueObject<int>(new MinimalUnitValidator(), value)
    {
    
    }
}
