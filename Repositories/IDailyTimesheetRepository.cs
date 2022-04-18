using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaIT.Timesheet.Core.Entities;

namespace VegaIT.Timesheet.Core.Repositories
{
    public interface IDailyTimesheetRepository : IRepository<DailyTimesheet>
    {
        
        void Add(DailyTimesheet dailyTimesheet);
        void Update(DailyTimesheet dailyTimesheet);
        void Remove(Guid dailyId);
        IEnumerable<DailyTimesheet> FindAll();
        Maybe<DailyTimesheet> FindById(Guid dailyId);
    }
}
