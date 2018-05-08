using IManageService.BusinessLogic.Domain;
using System.Data.Entity.ModelConfiguration;

namespace IManageService.Persistence.EntityConfigurations
{
    /// <summary>
    /// A class which contains constraints configuration of table Employees
    /// </summary>
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employees");

            HasKey(employee => employee.EmployeeId);

            Property(employee => employee.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            Property(employee => employee.LastName)
                .IsRequired()
                .HasMaxLength(255);

            Property(employee => employee.Email)
                .IsRequired()
                .HasMaxLength(255);

            Property(employee => employee.Address)
                .IsRequired()
                .HasMaxLength(500);

            Property(employee => employee.BsnNumber)
                .IsRequired()
                .HasColumnType("int");

            Property(employee => employee.PhoneNumber)
                .IsRequired();

            Property(employee => employee.DateOfBirth)
                .IsRequired()
                .HasColumnType("datetime2");

            Property(employee => employee.PinCode)
                .IsOptional()
                .HasMaxLength(4);

            Property(employee => employee.Gender)
                .IsRequired();

            Property(employee => employee.JobTitle)
                .IsRequired();

            Property(employee => employee.IsDeleted)
                .IsRequired();

            HasMany(employee => employee.ClockInOuts)
                .WithRequired(clockinout => clockinout.Employee)
                .HasForeignKey(clocinout => clocinout.EmployeeId)
                .WillCascadeOnDelete(false);

            HasMany(employee => employee.Notifications)
                .WithRequired(notification => notification.Employee)
                .HasForeignKey(notification => notification.EmployeeId)
                .WillCascadeOnDelete(false);

            HasMany(employee => employee.Schedules)
                .WithRequired(schedule => schedule.Employee)
                .HasForeignKey(schedule => schedule.EmployeeId)
                .WillCascadeOnDelete(false);
        }
    }
}
