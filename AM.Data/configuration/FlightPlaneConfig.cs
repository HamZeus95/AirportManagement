using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.configuration
{
    internal class FlightPlaneConfig : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(f => f.Passengers)
                   .WithMany(p => p.Flights)
                   .UsingEntity(jointure => jointure.ToTable("FP"));

            builder.HasOne(f => f.MyPlane)
                   .WithMany(p => p.Flights)
                   .HasForeignKey(f => f.PlaneId)
                   .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
