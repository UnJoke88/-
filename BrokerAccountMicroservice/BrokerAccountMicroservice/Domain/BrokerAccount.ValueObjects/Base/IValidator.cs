using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base
{
    /// <summary>
    /// Интерфейс валидатора объекта-значения.
    /// </summary>
    /// <typeparam name="T">Тип проверяемого значения.</typeparam>
    public interface IValidator<T>
    {
        /// <summary>
        /// Метод валидации значения.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        void Validate(T value);
    }
}
