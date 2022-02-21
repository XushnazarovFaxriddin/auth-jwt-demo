using Entitys.Configurations;
using Entitys.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(
                new UserConfiguration()
            );
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique();
        }

        public DbSet<User> Users { get; set; }
    }
}
