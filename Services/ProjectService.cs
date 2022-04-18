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
    public class ProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Result CreateNew(Project project)
        {
            var maybeProject = _projectRepository.FindByNameOrId(project);
            if (maybeProject.HasValue) return Result.Failure("Project with same name or id already exists");

            _projectRepository.Add(project);
            return Result.Success();
        }

        public Result Remove(Project project, Guid projectId)
        {
            var maybeTeamMemeber = _projectRepository.FindByNameOrId(project);
            if (maybeTeamMemeber.HasValue) return Result.Failure("Project with same name or id already exists");

            _projectRepository.Remove(projectId);
            return Result.Success();
        }

        public Result Update(Project project)
        {
            var maybeTeamMemeber = _projectRepository.FindByNameOrId(project);
            if (maybeTeamMemeber.HasValue) return Result.Failure("Project with same name or id already exists");

            _projectRepository.Update(project);
            return Result.Success();
        }

        public Result Remove(Guid projectId)
        {
            var maybeProject = _projectRepository.FindById(projectId);
            if (maybeProject.HasNoValue) return Result.Failure("Project with provided id doesn't exist");

            _projectRepository.Remove(projectId);
            return Result.Success();
        }
    }
}
