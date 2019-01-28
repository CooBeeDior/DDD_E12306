using E12306.Common;
using E12306.Common.Enum;
using E12306.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.Db
{

    public class TestDbContext : DbContext
    {
        public TestDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(Configuration.AppSettings.ConnectString);


        }

        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<TrainShift> TrainShifts { get; set; }
        public DbSet<TrainOrder> TrainOrders { get; set; }



        public DbSet<CarriageTypeConfig> CarriageTypeConfigs { get; set; }
        public DbSet<LocationSeatTypeConfig> LocationSeatTypeConfigs { get; set; }
        public DbSet<SeatTypeConfig> SeatTypeConfigs { get; set; }
        public DbSet<TrainTypeConfig> TrainTypeConfigs { get; set; }
    



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      


     

        }


    }
}
