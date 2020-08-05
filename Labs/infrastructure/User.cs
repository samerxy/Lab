using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.infrastructure
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? LabID { get; set; }
        public Lab lab { get; set; }
        public int RoleID { get; set; }
        public Role role { get; set; }
        public bool isDeleted { get; set; }
    }

    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.UserName).IsRequired();
            builder.Property(c => c.Password).IsRequired(); 
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Phone).IsRequired();
            builder.Property(c => c.RoleID).IsRequired();
            builder.Property(c => c.LabID).HasDefaultValue(null);
            builder.Property(c => c.isDeleted).IsRequired().HasDefaultValue(false);

            
               builder.HasOne(d => d.role)
               .WithMany(e => e.users)
               .HasForeignKey(f => f.RoleID)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.lab)
               .WithMany(e => e.Users)
               .HasForeignKey(f => f.LabID)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new User
            {
                ID = 1,
                Name = "نادرة رعد ",
                UserName = "Admin",
                Password = "Admin123",
                Email = "test@gmail.com",
                Phone = "07712365899",
                RoleID = 1,
                isDeleted = false

            }) ;
            builder.HasData(new User
            {
                ID = 2,
                Name = "اية اسماعيل",
                UserName = "User",
                Password = "User123",
                Email = "test@gmail.com",
                Phone = "07712365899",
                RoleID = 2,
                isDeleted=false
            });
        }
       
    }
}
