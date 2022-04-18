using System;
using CSharpFunctionalExtensions;
using VegaIT.Timesheet.Core.Entities;
using VegaIT.Timesheet.Core.Repositories;

namespace VegaIT.Timesheet.Core.Services
{
    public class DailyTimesheetService
    {
        private readonly IDailyTimesheetRepository _dailyTimesheetRepository;

        public DailyTimesheetService(IDailyTimesheetRepository dailyTimesheetRepository)
        {
            _dailyTimesheetRepository = dailyTimesheetRepository;
        }

        public Result CreateNew(DailyTimesheet dailyTimesheet)
        {
            var maybeDailyTimesheet = _dailyTimesheetRepository.FindById(dailyTimesheet.Id);
            if (maybeDailyTimesheet.HasValue) return Result.Failure("DailyTimesheet with ID already exists");

            _dailyTimesheetRepository.Add(dailyTimesheet);
            return Result.Success();
        }

        public Result Remove(Guid dailyTimesheetId)
        {
            var maybeDailyTimesheet = _dailyTimesheetRepository.FindById(dailyTimesheetId);
            if (maybeDailyTimesheet.HasNoValue) return Result.Failure("DailyTimesheet with provided id doesn't exist");

            _dailyTimesheetRepository.Remove(dailyTimesheetId);
            return Result.Success();
        }

        public Result Update(DailyTimesheet dailyTimesheet)
        {
            var maybeDailyTimesheet = _dailyTimesheetRepository.FindById(dailyTimesheet.Id);
            if (maybeDailyTimesheet.HasNoValue) return Result.Failure("DailyTimesheet with provided id doesn't exist");

            _dailyTimesheetRepository.Update(dailyTimesheet);
            return Result.Success();
        }
    }
}