using GM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GM.Data.Configurations
{
    public class VehicleModelConfig : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder
                .HasOne(model => model.Manufacturer)
                .WithMany(manufacturer => manufacturer.VehicleModels)
                .HasForeignKey(model => model.ManufactirerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
