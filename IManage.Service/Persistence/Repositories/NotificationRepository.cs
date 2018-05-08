using IManageService.BusinessLogic.Domain;
using IManageService.BusinessLogic.Repostiories;
using System.Data.Entity;

namespace IManageService.Persistence.Repositories
{
    /// <summary>
    /// A class which communicates with Notifications entity
    /// </summary>
    public class NotificationRepository : Repository<Notification>, INotificationRepository
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
        public NotificationRepository(DbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
