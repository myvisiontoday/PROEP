using IManageService.BusinessLogic;
using IManageService.BusinessLogic.Domain;
using IManageService.Contracts;
using System.Diagnostics;
using System.ServiceModel;

namespace IManageService.Services
{
    /// <summary>
    /// A class which provides login services
    /// </summary>
    [ServiceBehavior]
    public class LoginService : ILoginService
    {
        #region Public Constant Data
        public const string NameOfService = "Login Service";
        public const string ServiceAddress = "http://localhost:8080/IManageService/Services/LoginService/";
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets and sets the unit of work instance
        /// </summary>
        public static IUnitOfWork UnitOfWork { get; set; }
        #endregion

        #region ILoginService Implementation
        public Client GetClient(string userName, string passWord)
        {
            Debug.Assert(UnitOfWork != null);

            return UnitOfWork?.Clients.GetClientWithUserNamePassword(userName, passWord);
        }
        #endregion
    }
}
