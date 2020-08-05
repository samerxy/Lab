using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.infrastructure
{
    public class LabDateTest
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int age { get; set; }
        public int LabID { get; set; }
        public Lab lab { get; set; }
        public DateTime Date { get; set; }        
        public int TimeID { get; set; }
        public Time Time { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDone { get;  set; }
    }
    public class LDTConfigurations : IEntityTypeConfiguration<LabDateTest>
    {
        public void Configure(EntityTypeBuilder<LabDateTest> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.FullName).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(c => c.LabID).IsRequired();
            builder.Property(c => c.Date).IsRequired();
            builder.Property(c => c.TimeID).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.age).IsRequired();

            //builder.HasOne(s => s.Time)
            //    .WithMany(a => a.lDTs)
            //    .HasForeignKey(q => q.TimeID)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
