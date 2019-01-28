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
        public TrainTicketPrice(TrainStation StartTrainStation, TrainStation EndTrainStation, IList<TrainSeatPrice> TrainSeatPrices)
        {
            this.StartTrainStation = StartTrainStation;
            this.EndTrainStation = EndTrainStation;
            this.TrainSeatPrices = TrainSeatPrices;

           
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }
    
        public TrainStation StartTrainStation { get; private set; }
  
        public TrainStation EndTrainStation { get; private set; }

        public IList<TrainSeatPrice> TrainSeatPrices { get; private set; }

        public void AddTrainSeatPrice(TrainSeatPrice TrainSeatPrice)
        {
            if (TrainSeatPrices == null)
            {
                TrainSeatPrices = new List<TrainSeatPrice>();
            }
            if (TrainSeatPrices.Where(o => o.SeatType == TrainSeatPrice.SeatType).Count() > 0)
            {
                throw new Exception("exsit same SeatType TrainSeatPrice");
            }
            TrainSeatPrices.Add(TrainSeatPrice);
        }





    }


    public class TrainSeatPrice : EntityBase
    {
        protected TrainSeatPrice()
        {

        }
        public TrainSeatPrice(SeatTypeConfig SeatType, decimal Price, bool IsDefault = false)
        {
            this.SeatType = SeatType;
            this.Price = Price;
            this.IsDefault = IsDefault;

           
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }

        public bool IsDefault { get; private set; }
        public SeatTypeConfig SeatType { get; private set; }

        public decimal Price { get; private set; }

        public void SetPrice(decimal Price)
        {
            this.Price = Price;
        }

        public override string ToString()
        {
            return $"座位类型：【{SeatType}】,价格：{Price}，是否默认：{IsDefault}";
        }
    }


    public class TrainTicketConfig
    {
        public decimal DiscountStudent { get; private set; }

    }



}




