using IManageService.BusinessLogic.Domain;
using System.Data.Entity.ModelConfiguration;

namespace IManageService.Persistence.EntityConfigurations
{
    /// <summary>
    /// A class which contains constraints configuration of table ClockInOuts
    /// </summary>
    public class ClockInOutConfiguration : EntityTypeConfiguration<ClockInOut>
    {
        public ClockInOutConfiguration()
        {
            ToTable("ClockInOuts");

            HasKey(clockInOut => clockInOut.Id);

            Property(clockInOut => clockInOut.ClockInDateTime)
                .IsOptional()
                .HasColumnType("datetime2");

            Property(clockInOut => clockInOut.EmployeePinCode)
                .IsRequired()
                .HasMaxLength(4);

            Property(clockInOut => clockInOut.ClockOutDateTime)
                .IsOptional()
                .HasColumnType("datetime2");

        }
    }
}
