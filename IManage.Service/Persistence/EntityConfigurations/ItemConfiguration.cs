using IManageService.BusinessLogic.Domain;
using System.Data.Entity.ModelConfiguration;

namespace IManageService.Persistence.EntityConfigurations
{
    /// <summary>
    /// A class which contains constraints configuration of table Items
    /// </summary>
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            ToTable("Items");

            HasKey(item => item.Id);

            Property(item => item.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(item => item.Quantity)
                .IsRequired();

            Property(item => item.Price)
                .IsRequired();

            Property(item => item.AddedDate)
                .IsRequired()
                .HasColumnType("datetime2");

            Property(item => item.DeletedDate)
                .IsOptional()
                .HasColumnType("datetime2");

            Property(item => item.IsDeleted)
                .IsRequired();
        }
    }
}
