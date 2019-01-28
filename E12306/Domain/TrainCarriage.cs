using E12306.Common;
using E12306.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.Domain
{

    /// <summary>
    /// 火车车厢 （实体）
    /// </summary>
    public class TrainCarriage : EntityBase
    {
        protected TrainCarriage()
        { }
        public TrainCarriage(Train Train, int Order, string Name, CarriageTypeConfig CarriageType) : this(Train, Order, Name, CarriageType, null)
        {

        }
        public TrainCarriage(Train Train, int Order, string Name, CarriageTypeConfig CarriageType, IList<Seat> Seats)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.Order = Order;
            this.CarriageType = CarriageType;
            this.Seats = Seats ?? new List<Seat>();
            this.Train = Train;
            Version = 0;
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;

            Train.AddTrainCarriage(this);
        }


        public void AddSeat(Seat Seat)
        {
            Seats.Add(Seat);
        }
        public void RemoveSeat(Seat Seat)
        {
            Seats.Remove(Seat);
        }

        public Train Train { get; private set; }
        public string Name { get; private set; }

        public int Order { get; private set; }

        public CarriageTypeConfig CarriageType { get; private set; }

        public IList<Seat> Seats { get; private set; }


        public void SetOrder(int Order)
        {
            this.Order = Order;
        }
    }
}
