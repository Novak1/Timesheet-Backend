using System;
using CSharpFunctionalExtensions;
using VegaIT.Timesheet.Core.Contracts;

namespace VegaIT.Timesheet.Core.Entities
{
    public class Project : IAggregateRoot
    {
        private Project(Guid id, string name, string description, Client client, TeamMember teamMember, ProjectStatus status)
        {
            Id = id;
            Name = name;
            Description = description;
            Client = client;
            TeamMember = teamMember;
            Status = status;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        public Client Client { get; }

        public TeamMember TeamMember { get; }

        public ProjectStatus Status { get; }

        public static Result<Project> Create(Guid id, string name, string description, Client client, TeamMember teamMember,
            ProjectStatus status)
        {
            if (id == Guid.Empty) return Result.Failure<Project>("Id cannot be empty");
            if (string.IsNullOrWhiteSpace(name)) return Result.Failure<Project>("Name cannot be empty");
            if (string.IsNullOrWhiteSpace(description)) return Result.Failure<Project>("Description cannot be empty");
            if (client is null) return Result.Failure<Project>("Client cannot be empty");
            if (teamMember is null) return Result.Failure<Project>("Team member cannot be empty");
            return Result.Success(new Project(id, name, description, client, teamMember, status));
        }
    }
}