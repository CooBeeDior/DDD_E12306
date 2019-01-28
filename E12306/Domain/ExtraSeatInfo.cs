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
    public class ExtraSeatInfo : EntityBase
    {
        protected ExtraSeatInfo()
        {

        }
        public ExtraSeatInfo(TrainShift TrainShift, Seat Seat)
        {
            this.Seat = Seat;
            this.TrainShift = TrainShift;
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;

        }


    
        public TrainShift TrainShift { get; private set; }

 
        public Seat Seat { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as ExtraSeatInfo;
            return this.TrainShift == other.TrainShift && this.Seat == other.Seat;
        }

        public override int GetHashCode()
        {
            var a = TrainShift.GetHashCode();
            var b = Seat.GetHashCode();
            return a ^ b;
        }


        public static bool operator ==(ExtraSeatInfo left, ExtraSeatInfo right)
        {
            return isEqual(left, right);
        }
        public static bool operator !=(ExtraSeatInfo left, ExtraSeatInfo right)
        {
            return !isEqual(left, right);
        }

        private static bool isEqual(ExtraSeatInfo left, ExtraSeatInfo right)
        {
            var a = ReferenceEquals(left, null);
            var b = ReferenceEquals(right, null);
            if (a ^ b)
            {
                return false;
            }
            var c = ReferenceEquals(left, null);
            var d = left.Equals(right);
            return c || d;
        }
    }
}
