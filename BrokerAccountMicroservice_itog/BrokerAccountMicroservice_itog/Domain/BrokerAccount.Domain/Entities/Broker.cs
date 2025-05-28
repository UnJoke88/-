using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities.Base;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Exceptions;
using BrokerAccountMicroservice_itog.Domain.BrokerAccount.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Collections.Specialized.BitVector32;

namespace BrokerAccountMicroservice_itog.Domain.BrokerAccount.Domain.Entities
{
    public class Broker : Entity<Guid>
    {
        #region Свойства

        public BrokerName Name { get; }

        private readonly ICollection<Client> _client = [];

        #endregion

        #region Конструктор

        protected Broker()
        {

        }

        protected Broker(Guid id, BrokerName name)
            : base(id)
        {
            Name = name ?? throw new ArgumentNullValueException(nameof(name));
        }

        public Broker(BrokerName name)
           : this(Guid.NewGuid(), name)
        {

        }
        #endregion

        #region Методы

        /// <summary>
        /// Изменить Брокеру минимальное кол-во актива за одну покупку
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public bool SetUnit(Asset asset, MinimalUnit unit)
        {
            if (asset == null) return false;
            if (!asset.ChangeMinimalUnit(unit)) return false;
            return true;
        }

        /// <summary>
        /// Брокер меняет цену на актив
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool SetPrice(Asset asset, Money price)
        {
            if (asset == null) return false;
            if (!asset.ChangePurchasePrice(price)) return false;
            return true;
        }

        //Получение Список всех клиентов
        public IReadOnlyCollection<Client> ShowClients => //ShowClients - название коллекции клиентов
            _client.ToList().AsReadOnly();

        /// <summary>
        /// Добавление клиента в список брокера (в управление брокером)
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool AddClient(Client client)
        {
            if (client == null) return false;
            _client.Add(client);
            return true;
        }

        #endregion
    }
}
