
using System;
using System.Collections.Generic;

namespace IManageService.BusinessLogic.Domain
{
    #region Enum Gender
    /// <summary>
    /// Enum for Gender
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Represent male 
        /// </summary>
        Male = 0,
        /// <summary>
        /// Represent female
        /// </summary>
        Female = 1
    }
    #endregion

    #region Enum Gender
    /// <summary>
    /// Enum representing different job title for employees
    /// </summary>
    public enum JobTitle
    {
        /// <summary>
        /// Resaurant manager
        /// </summary>
        Manager = 0,

        /// <summary>
        /// Cook of the restaurant
        /// </summary>
        Chef = 1,

        /// <summary>
        /// Waiter of a restaurant
        /// </summary>
        Waiter = 2,

        /// <summary>
        /// Dish washer of the restaurant
        /// </summary>
        DishWasher = 3,
    }
    #endregion

    /// <summary>
    /// A class representing employee information
    /// </summary>
    public class Employee
    {
        #region Properties
        /// <summary>
        /// Gets employee id
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets and sets the employee firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets and sets employee lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets and sets employee email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets and sets employee address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets and sets employee bsn number
        /// </summary>
        public int? BsnNumber { get; set; }

        /// <summary>
        /// Gets and sets employee phone number
        /// </summary>
        public long PhoneNumber { get; set; }

        /// <summary>
        /// Gets and sets employee pin code
        /// </summary>
        public string PinCode { get; set; }

        /// <summary>
        /// Gets and sets the date of birth 
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        ///Gets and sets the gender
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Gets and sets the employee job title
        /// </summary>
        public JobTitle? JobTitle { get; set; }

        /// <summary>
        /// Gets and sets deleted flag of an employee
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets and sets clocked flag
        /// </summary>
        public bool IsClocked { get; set; }

        /// <summary>
        /// Gets and sets clockin out id
        /// </summary>
        public int? ClockInOutId { get; set; }
        /// <summary>
        /// Gets and sets all clockinouts entity
        /// </summary>
        public ICollection<ClockInOut> ClockInOuts { get; set; }

        /// <summary>
        /// Gets and sets all notifications entity
        /// </summary>
        public ICollection<Notification> Notifications { get; set; }

        /// <summary>
        /// Gets and sets all schedules entity
        /// </summary>
        public ICollection<Schedule> Schedules { get; set; }


        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Employee()
        {

        }
        /// <summary>
        /// Initializes members
        /// </summary>
        /// <param name="firstName">First name of an employee </param>
        /// <param name="lastName">Last name of an employee</param>
        /// <param name="email">Gender of an employee</param>
        /// <param name="bsnNumber">BSN number of an employee</param>
        /// <param name="address">Address of an employee</param>
        /// <param name="phoneNumber">Phone number of an employee</param>
        /// <param name="dateOfBirth">Date of birth of an employee</param>
        /// <param name="gender">Gender of an employee</param>
        /// <param name="jobTitle">Job title of an employee</param>
        public Employee(string firstName, string lastName, string email, int bsnNumber, string address, long phoneNumber, DateTime dateOfBirth, Gender gender, JobTitle jobTitle)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BsnNumber = bsnNumber;
            Address = address;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            JobTitle = jobTitle;
        }
        #endregion
    }
}
