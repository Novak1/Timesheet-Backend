using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using VegaIT.Timesheet.Core.Entities;

namespace VegaIT.Timesheet.Core.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Maybe<Project> FindByNameOrId(Project project);
        void Add(Project project);
        void Update(Project project);
        void Remove(Guid projectId);

        //kad god vracam listu koristim IEnumerable
        IEnumerable<Project> FindAll();
        Maybe<Project> FindById(Guid projectId);
    }
}