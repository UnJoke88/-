using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Exceptions;


namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects.Validators
{
    ///<summary>
    ///Валидатор email-адреса. Проверяет корректность формата.
    ///</summary>
    public class EmailValidator : IValidator<string>
    {
        ///<summary>
        ///Проверяет формат email.
        ///</summary>
        ///<param name="value">Значение email.</param>
        ///<exception cref="EmailFormatException">Если email некорректного формата.</exception>
        public void Validate(string value)
        {
            try
            {
                var address = new MailAddress(value);
                if (address.Address != value)
                    throw new EmailFormatException(nameof(value), value);
            }
            catch
            {
                throw new EmailFormatException(nameof(value), value);
            }
        }
    }
}
