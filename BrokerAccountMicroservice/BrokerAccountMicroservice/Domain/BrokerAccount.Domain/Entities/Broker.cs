using BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAccountMicroservice.Domain.BrokerAccount.Domain.Entities
{
    /// <summary>
    /// Сущность "Клиент" — инвестор, владеющий брокерским счётом.
    /// </summary>
    public class Client : Entity<Guid>
    {
        #region Свойства
        public FirstName FirstName { get; }
        public LastName LastName { get; }
        public MiddleName? MiddleName { get; }
        public Email Email { get; }
        public PhoneNumber PhoneNumber { get; }
        public DateTime RegistrationDate { get; private set; }
        public BrokerAccount Account { get; private set; }
        #endregion

        #region Основной конструктор
        // Используется внутри и для создания через public-конструктор
        protected Client(
            Guid id,
            FirstName firstName,
            LastName lastName,
            MiddleName? middleName,
            Email email,
            PhoneNumber phoneNumber,
            DateTime registrationDate
        ) : base(id)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            MiddleName = middleName;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            RegistrationDate = registrationDate;
        }
        #endregion

        #region Публичный конструктор
        // Упрощённый вызов — Guid генерируется автоматически
        public Client(
            FirstName firstName,
            LastName lastName,
            MiddleName? middleName,
            Email email,
            PhoneNumber phoneNumber,
            DateTime registrationDate
        ) : this(Guid.NewGuid(), firstName, lastName, middleName, email, phoneNumber, registrationDate)
        {
        }
        #endregion

        #region Конструктор для ORM
        // Используется Entity Framework при загрузке сущности из БД
        protected Client() : base(Guid.NewGuid())
        {
        }
        #endregion
    }
    


}
