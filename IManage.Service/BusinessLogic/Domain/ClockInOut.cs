using System;
using System.Runtime.Serialization;

namespace IManageService.BusinessLogic.Domain
{
    /// <summary>
    /// A class representing clocking and out information an employee
    /// </summary>
    [DataContract]
    public class ClockInOut
    {
        #region Properties
        /// <summary>
        /// Gets and sets the id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the clock in date time of an employee
        /// </summary>
        [DataMember]
        public DateTime? ClockInDateTime { get; set; }
        /// <summary>
        /// Gets and sets the clock out date time of an employee
        /// </summary>
        [DataMember]
        public DateTime? ClockOutDateTime { get; set; }
        /// <summary>
        /// Gets and sets the total hours worked in day
        /// </summary>
        public double TotalHoursWorked { get; set; }

        /// <summary>
        /// Gets and sets the employee entity
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets and sets the employee id
        /// </summary>
        public int EmployeeId { get; set; }

        public string EmployeePinCode { get; set; }
        #endregion

    }
}
