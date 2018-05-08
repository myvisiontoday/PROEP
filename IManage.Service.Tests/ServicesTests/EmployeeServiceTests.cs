using System;
using System.Collections.Generic;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IManageService.BusinessLogic.Domain;




namespace IManageServiceTest.ServicesTests
{
    [TestClass]
    public class EmployeeServiceTests
    {
        IManageService.Services.EmployeeService EmployeService = new IManageService.Services.EmployeeService();

        #region Example Employee Data
        /// <summary>
        /// Firstname of example employee
        /// </summary>
        string _firstName = "Jan";

        /// <summary>
        /// Lastname of example employee
        /// </summary>
        string _lastName = "Karri";

        /// <summary>
        /// BSN Number of example employee
        /// </summary>
        int _bsnNumber = 123456789;

        /// <summary>
        /// Address of example employee
        /// </summary>
        string _address = "Eindhoven";

        /// <summary>
        /// Phone Number of example employee
        /// </summary>
        long _phoneNumber = 06482339939;

        /// <summary>
        /// Birthday of example employee
        /// </summary>
        DateTime _dateOfBirth = new DateTime(1999, 3, 9);

        /// <summary>
        /// Gender of example employee
        /// </summary>
        Gender _gender = Gender.Male;

        /// <summary>
        /// EmployeeId of example employee
        /// </summary>
        int _employeeId = 1;

        /// <summary>
        /// Employee Pincode of example employee
        /// </summary>
        string _employeePinCode = "D5";

        /// <summary>
        /// A condition for comparing the result of the calling method and the example employee 
        /// </summary>
        bool _expectedResult = false;
        
        /// <summary>
        /// A condition for comparing the result of the calling method and the example employee 
        /// </summary>
        bool _actualResult = false;

        /// <summary>
        /// An object of Employee with the exampleEmployee data 
        /// </summary>
        Employee _exampleEmployee;

        /// <summary>
        /// An object of Employee with the resultEmployee data 
        /// </summary>
        Employee _resultEmployee;
        #endregion


        #region Private Method
        public void makingAnExampleEmlopyee()
        {
            _exampleEmployee = new Employee(_firstName, _lastName, _bsnNumber, _address, _phoneNumber, _dateOfBirth, _gender);
          
        }
        #endregion

        #region EmployeeService TestMethod Implementation
        [TestMethod]
        public void CreateEmployeeTest()
        {

            _actualResult =  EmployeService.CreateEmployee(_firstName, _lastName, _bsnNumber, _address, _phoneNumber, _dateOfBirth, _gender);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual<bool>(_expectedResult, _actualResult);
        }

        [TestMethod]
        public void AssignPinCodeToEmployeeTest()
        {
            _actualResult = EmployeService.AssignPinCodeToEmployee(_employeeId);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual<bool>(_expectedResult, _actualResult);

        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            _actualResult = EmployeService.UpdateEmployee(_employeeId, _firstName, _lastName, _bsnNumber, _address, _phoneNumber, _dateOfBirth, _gender);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual<bool>(_expectedResult, _actualResult);
        }

        [TestMethod]
        public void DeleteEmployeeWithGivenPinCodeTest()
        {
            _actualResult = EmployeService.DeleteEmployeeWithGivenPinCode(_employeePinCode);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual<bool>(_expectedResult, _actualResult);
        }

        [TestMethod]
        public void DeleteEmployeeWithGivenIdTest()
        {
            _actualResult = EmployeService.DeleteEmployeeWithGivenId(_employeeId);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual<bool>(_expectedResult, _actualResult);
        }
        [TestMethod]
        public void GetEmployeeWithGivenPinCodeTest()
        {
            _resultEmployee = EmployeService.GetEmployeeWithGivenPinCode(_employeePinCode);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual<Employee>(_exampleEmployee, _resultEmployee);
        }

        #endregion
    }
}
