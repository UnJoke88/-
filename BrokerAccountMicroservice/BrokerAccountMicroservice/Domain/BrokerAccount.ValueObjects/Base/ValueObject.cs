using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Exceptions;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.ValueObjects.Base
{
    /// <summary>
    /// Абстрактный базовый класс для объектов-значений с поддержкой валидации и сравнения.
    /// </summary>
    /// <typeparam name="T">Тип значения</typeparam>
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
    {
        //Хранит фактическое значение объекта (например, строку email или число суммы)
        public T Value { get; }

        //Конструктор принимает валидатор и значение. Валидатор проверяет корректность.
        protected ValueObject(IValidator<T> validator, T value)
        {
            if (validator == null)
                throw new DomainValidationException("Validator must not be null");

            validator.Validate(value);
            Value = value;
        }

        //Преобразует значение в строку
        public override string ToString() => Value?.ToString() ?? string.Empty;

        //Возвращает хеш-код, основанный на значении.
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;

        //Сравнивает объект с другим, если тот тоже ValueObject с таким же значением
        public override bool Equals(object? other) => Equals(other as ValueObject<T>);

        //Сравнивает два объекта-значения по внутреннему содержимому
        public bool Equals(ValueObject<T>? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;
            return Equals(Value, other.Value);
        }

        //Перегрузка оператора "==" для сравнения по значению
        public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right) => Equals(left, right);
        //Перегрузка оператора "!=" для сравнения по значению
        public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right) => !Equals(left, right);
    }
}
