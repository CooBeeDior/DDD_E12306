using E12306.Common;
using E12306.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace E12306.Domain
{

    /// <summary>
    /// 实体
    /// </summary>
    [Table("TrainTicketPrice")]
    public class TrainTicketPrice : EntityBase
    {
        protected TrainTicketPrice()
        {

        }
        public TrainTicketPrice(TrainStation StartTrainStation, TrainStation EndTrainStation, IList<TrainSeatPrice> TrainSeatPrices) : base()
        {
            this.StartTrainStation = StartTrainStation;
            this.EndTrainStation = EndTrainStation;
            this.TrainSeatPrices = TrainSeatPrices ?? new List<TrainSeatPrice>();
        }
        //[Required]
        public virtual TrainStation StartTrainStation { get; private set; }
        //[Required]
        public virtual TrainStation EndTrainStation { get; private set; }
     
        public virtual IList<TrainSeatPrice> TrainSeatPrices { get; private set; }

        public void AddTrainSeatPrice(TrainSeatPrice TrainSeatPrice)
        {
            if (TrainSeatPrices.Where(o => o.SeatType == TrainSeatPrice.SeatType).Count() > 0)
            {
                throw new Exception("exsit same SeatType TrainSeatPrice");
            }
            TrainSeatPrices.Add(TrainSeatPrice);
        }

    }
 


 



}




