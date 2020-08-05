using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Labs.infrastructure
{
    public class Lab
    {
        public int ID { get; set; }
        public string LabName { get; set; }
        
        public bool isDeleted { get; set; }
        public ICollection<LabTest> Lt { get; set; }
        public ICollection<User> Users { get; set; }


    }
    public class LabConfigurations : IEntityTypeConfiguration<Lab>
    {
        public void Configure(EntityTypeBuilder<Lab> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.LabName).IsRequired();
            builder.Property(c => c.isDeleted).IsRequired().HasDefaultValue(false);

            builder.HasData(new Lab { ID = 1, LabName = "Pure", isDeleted = false });
        }
    }
}
