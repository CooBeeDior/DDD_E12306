using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{
    //    [Name("无座")]
    //    NoSeat,
    //    [Name("硬座")]
    //    HardSeat,
    //    [Name("软座")]
    //    SoftSeat,


    //    [Name("商务座")]
    //    BusinessSeat,
    //    [Name("一等座")]
    //    OneLevelSeat,
    //    [Name("二等座")]
    //    TwoLevelSeat,



    //    [Name("硬卧")]
    //    HardSleep,
    //    [Name("软卧")]
    //    SoftTSleep,

    [Table("SeatTypeConfig")]
    public class SeatTypeConfig : ConfigBase
    {
        private SeatTypeConfig()
        {

        }

        public SeatTypeConfig(string Code, string Name) : this(Code, Name, null)
        {

        }

        public SeatTypeConfig(string Code, string Name, IList<LocationSeatTypeConfig> LocationSeatTypes) : base(Code, Name)
        {
            this.LocationSeatTypes = LocationSeatTypes ?? new List<LocationSeatTypeConfig>();

        }

        public virtual IList<LocationSeatTypeConfig> LocationSeatTypes { get; private set; }

        public void AddLocationSeatTypeConfig(LocationSeatTypeConfig LocationSeatType)
        {
            this.LocationSeatTypes.Add(LocationSeatType);

        }

        public override bool Equals(object obj)
        {
            var other = obj as SeatTypeConfig;
            return this.LocationSeatTypes == other.LocationSeatTypes && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            var a = LocationSeatTypes.GetHashCode();
            return a ^ base.GetHashCode();
        }


        public static bool operator ==(SeatTypeConfig left, SeatTypeConfig right)
        {
            return isEqual(left, right);
        }
        public static bool operator !=(SeatTypeConfig left, SeatTypeConfig right)
        {
            return !isEqual(left, right);
        }

        private static bool isEqual(SeatTypeConfig left, SeatTypeConfig right)
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
