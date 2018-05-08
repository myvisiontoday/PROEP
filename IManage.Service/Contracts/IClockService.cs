using IManageService.BusinessLogic.Domain;
using System;
using System.ServiceModel;

namespace IManageService.Contracts
{
    /// <summary>
    /// An interface class for a class capable providing clocking service
    /// </summary>
    [ServiceContract(Name = "IClockService")]
    public interface IClockService
    {
        /// <summary>
        /// Clock in employee
        /// </summary>
        /// <param name="employeePinCode">Employees pin code</param>
        /// <param name="clockInOut">Clock in outs</param>
        /// <returns>True when successful clocked in otherwise false</returns>
        [OperationContract]
        bool ClockIn(string employeePinCode, ClockInOut clockInOut);

        /// <summary>
        /// Clock out employee
        /// </summary>
        /// <param name="employeePinCode">Employees pin code</param>
        /// <param name="clockOutDateTime">Clock out date time</param>
        /// <returns>True when successful clocked out otherwise false</returns>
        [OperationContract]
        bool ClockOut(string employeePinCode, DateTime clockOutDateTime);
    }
}
