using IManageService.BusinessLogic.Domain;
using System.Collections.Generic;

namespace IManageService.BusinessLogic.Repostiories
{
    /// <summary>
    /// An interface for a class providing capabilities to perform CRUD in Schedule entity 
    /// </summary>
    public interface IScheduleRepository : IRepository<Schedule>
    {
        IEnumerable<Schedule> GetSchedulesWithEmployeePinCodeAndWeekNumber(string employeePincode, int weekNumber);
        IEnumerable<Schedule> GetSchedulesWithGivenWeekNumber(int weekNumber);
    }
}
