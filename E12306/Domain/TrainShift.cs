using E12306.Common;
using E12306.Common.Enum;
using E12306.Util;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E12306.Domain
{
    /// <summary>
    ///    当天车次 实体
    /// </summary>
    public class TrainShift : EntityBase
    {
        protected TrainShift()
        {

        }
        public TrainShift(TrainNumber TrainNumber, Train Train, DateTimeOffset Date)
        {
            Id = Guid.NewGuid();
            this.TrainNumber = TrainNumber ?? throw new ArgumentNullException("TrainNumber");
            this.Train = Train ?? throw new ArgumentNullException("TrainNumber");
            this.Date = Date;

            Version = 0;
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;

            ExtraSeats = new List<Seat>();
            SaleSeats = new List<DestinationSeat>();
            FreezeSeats = new List<DestinationSeat>();
            foreach (var trainCarriage in Train.TrainCarriages)
            {
                foreach (var seat in trainCarriage.Seats)
                {
                    ExtraSeats.Add(seat);
                }
            }
        }


        /// <summary>
        /// 车次
        /// </summary>
        public TrainNumber TrainNumber { get; private set; }

        /// <summary>
        /// 当天运行的火车
        /// </summary>
        public Train Train { get; set; }

        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTimeOffset Date { get; private set; }


        /// <summary>
        /// 剩余的座位信息
        /// </summary>
        public IList<Seat> ExtraSeats { get; private set; }


        /// <summary>
        /// 已销售的座位信息
        /// </summary>
        public IList<DestinationSeat> SaleSeats { get; private set; }

        /// <summary>
        /// 冻结的座位信息
        /// </summary>
        public IList<DestinationSeat> FreezeSeats { get; private set; }



        public void AddSaleSeat(Seat Seat)
        {
            ExtraSeats.Add(Seat);
        }

        public void AddSaleSeat(IList<Seat> Seats)
        {
            foreach (var seat in Seats)
            {
                ExtraSeats.Add(seat);
            }

        }

        public void RemoveSaleSeat(IList<Seat> Seats)
        {
            foreach (var seat in Seats)
            {
                ExtraSeats.Remove(seat);
            }
        }





    }

    public class DestinationSeat : EntityBase
    {
        protected DestinationSeat()
        {

        }
        public DestinationSeat(Seat Seat, IList<TrainStationWay> TrainStationWays)
        {
            this.Seat = Seat;
            this.TrainStationWays = TrainStationWays;

            Version = 0;
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }
        public Seat Seat { get; private set; }


        public IList<TrainStationWay> TrainStationWays { get; private set; }
    }



}
