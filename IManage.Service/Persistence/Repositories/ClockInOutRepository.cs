using IManageService.BusinessLogic.Domain;
using IManageService.BusinessLogic.Repostiories;
using System.Data.Entity;
using System.Linq;

namespace IManageService.Persistence.Repositories
{
    /// <summary>
    /// A class which communicates with ClockInOuts entity
    /// </summary>
    public class ClockInOutRepository : Repository<ClockInOut>, IClockInOutRepository
    {
        /// <summary>
        /// A class which communicates with ClockInOuts entity
        /// </summary>

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
        public ClockInOutRepository(DbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region IClockInOutsRepository Implementation
        public ClockInOut GetClockInOutWhoseClockOutDateTimeIsNull(string employeePinCode)
        {
            return AppiManageDatabaseContext.ClockInOuts.Where(clockInout =>
                (clockInout.EmployeePinCode == employeePinCode) && (clockInout.ClockOutDateTime == null)).ToList()[0];
        }
        #endregion
    }
}
