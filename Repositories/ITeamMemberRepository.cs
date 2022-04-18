using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaIT.Timesheet.Core.Entities;

namespace VegaIT.Timesheet.Core.Repositories
{
    public interface ITeamMemberRepository : IRepository<TeamMember>
    {
        Maybe<TeamMember> FindByNameOrId(TeamMember teamMember);
        void Add(TeamMember teamMember);
        void Update(TeamMember teamMember);

        void Remove(Guid teamMemberId);
        //kad god vracam listu koristim IEnumerable
        IEnumerable<TeamMember> FindAll();
        Maybe<TeamMember> FindById(Guid teamMemberId);
    }
}
