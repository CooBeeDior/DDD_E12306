using E12306.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace E12306.Domain
{
    /// <summary>
    ///座位的信息  
    /// </summary>
    [Table("DestinationSeat")]
    public class DestinationSeat : EntityBase
    {
        protected DestinationSeat()
        {

        }
        public DestinationSeat(Seat Seat, IList<TrainStationWay> TrainStationWays)
        {
            this.Seat = Seat;
            this.TrainStationWays = TrainStationWays;

            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }
        [Required]
        public Seat Seat { get; private set; }

        [Required]
        public IList<TrainStationWay> TrainStationWays { get; private set; }


        public override bool Equals(object obj)
        {
            var other = obj as DestinationSeat;
            if (this.Seat != other.Seat)
            {
                return false;
            }
            var otherTrainStationWays = other?.TrainStationWays?.OrderBy(o => o.StartTrainStation.Order).ToList();
            var thisTrainStationWays = TrainStationWays.OrderBy(o => o.StartTrainStation.Order).ToList();

            for (int i = 0; i < otherTrainStationWays.Count(); i++)
            {
                if (otherTrainStationWays[i] != thisTrainStationWays[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            var a = Seat.GetHashCode();
            var b = TrainStationWays.GetHashCode();
            return a ^ b;
        }


        public static bool operator ==(DestinationSeat left, DestinationSeat right)
        {
            return isEqual(left, right);
        }
        public static bool operator !=(DestinationSeat left, DestinationSeat right)
        {
            return !isEqual(left, right);
        }

        private static bool isEqual(DestinationSeat left, DestinationSeat right)
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
