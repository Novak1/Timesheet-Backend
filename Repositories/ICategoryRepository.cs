using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using VegaIT.Timesheet.Core.Entities;

namespace VegaIT.Timesheet.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Maybe<Category> FindByNameOrId(Category category);
        void Add(Category category);
        void Update(Category category);
        void Remove(Guid categoryId);
        IEnumerable<Category> FindAll();
        Maybe<Category> FindById(Guid categoryId);
    }
}