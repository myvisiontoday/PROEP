using IManageService.BusinessLogic.Domain;

namespace IManageService.BusinessLogic.Repostiories
{
    /// <summary>
    /// An interface for a class providing capabilities to perform CRUD in clients entity 
    /// </summary>
    public interface IClientRepository : IRepository<Client>
    {
        /// <summary>
        /// Gets a client with given user name and password
        /// </summary>
        /// <param name="userName">User name of a client</param>
        /// <param name="password">Password of a client</param>
        /// <returns></returns>
        Client GetClientWithUserNamePassword(string userName, string password);
    }
}
