using System;
using CSharpFunctionalExtensions;
using VegaIT.Timesheet.Core.Contracts;
using VegaIT.Timesheet.Core.Entities.ValueObjects;

namespace VegaIT.Timesheet.Core.Entities
{
    public class Client : IAggregateRoot
    {
        private Client(Guid id, string name, Address address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Address Address { get; }

        //guard statements
        //early exit, multiple return statements
        public static Result<Client> Create(Guid id, string name, Address address)
        {
            if (id == Guid.Empty) return Result.Failure<Client>("Id cannot be empty");
            var clientName = ClientName.Create(name);
            if (clientName.IsFailure) return Result.Failure<Client>(clientName.Error);
            if (address is null) return Result.Failure<Client>("Address cannot be empty");
            return Result.Success(new Client(id, name, address));
        }
    }
}