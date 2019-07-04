using GM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GM.Data.Configurations
{
    public class TransmissionTypeConfig : IEntityTypeConfiguration<TransmissionType>
    {
        public void Configure(EntityTypeBuilder<TransmissionType> builder)
        {
            builder
                .HasMany(transmission => transmission.Cars)
                .WithOne(car => car.Transmission)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
