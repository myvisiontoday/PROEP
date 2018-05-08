using IManageService.BusinessLogic.Domain;
using System.Collections.Generic;

namespace IManageService.BusinessLogic.Repostiories
{
    /// <summary>
    /// An interface for a class providing capabilities to perform CRUD in employees entity 
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Get an employee
        /// </summary>
        /// <param name="pinCode">Pin code of an employee</param>
        /// <returns>Employee if it found otherwise return null</returns>
        Employee GetEmployeeWithGivenPinCode(string pinCode);

        /// <summary>
        /// Gets employees with given name
        /// </summary>
        /// <param name="name">name of an employee</param>
        /// <returns>All employees with given name</returns>
        IEnumerable<Employee> GetAllEmployeesWithGivenName(string name);

        bool IsEmployeeClockedIn(string employeePinCode);
    }
}
