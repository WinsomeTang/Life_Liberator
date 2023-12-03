using System;
using Microsoft.EntityFrameworkCore;
using Life_Liberator.Models;
using Microsoft.Extensions.Configuration;

namespace Life_Liberator.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> CustomSchedule { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configure foreign key relationship
        //    modelBuilder.Entity<Schedule>()
        //        .HasOne(s => s.User)
        //        .WithMany(u => u.CustomSchedules)
        //        .HasForeignKey(s => s.UserId);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}

