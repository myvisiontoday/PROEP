using System;
using System.Collections.Generic;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IManageService.BusinessLogic.Domain;

namespace IManageServiceTest.ServicesTests
{
    [TestClass]
    public class LoginServiceTests
    {
        IManageService.Services.LoginService LoginService= new IManageService.Services.LoginService();

        #region Example Employee Data
        /// <summary>
        /// Firstname of example employee
        /// </summary>
        string _username = "Jan123";

        /// <summary>
        /// Lastname of example employee
        /// </summary>
        string _password = "12345";

        /// <summary>
        /// A condition for comparing the result of the calling method and the example employee 
        /// </summary>
        bool _expectedResult = false;

        /// <summary>
        /// A condition for comparing the result of the calling method and the example employee 
        /// </summary>
        bool _actualResult = false;
        #endregion

        [TestMethod]
        public void LoginTest()
        {
            _actualResult = LoginService.Login(_username, _password);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual<bool>(_expectedResult, _actualResult);
        }
    }
}
