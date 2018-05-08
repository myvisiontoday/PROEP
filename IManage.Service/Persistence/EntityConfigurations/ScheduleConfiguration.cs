using IManageService.BusinessLogic.Domain;
using System.Data.Entity.ModelConfiguration;

namespace IManageService.Persistence.EntityConfigurations
{
    /// <summary>
    /// A class which contains constraints configuration of table Schedules
    /// </summary>
    public class ScheduleConfiguration : EntityTypeConfiguration<Schedule>
    {
        public ScheduleConfiguration()
        {
            ToTable("Schedules");
            HasKey(schedule => schedule.Id);

            Property(schedule => schedule.WeekDay)
                .IsRequired();

            Property(schedule => schedule.Updated)
                .IsRequired();

            Property(schedule => schedule.IsDeleted)
                .IsRequired();

            Property(schedule => schedule.EmployeePinCode)
                .IsRequired();

            Property(schedule => schedule.StartHour)
                .IsRequired()
                .HasColumnType("datetime2");

            Property(schedule => schedule.EndHour)
                .IsRequired()
                .HasColumnType("datetime2");

            Property(schedule => schedule.CreatedDate)
                .HasColumnType("datetime2");

            Property(schedule => schedule.UpdatedDate)
                .IsOptional()
                .HasColumnType("datetime2");

            Property(schedule => schedule.DeletedDate)
                .IsOptional()
                .HasColumnType("datetime2");
        }
    }
}
