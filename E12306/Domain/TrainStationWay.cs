using E12306.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{

    /// <summary>
    /// 值对象
    /// </summary>
    [Table("TrainStationWay")]
    public class TrainStationWay : ValueObject<TrainStationWay>
    {
        protected TrainStationWay()
        {
        }

        public TrainStationWay(TrainStation StartTrainStation, TrainStation EndTrainStation) : base()
        {
            this.StartTrainStation = StartTrainStation;
            this.EndTrainStation = EndTrainStation;

        }
        //[Required]
        public virtual TrainStation StartTrainStation { get; private set; }
        //[Required]
        public virtual TrainStation EndTrainStation { get; private set; }



        public override string ToString()
        {
            return $"起点站：{StartTrainStation}；终点站:{EndTrainStation}";
        }

        protected override bool EqualsCore(TrainStationWay other)
        {
            return this.StartTrainStation == other.StartTrainStation && this.EndTrainStation == other.EndTrainStation;
        }

        protected override int GetHashCodeCore()
        {
            var a = StartTrainStation.GetHashCode();
            var b = EndTrainStation.GetHashCode();
            return a ^ b;
        }
    }
}
