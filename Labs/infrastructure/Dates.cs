using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.infrastructure
{
    public class Dates
    {
        public int ID { get; set; }
        public int LabID { get; set; }
        public Lab lab { get; set; }
        public DateTime Date { get; set; }
        public bool isBooked { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Time>  Times { get; set; }

    }
    public class DatesConfigurations : IEntityTypeConfiguration<Dates>
    {
        public void Configure(EntityTypeBuilder<Dates> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.Date).IsRequired();
            builder.Property(c => c.LabID).IsRequired();
            builder.Property(c => c.isBooked).IsRequired().HasDefaultValue(false);
            builder.Property(c => c.IsDeleted).IsRequired().HasDefaultValue(false);

           
            
        }
    }
}
