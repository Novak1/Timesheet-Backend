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
    public class TeamMemberService
    {
        private readonly ITeamMemberRepository _TeamMemberRepository;

        public TeamMemberService(ITeamMemberRepository teamMemberRepository)
        {
            _TeamMemberRepository = teamMemberRepository;
        }

        public Result CreateNew(TeamMember teamMember)
        {
            var maybeTeamMember = _TeamMemberRepository.FindByNameOrId(teamMember);
            if (maybeTeamMember.HasValue) return Result.Failure("Team member with same name or id already exists");

            _TeamMemberRepository.Add(teamMember);
            return Result.Success();
        }

        public Result Remove(TeamMember teamMember, Guid teamMemberId)
        {
            var maybeTeamMemeber = _TeamMemberRepository.FindByNameOrId(teamMember);
            if (maybeTeamMemeber.HasValue) return Result.Failure("Team member with same name or id already exists");

            _TeamMemberRepository.Remove(teamMemberId);
            return Result.Success();
        }

        public Result Update(TeamMember teamMember)
        {
            var maybeTeamMemeber = _TeamMemberRepository.FindByNameOrId(teamMember);
            if (maybeTeamMemeber.HasValue) return Result.Failure("Team member with same name or id already exists");

            _TeamMemberRepository.Update(teamMember);
            return Result.Success();
        }

        public Result Remove(Guid id)
        {
            var maybeClient = _TeamMemberRepository.FindById(id);
            if (maybeClient.HasNoValue) return Result.Failure("Team member with provided id doesn't exist");

            _TeamMemberRepository.Remove(id);
            return Result.Success();
        }
    }
}
