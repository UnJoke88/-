using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при отрицательном значении комиссии за транзакцию.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="fee">Недопустимая комиссия.</param>
    internal class TransactionFeeNegativeException(string paramName, decimal fee)
        : ArgumentException($"Комиссия за транзакцию не может быть отрицательной: {fee}.", paramName)
    {
        public decimal Fee => fee;
    }
}
