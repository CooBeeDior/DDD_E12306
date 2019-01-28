using E12306.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{
    /// <summary>
    /// 冻结座位信息 类对象
    /// </summary>   
    [Table("FreezeSeatInfo")]
    public class FreezeSeatInfo : EntityBase
    {
        protected FreezeSeatInfo()
        {

        }
        public FreezeSeatInfo(TrainShift TrainShift ,DestinationSeat DestinationSeat)
        {
            this.DestinationSeat = DestinationSeat;
            this.TrainShift = TrainShift;

            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;

            TrainShift.FreezeSeatInfos.Add(this);
        }
        
        public TrainShift TrainShift { get; private set; }

      
        public DestinationSeat DestinationSeat { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as FreezeSeatInfo;
            return this.TrainShift == other.TrainShift && this.DestinationSeat == other.DestinationSeat;
        }

        public override int GetHashCode()
        {
            var a = TrainShift.GetHashCode();
            var b = DestinationSeat.GetHashCode();
            return a ^ b;
        }


        public static bool operator ==(FreezeSeatInfo left, FreezeSeatInfo right)
        {
            return isEqual(left, right);
        }
        public static bool operator !=(FreezeSeatInfo left, FreezeSeatInfo right)
        {
            return !isEqual(left, right);
        }

        private static bool isEqual(FreezeSeatInfo left, FreezeSeatInfo right)
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
