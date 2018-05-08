using IManageService.BusinessLogic.Domain;
using IManageService.BusinessLogic.Repostiories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IManageService.Persistence.Repositories
{
    /// <summary>
    /// A class which communicates with employee entity
    /// </summary>
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        #region Properties
        /// <summary>
        /// Gets database context
        /// </summary>
        public AppiManageDatabaseContext AppiManageDatabaseContext => DbContext as AppiManageDatabaseContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialzes the members
        /// </summary>
        /// <param name="appiManageDatabaseContext">Database context</param>
        public EmployeeRepository(AppiManageDatabaseContext appiManageDatabaseContext) : base(appiManageDatabaseContext)
        {
        }
        #endregion

        #region IEmployeeRepository Implementation

        public Employee GetEmployeeWithGivenPinCode(string pinCode)
        {
            return AppiManageDatabaseContext.Employees.SingleOrDefault(emp => emp.PinCode == pinCode);
        }

        public IEnumerable<Employee> GetAllEmployeesWithGivenName(string name)
        {
            return AppiManageDatabaseContext.Employees.OrderByDescending(emp => emp.FirstName).Take(10).ToList();
        }

        public bool IsEmployeeClockedIn(string employeePinCode)
        {
            bool result=false;

            Employee foundEmployee = AppiManageDatabaseContext.Employees.SingleOrDefault((employee =>
                employee.PinCode == employeePinCode && employee.IsClocked));
            if (foundEmployee != null)
            {
                result = foundEmployee.IsClocked;
            }
 

            return result;
        }

        #endregion
    }
}
