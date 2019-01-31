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
        static int i = 0;
        public TestDbContext()
        {
            if (i == 0)
            {
                if (!Database.CanConnect())
                {
                    try
                    {                      
                        Database.EnsureCreated();
                        i++;
                    }
                    catch (Exception)
                    {
                        Database.EnsureDeleted();
                    }
                }
            }      



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
                .UseLazyLoadingProxies()//延迟加载
                .UseSqlServer(Configuration.AppSettings.ConnectString);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<DestinationSeat> DestinationSeats { get; set; }
        public DbSet<ExtraSeatInfo> ExtraSeatInfos { get; set; }
        public DbSet<FreezeSeatInfo> FreezeSeatInfos { get; set; }
        public DbSet<SaleSeatInfo> SaleSeatInfos { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainCarriage> TrainCarriages { get; set; }
        public DbSet<TrainNumber> TrainNumbers { get; set; }
        public DbSet<TrainOrder> TrainOrders { get; set; }
        public DbSet<TrainOrderItem> TrainOrderItems { get; set; }
        public DbSet<TrainSeatPrice> TrainSeatPrices { get; set; }
        public DbSet<TrainShift> TrainShifts { get; set; }
        public DbSet<TrainStation> TrainStations { get; set; }
        public DbSet<TrainStationWay> TrainStationWays { get; set; }
        public DbSet<TrainTicketPrice> TrainTicketPrices { get; set; }
        public DbSet<UserContract> UserContracts { get; set; }

        public DbSet<CarriageTypeConfig> CarriageTypeConfigs { get; set; }
        public DbSet<LocationSeatTypeConfig> LocationSeatTypeConfigs { get; set; }
        public DbSet<SeatTypeConfig> SeatTypeConfigs { get; set; } 
        public DbSet<TrainTypeConfig> TrainTypeConfigs { get; set; }


 


    }
}
