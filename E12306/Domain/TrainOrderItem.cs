using E12306.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{
    /// <summary>
    /// 实体
    /// </summary>
    [Table("TrainOrderItem")]
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



            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }
 
        public Seat Seat { get; set; }
 
        public UserContract UserContract { get; set; }
        [Required]
        public decimal Price { get; set; }



    }
}
