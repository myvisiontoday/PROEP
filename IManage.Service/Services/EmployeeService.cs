using IManageService.BusinessLogic;
using IManageService.BusinessLogic.Domain;
using IManageService.Contracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace IManageService.Services
{
    /// <summary>
    /// A class which provides employee service
    /// </summary>
    [ServiceBehavior]
    public class EmployeeService : IEmployeeService
    {
        #region Public Constant Data
        public const string NameOfService = "Employee Service";
        public const string ServiceAddress = "http://localhost:8080/IManageService/Services/EmployeeService/";
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets and sets the unit of work instance
        /// </summary>
        public static IUnitOfWork UnitOfWork { get; set; }
        #endregion

        #region Private Methods
        /// <summary>
        /// Generates an employee pincode
        /// </summary>
        /// <param name="employeeId">Id of an employee</param>
        /// <returns>True when pincode is generated for an employee otherwise returns false</returns>
        private bool GenerateEmployeePinCode(int employeeId)
        {
            bool onSuccess = false;
            Employee foundEmployee = UnitOfWork?.Employees.Get(employeeId);
            if (foundEmployee != null)
            {
                foundEmployee.PinCode = foundEmployee.EmployeeId.ToString("0000");
                int saveSuccess = UnitOfWork.SaveChanges();
                if (saveSuccess == 1)
                {
                    onSuccess = true;
                }
            }
            return onSuccess;
        }
        #endregion

        #region IEmployeeService Implementation
        public bool SaveEmployee(string firstName, string lastName, string email, int bsnNumber, string address, long phoneNumber, DateTime dateOfBirth, Gender gender, JobTitle jobTitle)//, out bool employeeSaved)
        {
            bool onSuccess = false;

            Employee employee = new Employee(firstName, lastName, email, bsnNumber, address, phoneNumber, dateOfBirth, gender, jobTitle);

            if (UnitOfWork != null)
            {
                UnitOfWork.Employees.Add(employee);
                int saveSuccess = UnitOfWork.SaveChanges();
                if (saveSuccess == 1)
                {
                    onSuccess = GenerateEmployeePinCode(employee.EmployeeId);
                }
            }
            return onSuccess;
        }
        public bool UpdateEmployee(string employeePinCode, string firstName, string lastName, string email, int bsnNumber, string address, long phoneNumber, DateTime dateOfBirth, Gender gender, JobTitle jobTitle)
        {
            bool onSuccess = false;

            Employee foundEmployee = UnitOfWork?.Employees.GetEmployeeWithGivenPinCode(employeePinCode);
            if (foundEmployee != null)
            {
                foundEmployee.FirstName = firstName;
                foundEmployee.LastName = lastName;
                foundEmployee.Email = email;
                foundEmployee.BsnNumber = bsnNumber;
                foundEmployee.Address = address;
                foundEmployee.PhoneNumber = phoneNumber;
                foundEmployee.DateOfBirth = dateOfBirth;
                foundEmployee.Gender = gender;
                foundEmployee.JobTitle = jobTitle;
                int saveSuccess = UnitOfWork.SaveChanges();
                if (saveSuccess == 1)
                {
                    onSuccess = true;
                }
            }
            return onSuccess;
        }

        public bool DeleteEmployeeWithGivenPinCode(string employeePinCode)
        {
            bool onSuccess = false;
            Employee foundEmployee = UnitOfWork?.Employees.SingleOrDefault(emp => emp.PinCode == employeePinCode);
            if (foundEmployee != null)
            {
                foundEmployee.IsDeleted = true;
                int saveSuccess = UnitOfWork.SaveChanges();
                if (saveSuccess == 1)
                {
                    onSuccess = true;
                }
            }
            return onSuccess;
        }
        public Employee GetEmployeeWithGivenPinCode(string employeePinCode)
        {
            return UnitOfWork?.Employees.SingleOrDefault(emp => emp.PinCode == employeePinCode);
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return UnitOfWork?.Employees.GetAll();
        }

        public bool IsEmployeeClockedIn(string employeePinCode)
        {
            bool result = false;
            if (UnitOfWork != null)
            {
                result = UnitOfWork.Employees.IsEmployeeClockedIn(employeePinCode);
            }
            return result;
        }

        #endregion
    }
}
