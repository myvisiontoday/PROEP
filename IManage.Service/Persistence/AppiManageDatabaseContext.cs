using IManageService.BusinessLogic.Domain;
using IManageService.Persistence.EntityConfigurations;
using System.Data.Entity;

namespace IManageService.Persistence
{
    /// <summary>
    /// A class which contains entitites of a database
    /// </summary>
    public class AppiManageDatabaseContext : DbContext
    {
        #region Properties
        /// <summary>
        /// Gets and sets the employees entity
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets and sets the clients entity
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Gets and sets the Items entity
        /// </summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Gets and sets the schedules entity
        /// </summary>
        public DbSet<Schedule> Schedules { get; set; }

        /// <summary>
        /// Gets and sets the clockinouts entity
        /// </summary>
        public DbSet<ClockInOut> ClockInOuts { get; set; }

        /// <summary>
        /// Gets and sets the notifications entity
        /// </summary>
        public DbSet<Notification> Notifications { get; set; }
        #endregion

        #region Constructor



        /// <summary>
        /// Inilitiazes the members
        /// </summary>
        public AppiManageDatabaseContext() : base("name=AppiManageDatabaseContext")
        {

        }

        #endregion

        #region Base Class Overrides
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().Ignore(schedule => schedule.Updated);

            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new ClockInOutConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new ScheduleConfiguration());
            modelBuilder.Configurations.Add(new NotificationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
