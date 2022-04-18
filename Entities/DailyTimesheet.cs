using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using VegaIT.Timesheet.Core.Contracts;

namespace VegaIT.Timesheet.Core.Entities
{
    public class DailyTimesheet : IAggregateRoot
    {
        private DailyTimesheet(Guid id, DateTimeOffset date, IEnumerable<TimeSheetEntry> timeSheetEntries)
        {
            Id = id;
            Date = date;
            TimeSheetEntries = timeSheetEntries;
        }

        public Guid Id { get; }
        public DateTimeOffset Date { get; }
        public IEnumerable<TimeSheetEntry> TimeSheetEntries { get; }

        public static Result<DailyTimesheet> Create(Guid id, DateTimeOffset date, IEnumerable<TimeSheetEntry> timeSheetEntries)
        {
            if (timeSheetEntries is null) return Result.Failure<DailyTimesheet>("Timesheet entries cannot be empty");
            if (id == Guid.Empty) return Result.Failure<DailyTimesheet>("Id cannot be empty");
            return Result.Success(new DailyTimesheet(id, date, timeSheetEntries));
        }
    }
}