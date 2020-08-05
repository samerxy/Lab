using Labs.infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Labs.Data
{
    public class LabsContext:DbContext
    {
        public LabsContext(DbContextOptions options) : base(options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

        }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Dates> dates { get; set; }
        public DbSet<Test>  tests { get; set; }
        public DbSet<LabDateTest> Ldts { get; set; }
        public DbSet<LabTest> lt { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Email> emails { get; set; }
        public DbSet<Time> times { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
