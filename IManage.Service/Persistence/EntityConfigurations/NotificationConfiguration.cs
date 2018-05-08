using IManageService.BusinessLogic.Domain;
using System.Data.Entity.ModelConfiguration;

namespace IManageService.Persistence.EntityConfigurations
{
    /// <summary>
    /// A class which contains constraints configuration of table Notifications
    /// </summary>
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            ToTable("Notifications");

            HasKey(notification => notification.Id);

            Property(notification => notification.Message)
                .IsRequired()
                .HasMaxLength(255);

            Property(notification => notification.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2");

            Property(notification => notification.DeletedDate)
                .IsOptional()
                .HasColumnType("datetime2");

            Property(notification => notification.IsResolved)
                .IsRequired();

        }
    }
}
