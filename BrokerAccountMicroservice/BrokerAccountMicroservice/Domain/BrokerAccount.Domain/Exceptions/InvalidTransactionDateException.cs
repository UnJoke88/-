using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Exceptions.Transaction
{
    ///<summary>
    ///Исключение возникает при попытке задать дату транзакции в будущем.
    ///</summary>
    public class InvalidTransactionDateException : InvalidOperationException
    {
        private readonly DateTime _date;

        ///<summary>
        ///Конструктор исключения.
        ///</summary>
        ///<param name="date">Некорректная дата транзакции.</param>
        public InvalidTransactionDateException(DateTime date)
            : base($"Дата транзакции {date} не может быть в будущем.")
        {
            _date = date;
        }

        ///<summary>
        ///Возвращает некорректную дату транзакции.
        ///</summary>
        public DateTime Date => _date;
    }
}

