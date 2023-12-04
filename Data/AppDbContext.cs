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
        //public DbSet<Schedule> CustomSchedule { get; set; }
        //public DbSet<TimeBlock> TimeBlocks { get; set; }

    }
}

