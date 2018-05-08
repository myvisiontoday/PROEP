using IManageService.BusinessLogic;
using IManageService.BusinessLogic.Repostiories;
using IManageService.Persistence.Repositories;

namespace IManageService.Persistence
{
    /// <summary>
    /// A class which handles all the database operation
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Data
        /// <summary>
        /// Reference to the database context
        /// </summary>
        private readonly AppiManageDatabaseContext _appiManageDatabaseContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the members
        /// </summary>
        /// <param name="appiManageDatabaseContext">Database context</param>
        public UnitOfWork(AppiManageDatabaseContext appiManageDatabaseContext)
        {
            _appiManageDatabaseContext = appiManageDatabaseContext;
            Clients = new ClientRepository(_appiManageDatabaseContext);
            Employees = new EmployeeRepository(_appiManageDatabaseContext);
            ClockInOuts = new ClockInOutRepository(_appiManageDatabaseContext);
            Items = new ItemRepository(_appiManageDatabaseContext);
            Notifications = new NotificationRepository(_appiManageDatabaseContext);
            Schedules = new ScheduleRepository(_appiManageDatabaseContext);
        }
        #endregion

        #region IUnitOfWork Implementation
        public IClientRepository Clients { get; }
        public IEmployeeRepository Employees { get; }
        public IClockInOutRepository ClockInOuts { get; }
        public IItemRepository Items { get; }
        public INotificationRepository Notifications { get; }
        public IScheduleRepository Schedules { get; }
        public void Dispose()
        {
            _appiManageDatabaseContext?.Dispose();
        }
        public int SaveChanges()
        {
            if (_appiManageDatabaseContext != null)
            {
                return _appiManageDatabaseContext.SaveChanges();
            }
            return -1;
        }
        #endregion
    }
}
