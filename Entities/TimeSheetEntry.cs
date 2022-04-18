using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace VegaIT.Timesheet.Core.Entities
{
    public class TimeSheetEntry : ValueObject
    {
        private TimeSheetEntry(string description, int time, int overTime, Project project, Category category)
        {
            Description = description;
            Time = time;
            OverTime = overTime;
            Project = project;
            Category = category;
        }

        public string Description { get; }

        public int Time { get; }

        public int OverTime { get; }

        internal Project Project { get; }

        internal Category Category { get; }

        public static Result<TimeSheetEntry> Create(string description, int time, int overTime, Project project, Category category)
        {
            if (string.IsNullOrWhiteSpace(description)) return Result.Failure<TimeSheetEntry>("Description cannot be empty");

            if (time <= 0) return Result.Failure<TimeSheetEntry>("Time cannot be less then 0");
            if (overTime == -1) return Result.Failure<TimeSheetEntry>("Over time work cannot be less then 0");
            if (project is null) return Result.Failure<TimeSheetEntry>("Project cannot be empty");
            if (category is null) return Result.Failure<TimeSheetEntry>("Category cannot be empty");
            return Result.Success(new TimeSheetEntry(description, time, overTime, project, category));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Project;
            yield return Category;
            yield return Description;
            yield return Time;
            yield return OverTime;
        }
    }
}