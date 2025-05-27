using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    /// Проверка формата номера карты.
    ///</summary>
    internal class PortfolioNumberFormatException(string paramName, string portfolioNumber)
        : ArgumentException($"Номер портфеля имеет недопустимый формат: \"{portfolioNumber}\".", paramName)
    {
        public string PortfolioNumber => portfolioNumber;
    }
}
