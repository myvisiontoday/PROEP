using IManageService.BusinessLogic.Domain;
using System.Collections.Generic;
using System.ServiceModel;

namespace IManageService.Contracts
{
    /// <summary>
    /// An interface for a class capable of providing ScheduleServices
    /// </summary>
    [ServiceContract(Name = "IScheduleService")]
    public interface IScheduleService
    {
        #region Methods

        [OperationContract]
        bool AddSchedules(IEnumerable<Schedule> schedules);

        [OperationContract]
        bool AddAndUpdateSchedules(IEnumerable<Schedule> schedulesTobeAddOrUpdate);

        [OperationContract]
        bool DeleteSchedules(IEnumerable<Schedule> schedulesToBeRemove);


        [OperationContract]
        IEnumerable<Schedule> GetSchedulesWithEmployeePinCodeAndWeekNumber(string employeePincode, int weekNumber);

        [OperationContract]
        IEnumerable<Schedule> GetSchedulesWithGivenWeekNumber(int weekNumber);

        #endregion
    }
}
