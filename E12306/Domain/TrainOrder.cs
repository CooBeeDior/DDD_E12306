using E12306.Common;
using E12306.Common.Enum;
using E12306.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace E12306.Domain
{
    /// <summary>
    /// 订单 聚合跟
    /// </summary>
    [Table("TrainOrder")]
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

           
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }

        [Required]
        public string OrderNo { get; private set; }

       
        public TrainStation StartTrainStation { get; private set; }
   
        public TrainStation EndTrainStation { get; private set; }

      
        public IList<TrainOrderItem> TrainOrderItems { get; private set; }

        public int Count { get { return TrainOrderItems == null ? 0 : TrainOrderItems.Count; } }
        public decimal Amount { get { return TrainOrderItems == null ? 0 : TrainOrderItems.Sum(o => o.Price); } }
        [Required]
        public OrderStatusType Status { get; private set; }
        [Required]
        public CustomerInfo CustomerInfo { get; private set; }

        public void SetOrderStatusType(OrderStatusType Status)
        {
            this.Status = Status;
        }

    }


}
