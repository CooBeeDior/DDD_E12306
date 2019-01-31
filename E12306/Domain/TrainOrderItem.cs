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
        public TrainOrderItem(Seat Seat, UserContract UserContract, decimal Price) : base()
        {
            this.Seat = Seat;
            this.UserContract = UserContract;
            this.Price = Price;
        }
        [Required]
        public virtual Seat Seat { get; private set; }
        [Required]
        public virtual UserContract UserContract { get; private set; }

        [Required]
        public decimal Price { get; private set; }



    }
}
