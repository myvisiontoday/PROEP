using IManageService.BusinessLogic.Repostiories;
using System;

namespace IManageService.BusinessLogic
{
    /// <summary>
    /// An interface for a class providing capabilities to provide entities and perform actions on the entities
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region Properties
        /// <summary>
        /// Gets an employee entity
        /// </summary>
        IEmployeeRepository Employees { get; }

        /// <summary>
        ///Gets a client entity 
        /// </summary>
        IClientRepository Clients { get; }

        /// <summary>
        /// Gets ClockInout entity
        /// </summary>
        IClockInOutRepository ClockInOuts { get; }

        /// <summary>
        /// Gets Items entity
        /// </summary>
        IItemRepository Items { get; }

        /// <summary>
        /// Gets Notifications entity
        /// </summary>
        INotificationRepository Notifications { get; }

        /// <summary>
        /// Gets Schedules entity
        /// </summary>
        IScheduleRepository Schedules { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Save changes that has been on entities
        /// </summary>
        /// <returns>1 when saving changes is successful otherwise -1</returns>
        int SaveChanges();
        #endregion
    }
}
