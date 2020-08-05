using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.infrastructure
{
    public class Email
    {
        public int ID { get; set; }

        public string From { get; set; }
        public string To { get; set; }
        public string pass { get; set; }
        public string path { get; set; }
        public string supj { get; set; }
        public string body { get; set; }
    }

    public class EmailConfigurations : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(c=>c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.From).IsRequired();
            builder.Property(c => c.To).IsRequired();
            builder.Property(c => c.supj).IsRequired();
            builder.Property(c => c.pass).IsRequired();
            builder.Property(c => c.path);
            builder.Property(c => c.body).IsRequired();







        }
    }
}
