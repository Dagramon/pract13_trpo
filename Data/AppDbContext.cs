using Microsoft.EntityFrameworkCore;

using pract12_trpo.Classes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_trpo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<InterestGroup> InterestGroup { get; set; }
        public DbSet<UserInterestGroup> UsersInterestGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.ects;Database=KaramovUsersDB;User Id=student_10;Password=student_10;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<UserInterestGroup>()
                .HasKey(ig => new { ig.UserId, ig.InterestGroupId });

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(ig => ig.User)
                .WithMany(u => u.UserInterestGroups)
                .HasForeignKey(ig => ig.UserId);

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(ig => ig.InterestGroup)
                .WithMany(i => i.UserInterestGroups)
                .HasForeignKey(ig => ig.InterestGroupId);
        }
    }
}
