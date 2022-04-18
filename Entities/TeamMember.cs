using System;
using CSharpFunctionalExtensions;
using VegaIT.Timesheet.Core.Contracts;

namespace VegaIT.Timesheet.Core.Entities
{
    public class TeamMember : IAggregateRoot
    {
        private TeamMember(Guid id, string name, int hoursPerWeek, string userName, string emailAddress, TeamMemberStatus status,
            TeamMemberRole role)
        {
            Id = id;
            Name = name;
            HoursPerWeek = hoursPerWeek;
            UserName = userName;
            EmailAddress = emailAddress;
            Status = status;
            Role = role;
        }

        public Guid Id { get; }
        public string Name { get; }
        public int HoursPerWeek { get; }
        public string UserName { get; }
        public string EmailAddress { get; }
        public TeamMemberStatus Status { get; }
        public TeamMemberRole Role { get; }

        public static Result<TeamMember> Create(Guid id, string name, int hoursPerWeek, string userName, string emailAddress,
            TeamMemberStatus status, TeamMemberRole role)
        {
            if (id == Guid.Empty) return Result.Failure<TeamMember>("Id cannot be empty");
            if (string.IsNullOrWhiteSpace(name)) return Result.Failure<TeamMember>("Name cannot be empty");
            if (hoursPerWeek == 0 || hoursPerWeek == -1) return Result.Failure<TeamMember>("Hours cannot be less then 0");
            if (string.IsNullOrWhiteSpace(userName)) return Result.Failure<TeamMember>("Username cannot be empty");
            if (string.IsNullOrWhiteSpace(emailAddress)) return Result.Failure<TeamMember>("Email cannot be empty");
            return Result.Success(new TeamMember(id, name, hoursPerWeek, userName, emailAddress, status, role));
        }
    }
}