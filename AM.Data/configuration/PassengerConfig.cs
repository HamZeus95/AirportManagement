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
    class PassengerConfig : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            // Définition du mapping Table-Per-Hierarchy (TPH)
            builder.ToTable("Passengers");

            /** Utilisation de la discrimination pour définir la colonne IsTraveller **/
            builder.HasDiscriminator<PassengerType>("IsTraveller")
                .HasValue<Passenger>(PassengerType.None)
                .HasValue<Traveller>(PassengerType.Traveller)
                .HasValue<Staff>(PassengerType.Staff);
            
        }
    }
}
