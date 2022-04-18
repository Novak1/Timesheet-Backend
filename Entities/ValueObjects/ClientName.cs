using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace VegaIT.Timesheet.Core.Entities.ValueObjects
{
    public class ClientName : ValueObject
    {
        private string Name { get; }

        private ClientName(string name)
        {
            Name = name;
        }

        public static Result<ClientName> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return Result.Failure<ClientName>("Name cannot be empty");
            if (name.Length > 100) return Result.Failure<ClientName>("Name length exceeds 100 chars");

            return Result.Success(new ClientName(name));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}