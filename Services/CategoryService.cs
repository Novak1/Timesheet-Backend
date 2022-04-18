using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaIT.Timesheet.Core.Entities;
using VegaIT.Timesheet.Core.Repositories;

namespace VegaIT.Timesheet.Core.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryReposityory;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryReposityory = categoryRepository;
        }

        public Result CreateNew(Category category)
        {
            var maybeCategory = _categoryReposityory.FindByNameOrId(category);
            if (maybeCategory.HasValue) return Result.Failure("Category with same name or id already exists");
            _categoryReposityory.Add(category);
            return Result.Success();
        }

        public Result Remove(Category category, Guid categoryId)
        {
            var maybeTeamMemeber = _categoryReposityory.FindByNameOrId(category);
            if (maybeTeamMemeber.HasValue) return Result.Failure("Category with same name or id already exists");

            _categoryReposityory.Remove(categoryId);
            return Result.Success();
        }

        public Result Update(Category category)
        {
            var maybeTeamMemeber = _categoryReposityory.FindByNameOrId(category);
            if (maybeTeamMemeber.HasValue) return Result.Failure("Category with same name or id already exists");

            _categoryReposityory.Update(category);
            return Result.Success();
        }

        public Result Remove(Guid id)
        {
            var maybeCategory = _categoryReposityory.FindById(id);
            if (maybeCategory.HasNoValue) return Result.Failure("Team member with provided id doesn't exist");

            _categoryReposityory.Remove(id);
            return Result.Success();
        }
    }
}
