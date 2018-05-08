using IManageService.BusinessLogic;
using IManageService.BusinessLogic.Domain;
using IManageService.Contracts;
using System;
using System.ServiceModel;

namespace IManageService.Services
{
    [ServiceBehavior]
    public class ClockService : IClockService
    {
        #region Public Constant Data
        public const string NameOfService = "Clock Service";
        public const string ServiceAddress = "http://localhost:8080/IManageService/Services/ClockService/";
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets and sets the unit of work instance
        /// </summary>
        public static IUnitOfWork UnitOfWork { get; set; }
        #endregion

        #region Private Data
        private readonly IEmployeeService _employeeService;
        #endregion

        #region Constructor

        public ClockService()
        {
            _employeeService = new EmployeeService();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Find an employee with given pin code
        /// </summary>
        /// <param name="employeePinCode">Employees pin code</param>
        /// <returns></returns>
        private Employee FindEmployee(string employeePinCode)
        {
            Employee employee = null;

            if (_employeeService != null)
            {
                employee = _employeeService.GetEmployeeWithGivenPinCode(employeePinCode);
            }

            return employee;
        }
        #endregion

        #region IClockService Implementation

        public bool ClockIn(string employeePinCode, ClockInOut clockInOut)
        {
            bool success = false;
            Employee foundEmployee = FindEmployee(employeePinCode);
            if ((foundEmployee != null) && (clockInOut != null) && (UnitOfWork != null))
            {
                Employee employeeToBeUpdate = UnitOfWork.Employees.Get(foundEmployee.EmployeeId);
                if (employeeToBeUpdate != null)
                {
                    employeeToBeUpdate.IsClocked = true;
                    clockInOut.EmployeeId = employeeToBeUpdate.EmployeeId;
                    clockInOut.EmployeePinCode = employeeToBeUpdate.PinCode;
                    clockInOut.Employee = employeeToBeUpdate;
                    UnitOfWork.ClockInOuts.Add(clockInOut);
                }

                if (UnitOfWork.SaveChanges() >= 1)
                {
                    success = true;
                }
            }
            return success;
        }

        public bool ClockOut(string employeePinCode, DateTime clockOutDateTime)
        {
            bool success = false;
            Employee foundEmployee = FindEmployee(employeePinCode);

            if ((foundEmployee != null) && (UnitOfWork != null))
            {
                Employee employeeToBeUpdate = UnitOfWork.Employees.Get(foundEmployee.EmployeeId);
                if (employeeToBeUpdate != null)
                {
                    employeeToBeUpdate.IsClocked = false;
                    ClockInOut clockInOutToBeUpdate =
                        UnitOfWork.ClockInOuts.GetClockInOutWhoseClockOutDateTimeIsNull(employeePinCode);
                    clockInOutToBeUpdate.Employee = employeeToBeUpdate;
                    clockInOutToBeUpdate.ClockOutDateTime = clockOutDateTime;
                    if (clockInOutToBeUpdate.ClockInDateTime.HasValue)
                    {
                        clockInOutToBeUpdate.TotalHoursWorked =
                            clockOutDateTime.Subtract(clockInOutToBeUpdate.ClockInDateTime.Value).TotalHours;
                    }
                }

                if (UnitOfWork.SaveChanges() >= 1)
                {
                    success = true;
                }
            }
            return success;
        }
        #endregion
    }
}
