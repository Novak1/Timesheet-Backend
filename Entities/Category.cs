using System;
using CSharpFunctionalExtensions;
using VegaIT.Timesheet.Core.Contracts;

namespace VegaIT.Timesheet.Core.Entities
{
    public class Category : IAggregateRoot
    {
        private Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }

        public static Result<Category> Create(Guid id, string name)
        {
            if (id == Guid.Empty) return Result.Failure<Category>("Id cannot be empty");
            if (string.IsNullOrWhiteSpace(name)) return Result.Failure<Category>("Name space cannot be empty");
            return Result.Success(new Category(id, name));
        }
    }
}