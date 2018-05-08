using IManageService.BusinessLogic.Domain;
using IManageService.BusinessLogic.Repostiories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IManageService.Persistence.Repositories
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        /// <summary>
        /// A class which communicates with Schedules entity
        /// </summary>

        #region Properties

        /// <summary>
        /// Gets the dbcontext instance
        /// </summary>
        public AppiManageDatabaseContext AppiManageDatabaseContext => DbContext as AppiManageDatabaseContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises members
        /// </summary>
        /// <param name="dbContext">Instance of a DbContext</param>
        public ScheduleRepository(DbContext dbContext) : base(dbContext)
        {

        }

        #endregion

        #region IScheduleRepository Implementation

        public IEnumerable<Schedule> GetSchedulesWithEmployeePinCodeAndWeekNumber(string employeePincode, int weekNumber)
        {
            return AppiManageDatabaseContext.Schedules.Where(schedule => ((schedule.EmployeePinCode == employeePincode) && (schedule.WeekNumber == weekNumber)));
        }

        public IEnumerable<Schedule> GetSchedulesWithGivenWeekNumber(int weekNumber)
        {
            return AppiManageDatabaseContext.Schedules.Where(schedule => schedule.WeekNumber == weekNumber);
        }

        #endregion
    }
}
