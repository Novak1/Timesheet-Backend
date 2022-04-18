using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using VegaIT.Timesheet.Core.Entities;

namespace VegaIT.Timesheet.Core.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Maybe<Client> FindByNameOrId(Client client);
        void Add(Client client);
        void Update(Client client);
        void Remove(Guid clientId);
        IEnumerable<Client> FindAll();
        Maybe<Client> FindById(Guid clientId);
    }
}