using E12306.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.Domain
{

    /// <summary>
    /// 路线 值对象
    /// </summary>
    public class TrainStationWay : EntityBase
    {
        protected TrainStationWay()
        {
        }

        public TrainStationWay(TrainStation StartTrainStation, TrainStation EndTrainStation)
        {
            this.StartTrainStation = StartTrainStation;
            this.EndTrainStation = EndTrainStation;

            Version = 0;
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }
        public TrainStation StartTrainStation { get; private set; }

        public TrainStation EndTrainStation { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as TrainStationWay;
            return this.StartTrainStation == other.StartTrainStation && this.EndTrainStation == other.EndTrainStation;
        }

        public override int GetHashCode()
        {
            var a = StartTrainStation.GetHashCode();
            var b = EndTrainStation.GetHashCode();
            return a ^ b;
        }


        public static bool operator ==(TrainStationWay left, TrainStationWay right)
        {
            return isEqual(left, right);
        }
        public static bool operator !=(TrainStationWay left, TrainStationWay right)
        {
            return !isEqual(left, right);
        }

        private static bool isEqual(TrainStationWay left, TrainStationWay right)
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
            return $"起点站：{StartTrainStation}；终点站:{EndTrainStation}";
        }

    }
}
