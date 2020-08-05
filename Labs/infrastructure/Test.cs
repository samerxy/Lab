using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.infrastructure
{
    public class Test
    {
        public int ID { get; set; }
        public int LabID { get; set; }
        public Lab lab { get; set; }
        public string TestName { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class TestConfigurations : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.TestName).IsRequired();
            builder.Property(c => c.LabID).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
