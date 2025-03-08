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
    class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");

            // Définition de la clé primaire composite
            builder.HasKey(r => new { r.PassportNumber, r.FlightId });

            // setup relationqhip with Passenger
            builder.HasOne(r => r.Passenger)
            .WithMany()
            .HasForeignKey(r => r.PassportNumber)
            .OnDelete(DeleteBehavior.Cascade);

            // setup relationship with Flight
            builder.HasOne(r => r.Flight)
                .WithMany()
                .HasForeignKey(r => r.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
