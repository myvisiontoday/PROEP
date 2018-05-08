using IManageService.BusinessLogic.Domain;
using IManageService.BusinessLogic.Repostiories;
using System.Data.Entity;
using System.Linq;

namespace IManageService.Persistence.Repositories
{
    /// <summary>
    /// A class which communicates with client entity
    /// </summary>
    public class ClientRepository : Repository<Client>, IClientRepository
    {

        #region Properties
        /// <summary>
        /// Gets the dbcontext instance
        /// </summary>
        public AppiManageDatabaseContext AppiManageDatabaseContext => DbContext as AppiManageDatabaseContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialises members
        /// </summary>
        /// <param name="dbContext">Instance of a DbContext</param>
        public ClientRepository(DbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region IClientRepository Implementation
        public Client GetClientWithUserNamePassword(string userName, string password)
        {
            return AppiManageDatabaseContext.Clients.SingleOrDefault(client => ((client.UserName == userName) && (client.PassWord == password)));
        }
        #endregion
    }
}
