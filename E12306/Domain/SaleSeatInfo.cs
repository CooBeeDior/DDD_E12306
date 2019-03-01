using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using E12306.Common;
namespace E12306.Domain
{
    /// <summary>
    /// 销售座位信息 类对象
    /// </summary>
    [Table("SaleSeatInfo")]
    public class SaleSeatInfo : ValueObject<SaleSeatInfo>
    {
        private SaleSeatInfo()
        {

        }
        public SaleSeatInfo(TrainShift TrainShift, DestinationSeat DestinationSeat) : base()
        {
            this.DestinationSeat = DestinationSeat;
            this.TrainShift = TrainShift;


            TrainShift.SaleSeatInfos.Add(this);
        }

        //[Required]
        public virtual TrainShift TrainShift { get; private set; }


        [Required]
        public virtual DestinationSeat DestinationSeat { get; private set; }


        protected override bool EqualsCore(SaleSeatInfo other)
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
