using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManager.Data.Configurations
{
    public class GMUserConfig : IEntityTypeConfiguration<GMUser>
    {
        public void Configure(EntityTypeBuilder<GMUser> builder)
        {
            builder
                .HasIndex(email => email.Email)
                .IsUnique();
        }
    }
}
