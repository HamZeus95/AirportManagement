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
    class TravellerConfig : IEntityTypeConfiguration<Traveller>
    {
        public void Configure(EntityTypeBuilder<Traveller> builder)
        {
            builder.ToTable("Travellers");
        }
    }
}
