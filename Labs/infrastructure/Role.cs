using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.infrastructure
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleType { get; set; }

        public ICollection<User> users { get; set; }
    }

    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.RoleType).IsRequired();

            builder.HasData(new Role
            {
                ID = 1,
                RoleType = "ADMIN"
            });
            builder.HasData(new Role
            {
                ID = 2,
                RoleType = "USER"
            });

        }
    }
}