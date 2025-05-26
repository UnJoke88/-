using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions
{
    ///<summary>
    ///Исключение, возникающее при слишком длинном имени.
    ///</summary>
    ///<param name="paramName">Имя параметра.</param>
    ///<param name="name">Слишком длинное имя.</param>
    internal class FirstNameTooLongException(string paramName, string name)
        : FormatException($"Имя превышает допустимую длину: \"{name}\".", paramName)
    {
        public string Name => name;
    }
}
