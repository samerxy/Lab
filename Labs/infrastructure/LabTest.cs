using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.infrastructure
{
    public class LabTest
    {
        public int ID { get; set; }
        public int TestID { get; set; }
        public Test test { get; set; }
        public int LabID { get; set; }
        public Lab lab { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class LTConfigurations : IEntityTypeConfiguration<LabTest>
    {
        public void Configure(EntityTypeBuilder<LabTest> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(c => c.LabID).IsRequired();
            builder.Property(c => c.TestID).IsRequired();
        }
    }
}
