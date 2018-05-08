using IManageService.BusinessLogic.Domain;
using IManageService.BusinessLogic.Repostiories;
using System.Data.Entity;

namespace IManageService.Persistence.Repositories
{
    /// <summary>
    /// A class which communicates with Items entity
    /// </summary>
    public class ItemRepository : Repository<Item>, IItemRepository
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
        public ItemRepository(DbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
