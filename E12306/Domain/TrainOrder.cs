using E12306.Common;
using E12306.Common.Enum;
using E12306.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E12306.Domain
{
    public class TrainOrder : EntityBase
    {
        protected TrainOrder()
        { }
        public TrainOrder(TrainStation StartTrainStation, TrainStation EndTrainStation, CustomerInfo CustomerInfo, IList<TrainOrderItem> TrainOrderItems)
        {
            Id = Guid.NewGuid();
            this.OrderNo = GenerateOrderNoHelp.GenerateOrderNo();
            this.StartTrainStation = StartTrainStation;
            this.EndTrainStation = EndTrainStation;
            this.CustomerInfo = CustomerInfo;
            this.Status = OrderStatusType.PrePay;
            this.TrainOrderItems = TrainOrderItems;

            Version = 0;
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }


        public string OrderNo { get; private set; }

        public TrainStation StartTrainStation { get; private set; }
        public TrainStation EndTrainStation { get; private set; }

        public IList<TrainOrderItem> TrainOrderItems { get; private set; }

        public int Count { get { return TrainOrderItems == null ? 0 : TrainOrderItems.Count; } }
        public decimal Amount { get { return TrainOrderItems == null ? 0 : TrainOrderItems.Sum(o => o.Price); } }

        public OrderStatusType Status { get; private set; }

        public CustomerInfo CustomerInfo { get; private set; }

        public void SetOrderStatusType(OrderStatusType Status)
        {
            this.Status = Status;
        }

    }

    public class TrainOrderItem : EntityBase
    {
        protected TrainOrderItem()
        {

        }
        public TrainOrderItem(Seat Seat, UserContract UserContract, decimal Price)
        {
            Id = Guid.NewGuid();
            this.Seat = Seat;
            this.UserContract = UserContract;

            this.Price = Price;


            Version = 0;
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }
        public Seat Seat { get; set; }

        public UserContract UserContract { get; set; }

        public decimal Price { get; set; }



    }
}
