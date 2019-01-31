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
    public class DestinationSeat : ValueObject<DestinationSeat>
    {
        protected DestinationSeat()
        {

        }
        public DestinationSeat(Seat Seat, IList<TrainStationWay> TrainStationWays) : base()
        {
            this.Seat = Seat;
            this.TrainStationWays = TrainStationWays;
        }
        [Required]
        public virtual Seat Seat { get; private set; }

        [Required]
        public virtual IList<TrainStationWay> TrainStationWays { get; private set; }


        protected override bool EqualsCore(DestinationSeat other)
        {
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

        protected override int GetHashCodeCore()
        {
            var a = Seat.GetHashCode();
            var b = TrainStationWays.GetHashCode();
            return a ^ b;
        }
    }
}
