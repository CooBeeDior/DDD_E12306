using E12306.Common.Enum;
using E12306.Db;
using E12306.Domain;
using E12306.DomainEvent;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using E12306.DomainEvent.Impl;
namespace E12306
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化领域事件
            EventCollection.Subscribe(new WxOrderShippingEventHandle());
            EventCollection.Subscribe(new SmsOrderShippingEventHandle());
            EventCollection.Subscribe(new WxPaymentSucessEventHandle());
 
    
            TestDbContext testDbContext = new TestDbContext();

            TrainTypeConfig KtrainTypeConfig = new TrainTypeConfig("K", "快车");
            TrainTypeConfig ZtrainTypeConfig = new TrainTypeConfig("Z", "直达");
            TrainTypeConfig TtrainTypeConfig = new TrainTypeConfig("T", "特快");
            TrainTypeConfig DtrainTypeConfig = new TrainTypeConfig("D", "动车");
            TrainTypeConfig GtrainTypeConfig = new TrainTypeConfig("G", "高铁");
            TrainTypeConfig CtrainTypeConfig = new TrainTypeConfig("C", "城际");
            //testDbContext.Add(KtrainTypeConfig);
            //testDbContext.Add(ZtrainTypeConfig);
            //testDbContext.Add(TtrainTypeConfig);
            //testDbContext.Add(DtrainTypeConfig);
            //testDbContext.Add(GtrainTypeConfig);
            //testDbContext.Add(CtrainTypeConfig);

            CarriageTypeConfig hardSeatCarriageTypeConfig = new CarriageTypeConfig("硬座", "硬座");
            CarriageTypeConfig softSeatCarriageTypeConfig = new CarriageTypeConfig("软座", "软座");
            CarriageTypeConfig oneSeatCarriageTypeConfig = new CarriageTypeConfig("一等座", "一等座");
            CarriageTypeConfig twoSeatCarriageTypeConfig = new CarriageTypeConfig("二等座", "二等座");
            CarriageTypeConfig businessSeatCarriageTypeConfig = new CarriageTypeConfig("商务座", "商务座");
            CarriageTypeConfig hardSleepCarriageTypeConfig = new CarriageTypeConfig("硬卧", "硬卧");
            CarriageTypeConfig softSleepCarriageTypeConfig = new CarriageTypeConfig("软卧", "软卧");
            CarriageTypeConfig eatSleepCarriageTypeConfig = new CarriageTypeConfig("餐车", "餐车");
            //testDbContext.Add(hardSeatCarriageTypeConfig);
            //testDbContext.Add(softSeatCarriageTypeConfig);
            //testDbContext.Add(oneSeatCarriageTypeConfig);
            //testDbContext.Add(twoSeatCarriageTypeConfig);
            //testDbContext.Add(businessSeatCarriageTypeConfig);
            //testDbContext.Add(hardSleepCarriageTypeConfig);
            //testDbContext.Add(softSleepCarriageTypeConfig);
            //testDbContext.Add(eatSleepCarriageTypeConfig);

            IList<SeatTypeConfig> seatTypeConfigs = new List<SeatTypeConfig>();
            SeatTypeConfig oneSeatTypeConfig = new SeatTypeConfig("一等座", "一等座");
            SeatTypeConfig twoSeatTypeConfig = new SeatTypeConfig("二等座", "二等座");
            SeatTypeConfig businessSeatTypeConfig = new SeatTypeConfig("商务座", "商务座");
            seatTypeConfigs.Add(oneSeatTypeConfig);
            seatTypeConfigs.Add(twoSeatTypeConfig);
            seatTypeConfigs.Add(businessSeatTypeConfig);
            //testDbContext.AddRange(seatTypeConfigs);


            IList<SeatTypeConfig> sleepSeatTypeConfigs = new List<SeatTypeConfig>();
            SeatTypeConfig hardSleepSeatTypeConfig = new SeatTypeConfig("硬卧", "硬卧");
            SeatTypeConfig softSleepSeatTypeConfig = new SeatTypeConfig("软卧", "软卧");
            sleepSeatTypeConfigs.Add(hardSleepSeatTypeConfig);
            sleepSeatTypeConfigs.Add(softSleepSeatTypeConfig);
            //testDbContext.AddRange(sleepSeatTypeConfigs);


            LocationSeatTypeConfig toplocationSeatTypeConfig = new LocationSeatTypeConfig("Top", "上铺");
            LocationSeatTypeConfig middlelocationSeatTypeConfig = new LocationSeatTypeConfig("Middle", "上铺");
            LocationSeatTypeConfig downlocationSeatTypeConfig = new LocationSeatTypeConfig("Down", "上铺");
            LocationSeatTypeConfig alocationSeatTypeConfig = new LocationSeatTypeConfig("A", "A", true);
            LocationSeatTypeConfig blocationSeatTypeConfig = new LocationSeatTypeConfig("B", "B");
            LocationSeatTypeConfig clocationSeatTypeConfig = new LocationSeatTypeConfig("C", "C");
            LocationSeatTypeConfig dlocationSeatTypeConfig = new LocationSeatTypeConfig("D", "D");
            LocationSeatTypeConfig elocationSeatTypeConfig = new LocationSeatTypeConfig("E", "E");
            LocationSeatTypeConfig flocationSeatTypeConfig = new LocationSeatTypeConfig("F", "F", true);
            //testDbContext.AddRange(toplocationSeatTypeConfig);
            //testDbContext.AddRange(middlelocationSeatTypeConfig);
            //testDbContext.AddRange(downlocationSeatTypeConfig);
            //testDbContext.AddRange(alocationSeatTypeConfig);
            //testDbContext.AddRange(blocationSeatTypeConfig);
            //testDbContext.AddRange(clocationSeatTypeConfig);
            //testDbContext.AddRange(dlocationSeatTypeConfig);
            //testDbContext.AddRange(elocationSeatTypeConfig);
            //testDbContext.AddRange(flocationSeatTypeConfig);

            IList<LocationSeatTypeConfig> locationSeatTypeConfigs = new List<LocationSeatTypeConfig>();
            locationSeatTypeConfigs.Add(alocationSeatTypeConfig);
            locationSeatTypeConfigs.Add(flocationSeatTypeConfig);

            //初始化火车
            Train train = new Train("000001");
            IList<Train> trains = new List<Train>() { train };
            //testDbContext.AddRange(trains);

            //初始化车厢
            TrainCarriage trainCarriage1 = new TrainCarriage(train, 1, "商务车厢", businessSeatCarriageTypeConfig);
            TrainCarriage trainCarriage2 = new TrainCarriage(train, 2, "一等座车厢", oneSeatCarriageTypeConfig);
            TrainCarriage trainCarriage3 = new TrainCarriage(train, 3, "一等座车厢", oneSeatCarriageTypeConfig);
            TrainCarriage trainCarriage4 = new TrainCarriage(train, 4, "二等座车厢", twoSeatCarriageTypeConfig);
            TrainCarriage trainCarriage5 = new TrainCarriage(train, 5, "二等座车厢", twoSeatCarriageTypeConfig);
            TrainCarriage trainCarriage6 = new TrainCarriage(train, 6, "餐车", eatSleepCarriageTypeConfig);
            TrainCarriage trainCarriage7 = new TrainCarriage(train, 7, "硬座车厢", hardSleepCarriageTypeConfig);
            TrainCarriage trainCarriage8 = new TrainCarriage(train, 8, "软卧车厢", softSleepCarriageTypeConfig);
            IList<TrainCarriage> trainCarriages = new List<TrainCarriage>();
            trainCarriages.Add(trainCarriage1);
            trainCarriages.Add(trainCarriage2);
            trainCarriages.Add(trainCarriage3);
            trainCarriages.Add(trainCarriage4);
            trainCarriages.Add(trainCarriage5);
            trainCarriages.Add(trainCarriage6);
            trainCarriages.Add(trainCarriage7);
            trainCarriages.Add(trainCarriage8);
            //testDbContext.AddRange(trainCarriages);

            //商务座座位 1排2个
            IList<Seat> seatsbusiness = new List<Seat>();
            for (int i = 1; i <= 8; i++)
            {

                foreach (var item in locationSeatTypeConfigs)
                {
                    businessSeatTypeConfig.SetLocationSeatTypeConfig(item);
                    Seat seat = new Seat(trainCarriage1, i, $"{i}{item.Code}", businessSeatTypeConfig);
                    seatsbusiness.Add(seat);
                }
            }

            locationSeatTypeConfigs.Add(blocationSeatTypeConfig);
            locationSeatTypeConfigs.Add(elocationSeatTypeConfig);
            //一等座座位 1排4个
            IList<Seat> seats1 = new List<Seat>();
            for (int i = 1; i <= 12; i++)
            {

                foreach (var item in locationSeatTypeConfigs)
                {
                    oneSeatTypeConfig.SetLocationSeatTypeConfig(item);
                    Seat seat = new Seat(trainCarriage2, i, $"{i}{item.Code}", oneSeatTypeConfig);
                    seats1.Add(seat);

                    Seat seat1 = new Seat(trainCarriage3, i, $"{i}{item.Code}", oneSeatTypeConfig);
                    seatsbusiness.Add(seat1);
                }



            }

            //二等座座位 1排5个
            locationSeatTypeConfigs.Add(clocationSeatTypeConfig);
            IList<Seat> seats2 = new List<Seat>();
            for (int i = 1; i <= 12; i++)
            {
                foreach (var item in locationSeatTypeConfigs)
                {
                    twoSeatTypeConfig.SetLocationSeatTypeConfig(item);
                    Seat seat = new Seat(trainCarriage4, i, $"{i}{item.Code}", twoSeatTypeConfig);
                    seats2.Add(seat);

                    Seat seat1 = new Seat(trainCarriage5, i, $"{i}{item.Code}", twoSeatTypeConfig);
                    seats2.Add(seat);
                }

            }

            //软卧
            IList<LocationSeatTypeConfig> sleeplocationSeatTypeConfigs = new List<LocationSeatTypeConfig>();
            sleeplocationSeatTypeConfigs.Add(toplocationSeatTypeConfig);
            sleeplocationSeatTypeConfigs.Add(downlocationSeatTypeConfig);
            IList<Seat> seatSoftSleep = new List<Seat>();
            for (int i = 1; i <= 10; i++)
            {

                foreach (var item in sleeplocationSeatTypeConfigs)
                {
                    softSleepSeatTypeConfig.SetLocationSeatTypeConfig(item);
                    Seat seat = new Seat(trainCarriage7, i, $"{i}{item.Code}", softSleepSeatTypeConfig);
                    seatSoftSleep.Add(seat);
                }

            }



            //硬卧
            sleeplocationSeatTypeConfigs.Add(middlelocationSeatTypeConfig);
            IList<Seat> seatHardSleep = new List<Seat>();
            for (int i = 1; i <= 10; i++)
            {

                foreach (var item in sleeplocationSeatTypeConfigs)
                {
                    hardSleepSeatTypeConfig.SetLocationSeatTypeConfig(item);
                    Seat seat = new Seat(trainCarriage8, i, $"{i}{item.Code}", hardSleepSeatTypeConfig);
                    seatHardSleep.Add(seat);
                }

            }


            IList<TrainStation> trainStations = new List<TrainStation>();
            for (int i = 1; i <= 10; i++)
            {
                Station station = new Station(i.ToString(), $"站{i.ToString()}");
                var trainStation = new TrainStation(station, i);
                trainStations.Add(trainStation);
            }
            //testDbContext.AddRange(trainStations);

            IList<TrainTicketPrice> trainTicketPrices = new List<TrainTicketPrice>();
            var currentTrainStation = trainStations.FirstOrDefault();
            foreach (var item in trainStations.Skip(1))
            {
                IList<TrainSeatPrice> trainSeatPrices = new List<TrainSeatPrice>();

                TrainSeatPrice trainSeatPrice = new TrainSeatPrice(oneSeatTypeConfig, 20);
                trainSeatPrices.Add(trainSeatPrice);

                trainSeatPrice = new TrainSeatPrice(twoSeatTypeConfig, 10);
                trainSeatPrices.Add(trainSeatPrice);

                trainSeatPrice = new TrainSeatPrice(businessSeatTypeConfig, 100);
                trainSeatPrices.Add(trainSeatPrice);

                trainSeatPrice = new TrainSeatPrice(softSleepSeatTypeConfig, 80);
                trainSeatPrices.Add(trainSeatPrice);

                trainSeatPrice = new TrainSeatPrice(hardSleepSeatTypeConfig, 40);
                trainSeatPrices.Add(trainSeatPrice);

                TrainTicketPrice trainTicketPrice = new TrainTicketPrice(currentTrainStation, item, trainSeatPrices);
                trainTicketPrices.Add(trainTicketPrice);
                currentTrainStation = item;
            }
            //testDbContext.AddRange(trainTicketPrices);

            TrainNumber trainNumber = new TrainNumber("G8888", "高铁8888次", GtrainTypeConfig, trainStations, trainTicketPrices, trains);
            DateTimeOffset date = new DateTime(2019, 1, 31);
            TrainShift trainShift = new TrainShift(trainNumber, train, date);

            //初始化客户信息
            CustomerInfo customerInfo = new CustomerInfo("客户1", "1888888888");
            var userContract1 = new UserContract("张三", "3604031324567835", ContractUserType.Children);
            var userContract2 = new UserContract("李四", "3604564554545456");
            var userContract11 = new UserContract("刘六2", "3604564554545454");
            customerInfo.AddUserContract(userContract1);
            customerInfo.AddUserContract(userContract2);
            customerInfo.AddUserContract(userContract11);
            var sse = customerInfo.BookTrainTicket(trainShift, trainStations[2], trainStations[5], oneSeatTypeConfig, customerInfo, customerInfo.UserContracts);

            //初始化客户信息
            CustomerInfo customerInfo1 = new CustomerInfo("客户2", "1222222222");
            var userContract3 = new UserContract("王五", "3604031324567833");
            var userContract4 = new UserContract("刘六", "3604564554545454");
            var userContract41 = new UserContract("刘六11", "3604564554545454");
            var userContract421 = new UserContract("刘六22", "3604564554545454");
            customerInfo1.AddUserContract(userContract3);
            customerInfo1.AddUserContract(userContract4);
            customerInfo1.AddUserContract(userContract41);
            customerInfo1.AddUserContract(userContract421);
            var s1s = customerInfo1.BookTrainTicket(trainShift, trainStations[7], trainStations[9], oneSeatTypeConfig, customerInfo1, customerInfo1.UserContracts);

            //TrainShift trainShift = new TrainShift(trainNumber)

            CustomerInfo customerInfo2 = new CustomerInfo("客户3", "13333333");
            var userContract5 = new UserContract("徐梦", "3604031324567831");
            var userContract6 = new UserContract("刘爽", "3604564554545452");
            customerInfo2.AddUserContract(userContract5);
            customerInfo2.AddUserContract(userContract6);
            var sdd = customerInfo2.BookTrainTicket(trainShift, trainStations[1], trainStations[9], oneSeatTypeConfig, customerInfo2, customerInfo2.UserContracts);

            testDbContext.Add(sdd.Item3);
            //testDbContext.Add(customerInfo1);
            //testDbContext.Add(customerInfo2);
            testDbContext.SaveChanges();
            var ss = testDbContext.CustomerInfos.FirstOrDefault();
        }



    }

    public class A
    {
        public string Name { get; set; }



    }




















}



