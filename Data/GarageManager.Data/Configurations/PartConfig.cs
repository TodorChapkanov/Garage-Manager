using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManager.Data.Configurations
{
    public class PartConfig : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder
                .HasOne(part => part.Service)
                .WithMany(service => service.Parts)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
