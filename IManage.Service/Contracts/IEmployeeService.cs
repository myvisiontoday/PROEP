using IManageService.BusinessLogic.Domain;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace IManageService.Contracts
{
    /// <summary>
    /// An interface class capable of providing employee services 
    /// </summary>
    [ServiceContract(Name = "IEmployeeService")]
    public interface IEmployeeService
    {
        /// <summary>
        /// Saves an employee
        /// </summary>
        /// <param name="firstName">First name of an employee</param>
        /// <param name="lastName">Last name of an employee</param>
        /// <param name="bsnNumber">BSN number of an employee</param>
        /// <param name="address">Address of an employee</param>
        /// <param name="phoneNumber">Phone number of an employee</param>
        /// <param name="dateOfBirth">Date of birth of an employee</param>
        /// <param name="gender">Gender of an employee</param>
        /// <param name="jobTitle">Job title of an employee</param>
        /// <param name="email">Email of an employee</param>
        /// <returns>True when employee is saved otherwise returns false</returns>
        [OperationContract]
        bool SaveEmployee(string firstName, string lastName, string email, int bsnNumber, string address, long phoneNumber, DateTime dateOfBirth, Gender gender, JobTitle jobTitle);

        /// <summary>
        /// Update employee information
        /// </summary>
        /// <param name="firstName">First name of an employee</param>
        /// <param name="lastName">Last name of an employee</param>
        /// <param name="bsnNumber">BSN number of an employee</param>
        /// <param name="address">Address of an employee</param>
        /// <param name="phoneNumber">Phone number of an employee</param>
        /// <param name="dateOfBirth">Date of birth of an employee</param>
        /// <param name="gender">Gender of an employee</param>
        /// <param name="employeePincode">Pincode of employee which need to be update</param>
        /// <param name="jobTitle">Job title of an employee</param>
        /// <param name="email">Email of an employee</param>
        /// <returns>True when employee information is updated otherwise false</returns>
        [OperationContract]
        bool UpdateEmployee(string employeePincode, string firstName, string lastName, string email, int bsnNumber, string address, long phoneNumber, DateTime dateOfBirth, Gender gender, JobTitle jobTitle);

        /// <summary>
        /// Delete employee with given pin code
        /// </summary>
        /// <param name="employeePinCode">Employees pin code</param>
        /// <returns>True when employee is deleted otherwise false</returns>
        [OperationContract]
        bool DeleteEmployeeWithGivenPinCode(string employeePinCode);

        /// <summary>
        /// Get employee with given pin code
        /// </summary>
        /// <param name="employeePinCode">Employees pin code</param>
        /// <returns>Employees with given pin code</returns>
        [OperationContract]
        Employee GetEmployeeWithGivenPinCode(string employeePinCode);

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>All employees</returns>
        [OperationContract]
        IEnumerable<Employee> GetAllEmployees();

        [OperationContract]
        bool IsEmployeeClockedIn(string employeePinCode);
    }
}
