using E12306.Common;
using E12306.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{

    /// <summary>
    /// 火车车厢 （实体）
    /// </summary>
    [Table("TrainCarriage")]
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
        [Required]
        public Train Train { get; private set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; private set; }

        [Required]
        public int Order { get; private set; }

        [Required]
        public CarriageTypeConfig CarriageType { get; private set; }

        public IList<Seat> Seats { get; private set; }


        public void SetOrder(int Order)
        {
            this.Order = Order;
        }
    }
}
