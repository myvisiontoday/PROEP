using IManageService.BusinessLogic.Domain;
using System.Data.Entity.ModelConfiguration;

namespace IManageService.Persistence.EntityConfigurations
{
    /// <summary>
    /// A class which contains constraints configuration of table clients
    /// </summary>
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            ToTable("Clients");

            HasKey(client => client.Id);

            Property(client => client.UserName)
                .IsRequired()
                .HasMaxLength(255);

            Property(client => client.PassWord)
                .IsRequired()
                .HasMaxLength(15);

            Property(client => client.IsSubscriptionsExpired)
                .IsRequired();

            Property(client => client.SubscriptionsStartDate)
                .IsRequired()
                .HasColumnType("datetime2");

            Property(client => client.SubscriptionsEndDate)
                .IsRequired()
                .HasColumnType("datetime2");
        }
    }
}
