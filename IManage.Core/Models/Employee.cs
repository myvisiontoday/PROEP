using System;
using System.Collections;
using System.ComponentModel;

namespace IManage.Core.Models
{
    #region Enums

    /// <summary>
    /// Enum to identify gender of an employee
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

    /// <summary>
    /// Enum representing job title for an employee
    /// </summary>
    public enum JobTitle
    {
        /// <summary>
        /// Manager title
        /// </summary>
        Manager = 0,

        /// <summary>
        /// Chef title
        /// </summary>
        Chef = 1,

        /// <summary>
        /// Waiter title
        /// </summary>
        Waiter = 2,

        /// <summary>
        /// Dish washer title
        /// </summary>
        DishWasher = 3,
    }
    #endregion

    /// <summary>
    /// A class representing employee information
    /// </summary>
    public class Employee : INotifyDataErrorInfo
    {

        #region Properties

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
        public string BsnNumber { get; set; }

        /// <summary>
        /// Gets and sets employee phone number
        /// </summary>
        public long? PhoneNumber { get; set; }

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

        public string PinCode { get; set; }

        public string Details => FirstName + " " + LastName + " hello wolrd";

        #endregion

        #region INotifyDataErrorInfo Implementation
        public IEnumerable GetErrors(string propertyName)
        {
            string error = string.Empty;
            switch (propertyName)
            {
                case "FirstName":
                    error = "FirstName is required";
                    break;
                case "LastName":
                    error = "LastName is required";
                    break;
                case "Email":
                    error = "Email is required";
                    break;
                case "Address":
                    error = "Address is required";
                    break;

                case "BsnNumber":
                    error = "Bsn number is required";
                    break;

                case "PhoneNumber":
                    error = "Phone number is required";
                    break;

                case "DateOfBirth":
                    error = "Date of birth is required";
                    break;

                case "Gender":
                    error = "Gender is required";
                    break;

                case "JobTitle":
                    error = "Job title is required";
                    break;
            }
            return error;
        }

        public bool HasErrors => false;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        #endregion
    }
}
