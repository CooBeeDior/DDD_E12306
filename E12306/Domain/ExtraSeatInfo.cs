using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using E12306.Common;
namespace E12306.Domain
{
    /// <summary>
    ///剩余座位的信息 值对象
    /// </summary>
    /// 
    [Table("ExtraSeatInfo")]
    public class ExtraSeatInfo : ValueObject<ExtraSeatInfo>
    {
        protected ExtraSeatInfo()
        {

        }
        public ExtraSeatInfo(TrainShift TrainShift, Seat Seat) : base()
        {
            this.Seat = Seat;
            this.TrainShift = TrainShift;
        }


        //[Required]
        public virtual TrainShift TrainShift { get; private set; }

        [Required]
        public virtual Seat Seat { get; private set; }


        protected override bool EqualsCore(ExtraSeatInfo other)
        {
            return this.TrainShift == other.TrainShift && this.Seat == other.Seat;
        }

        protected override int GetHashCodeCore()
        {
            var a = TrainShift.GetHashCode();
            var b = Seat.GetHashCode();
            return a ^ b;
        }
    }
}
