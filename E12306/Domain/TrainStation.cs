using E12306.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.Domain
{

    /// <summary>
    /// 车次站台 (实体)
    /// </summary>
    public class TrainStation : EntityBase
    {
        protected TrainStation()
        {

        }

        public TrainStation(Station Station, int Order) : this(Station, Order, true)
        {

        }


        public TrainStation(Station Station, int Order, bool IsSale)
        {
            Id = Guid.NewGuid();
            this.Station = Station;
            this.Order = Order;
            this.IsSale = IsSale;

            Version = 0;
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;

        }

        public Station Station { get; private set; }

        /// <summary>
        /// 车次的第几站
        /// </summary>
        public int Order { get; private set; }

        public DateTimeOffset StartTime { get; private set; }

        public DateTimeOffset EndTime { get; private set; }


        /// <summary>
        /// 是否出售 ，（该站会停站，但是不出售车票）
        /// </summary>
        public bool IsSale { get; set; }

        public void SetOrder(int Order)
        {
            this.Order = Order;
        }
        public override bool Equals(object obj)
        {
            var other = obj as TrainStation;
            return this.Station == other.Station && this.Order == other.Order;
        }

        public override int GetHashCode()
        {
            var a = Station.GetHashCode();
            var b = Order.GetHashCode();
            return a ^ b;
        }


        public static bool operator ==(TrainStation left, TrainStation right)
        {
            return isEqual(left, right);
        }
        public static bool operator !=(TrainStation left, TrainStation right)
        {
            return !isEqual(left, right);
        }


        public static bool operator <(TrainStation left, TrainStation right)
        {
            return left.Order < right.Order;
        }

        public static bool operator >=(TrainStation left, TrainStation right)
        {
            return left.Order >= right.Order;
        }

        public static bool operator <=(TrainStation left, TrainStation right)
        {
            return left.Order <= right.Order;
        }

        public static bool operator >(TrainStation left, TrainStation right)
        {
            return left.Order > right.Order;
        }

        private static bool isEqual(TrainStation left, TrainStation right)
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

        public override string ToString()
        {
            return $"第{Order}站：{Station}";
        }

    }
}
