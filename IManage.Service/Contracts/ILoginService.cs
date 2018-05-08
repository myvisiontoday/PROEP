using IManageService.BusinessLogic.Domain;
using System.ServiceModel;

namespace IManageService.Contracts
{
    /// <summary>
    /// An interface class for a class capable of providing login service
    /// </summary>
    [ServiceContract(Name = "ILoginService")]
    public interface ILoginService
    {
        /// <summary>
        /// Gets the client
        /// </summary>
        /// <param name="userName">User name of a client</param>
        /// <param name="password">Password of an client</param>
        /// <returns>Client when it is found in database otherwise return null</returns>
        [OperationContract]
        Client GetClient(string userName, string password);
    }
}
