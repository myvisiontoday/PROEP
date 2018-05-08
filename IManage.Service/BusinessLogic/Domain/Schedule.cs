using System;
using System.Runtime.Serialization;

namespace IManageService.BusinessLogic.Domain
{
    #region Enum WeekDay
    /// <summary>
    /// Day of the week
    /// </summary>
    public enum WeekDay
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6
    }
    #endregion

    /// <summary>
    /// A class representing employee schedule information
    /// </summary>
    [DataContract]
    public class Schedule
    {
        #region Properties
        /// <summary>
        /// Gets and sets the schedule id
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the week day
        /// </summary>
        [DataMember]
        public WeekDay WeekDay { get; set; }

        /// <summary>
        /// Gets and sets the week number
        /// </summary>
        [DataMember]
        public int WeekNumber { get; set; }
        /// <summary>
        /// Gets and sets the employee pincode
        /// </summary>
        [DataMember]
        public string EmployeePinCode { get; set; }

        /// <summary>
        /// Gets and sets the start hour of an employee
        /// </summary>
        [DataMember]
        public DateTime StartHour { get; set; }

        /// <summary>
        /// Gets and sets the end hour of an employee
        /// </summary>
        [DataMember]
        public DateTime EndHour { get; set; }

        /// <summary>
        /// Gets and sets update status
        /// </summary>
        [DataMember]
        public bool Updated { get; set; }
        /// <summary>
        /// Gets and sets delete flag
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Gets and sets the created date of schedule
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets and sets the updated date of schedule
        /// </summary>
        [DataMember]
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets and sets the deleted date of schedule
        /// </summary>
        [DataMember]
        public DateTime? DeletedDate { get; set; }

        /// <summary>
        /// Gets and sets employee entity
        /// </summary>
        [DataMember]
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets and sets employee id
        /// </summary>
        [DataMember]
        public int EmployeeId { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor and doesnot initiazes the members
        /// </summary>
        public Schedule()
        {

        }
        /// <summary>
        /// Initializs members
        /// </summary>
        /// <param name="weekDay">Day of week</param>
        /// <param name="employeePinCode">Employee pin code</param>
        /// <param name="weekNumber">Week Number</param>
        /// <param name="startHour">Work start hour</param>
        /// <param name="endHour">Work end hour</param>
        public Schedule(WeekDay weekDay, int weekNumber, string employeePinCode, DateTime startHour, DateTime endHour)
        {
            WeekDay = weekDay;
            WeekNumber = weekNumber;
            EmployeePinCode = employeePinCode;
            StartHour = startHour;
            EndHour = endHour;
        }
        #endregion
    }
}
