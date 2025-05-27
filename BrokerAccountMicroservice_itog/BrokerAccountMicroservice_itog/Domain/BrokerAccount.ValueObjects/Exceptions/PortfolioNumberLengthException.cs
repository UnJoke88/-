using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    internal class PortfolioNumberLengthException(string portfolioNumber, int length)
            : FormatException($"Длина имени портфеля под номером {portfolioNumber} не равна допустимой длине {length}")
    {
        public string PortfolioNumber => portfolioNumber;
        public int Length => length;
    }
}
