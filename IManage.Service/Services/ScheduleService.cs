using IManageService.BusinessLogic;
using IManageService.BusinessLogic.Domain;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace IManageService.Services
{
    [ServiceBehavior]
    public class ScheduleService : Contracts.IScheduleService
    {
        #region Public Constant Data
        public const string NameOfService = "Schedule Service";
        public const string ServiceAddress = "http://localhost:8080/IManageService/Services/ScheduleService/";
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets and sets the unit of work instance
        /// </summary>
        public static IUnitOfWork UnitOfWork { get; set; }
        #endregion

        #region Private Methods
        private bool DeleteSchedulesFromDatabase(IEnumerable<Schedule> schedulesToBeRemove)
        {
            bool onSuccess = false;
            foreach (Schedule scheduleToRemove in schedulesToBeRemove)
            {
                Schedule schedule = UnitOfWork.Schedules.Get(scheduleToRemove.Id);
                if (schedule != null)
                {
                    schedule.IsDeleted = true;
                    schedule.DeletedDate = DateTime.Now;
                }
            }

            if (UnitOfWork.SaveChanges() == 1)
            {
                onSuccess = true;
            }

            return onSuccess;
        }
        private bool AddOrUpdateSchedules(IEnumerable<Schedule> schedulesTobeAddOrUpdate)
        {
            bool onSuccess = false;

            foreach (Schedule schedule in schedulesTobeAddOrUpdate)
            {
                if (schedule.Updated)
                {
                    Schedule toBeUpdate = UnitOfWork.Schedules.Get(schedule.Id);

                    if (toBeUpdate != null)
                    {
                        toBeUpdate.StartHour = schedule.StartHour;
                        toBeUpdate.EndHour = schedule.EndHour;
                        toBeUpdate.WeekDay = schedule.WeekDay;
                        toBeUpdate.UpdatedDate = schedule.UpdatedDate;
                        toBeUpdate.Updated = schedule.Updated;
                    }
                }
                else
                {
                    UnitOfWork.Schedules.Add(schedule);
                }
            }

            if (UnitOfWork.SaveChanges() == 1)
            {
                onSuccess = true;
            }


            return onSuccess;
        }
        #endregion

        #region ISchedule Service Implementation
        public bool AddSchedules(IEnumerable<Schedule> schedules)
        {
            bool onSuccess = false;

            if (UnitOfWork != null)
            {
                UnitOfWork.Schedules.AddRange(schedules);
                if (UnitOfWork.SaveChanges() == 1)
                {
                    onSuccess = true;
                }
            }

            return onSuccess;
        }

        public bool AddAndUpdateSchedules(IEnumerable<Schedule> schedulesTobeAddOrUpdate)
        {
            bool onSuccess = false;
            if (UnitOfWork != null)
            {
                onSuccess = AddOrUpdateSchedules(schedulesTobeAddOrUpdate);
            }
            return onSuccess;
        }

        public bool DeleteSchedules(IEnumerable<Schedule> schedulesToBeRemove)
        {
            bool onSuccess = false;
            if (UnitOfWork != null)
            {
                onSuccess = DeleteSchedulesFromDatabase(schedulesToBeRemove);
            }
            return onSuccess;
        }
        public IEnumerable<Schedule> GetSchedulesWithEmployeePinCodeAndWeekNumber(string employeePinCode, int weekNumber)
        {
            return UnitOfWork?.Schedules.GetSchedulesWithEmployeePinCodeAndWeekNumber(employeePinCode, weekNumber);
        }

        public IEnumerable<Schedule> GetSchedulesWithGivenWeekNumber(int weekNumber)
        {
            return UnitOfWork?.Schedules.GetSchedulesWithGivenWeekNumber(weekNumber);
        }

        #endregion

    }
}
