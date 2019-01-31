using E12306.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{
    /// <summary>
    /// 冻结座位信息 值对象
    /// </summary>   
    [Table("FreezeSeatInfo")]
    public class FreezeSeatInfo : ValueObject<FreezeSeatInfo>
    {
        protected FreezeSeatInfo()
        {

        }
        public FreezeSeatInfo(TrainShift TrainShift, DestinationSeat DestinationSeat) : base()
        {
            this.DestinationSeat = DestinationSeat;
            this.TrainShift = TrainShift;

            TrainShift.FreezeSeatInfos.Add(this);
        }
        //[Required]
        public virtual TrainShift TrainShift { get; private set; }

        [Required]
        public virtual DestinationSeat DestinationSeat { get; private set; }


        protected override bool EqualsCore(FreezeSeatInfo other)
        {
            return this.TrainShift == other.TrainShift && this.DestinationSeat == other.DestinationSeat;

        }

        protected override int GetHashCodeCore()
        {
            var a = TrainShift.GetHashCode();
            var b = DestinationSeat.GetHashCode();
            return a ^ b;
        }
    }
}
