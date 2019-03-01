using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{

    [Table("TrainSeatPrice")]
    public class TrainSeatPrice : EntityBase
    {
        private TrainSeatPrice()
        {
        }

        public TrainSeatPrice(TrainTicketPrice TrainTicketPrice, SeatTypeConfig SeatType, decimal Price) : this(TrainTicketPrice, SeatType, Price, false)
        {

        }
        public TrainSeatPrice(TrainTicketPrice TrainTicketPrice, SeatTypeConfig SeatType, decimal Price, bool IsDefault) : base()
        {
            this.TrainTicketPrice = TrainTicketPrice;
            this.SeatType = SeatType;
            this.Price = Price;
            this.IsDefault = IsDefault;
            this.TrainTicketPrice.AddTrainSeatPrice(this);
        }

        public TrainTicketPrice TrainTicketPrice { get; }

        public virtual SeatTypeConfig SeatType { get; private set; }

        public decimal Price { get; private set; }


        public bool IsDefault { get; private set; }

        public void SetDefault(bool IsDefault)
        {
            this.IsDefault = IsDefault;
        }



    }
}
