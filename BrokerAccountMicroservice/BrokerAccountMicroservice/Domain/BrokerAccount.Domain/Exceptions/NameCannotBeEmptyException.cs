using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Client
{
    ///<summary>
    ///Исключение возникает, если имя или фамилия пусты или содержат только пробелы.
    ///</summary>
    public class NameCannotBeEmptyException : InvalidOperationException
    {
        private readonly string _propertyName;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="propertyName">Имя свойства (FirstName, LastName и т.п.).</param>
        public NameCannotBeEmptyException(string propertyName)
            : base($"Свойство '{propertyName}' не может быть пустым.")
        {
            _propertyName = propertyName;
        }

        ///<summary>
        ///Возвращает имя свойства, вызвавшего исключение.
        ///</summary>
        public string PropertyName => _propertyName;
    }
}
