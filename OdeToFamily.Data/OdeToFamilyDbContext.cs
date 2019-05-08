using Microsoft.EntityFrameworkCore;
using OdeToFamily.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFamily.Data
{
    public class OdeToFamilyDbContext : DbContext
    {
        public DbSet<People> People { get; set; }
        public DbSet<Relations> Relations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=odetofamily;Username=postgres;Password=password");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Relations>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
