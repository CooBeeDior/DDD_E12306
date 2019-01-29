using E12306.Common;
using E12306.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace E12306.Domain
{
    /// <summary>
    /// 车次  实体
    /// </summary>
    [Table("TrainNumber")]
    public class TrainNumber : EntityBase
    {
        protected TrainNumber()
        {

        }
        public TrainNumber(string Code, string Name, TrainTypeConfig TrainType) : this(Code, Name, TrainType, null, null, null)
        {

        }

        public TrainNumber(string Code, string Name, TrainTypeConfig TrainType, IList<Train> Trains) : this(Code, Name, TrainType, null, null, Trains)
        {

        }
        public TrainNumber(string Code, string Name, TrainTypeConfig TrainType, IList<TrainStation> TrainStations, IList<TrainTicketPrice> TrainTicketPrices, IList<Train> Trains)
        {
            this.Id = Guid.NewGuid();
            this.Code = Code;
            this.Name = Name;
            this.TrainType = TrainType;
            this.TrainStations = TrainStations;
            this.TrainTicketPrices = TrainTicketPrices;
            this.Trains = Trains;
           
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }
        [Required]
        [MaxLength(50)]
        public string Name { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; protected set; }

        /// <summary>
        /// 车次类型 
        /// </summary> 
        public TrainTypeConfig TrainType { get; protected set; }

        /// <summary>
        /// 车票价格
        /// </summary>
        public IList<TrainTicketPrice> TrainTicketPrices { get; private set; }

        /// <summary>
        /// 站
        /// </summary>
        public IList<TrainStation> TrainStations { get; private set; }



        /// <summary>
        /// 火车
        /// </summary>
        public IList<Train> Trains { get; private set; }


        public void AddTrain(Train Train)
        {
            if (Trains == null)
            {
                Trains = new List<Train>();
            }
            if (Trains.Where(o => o.Id == Train.Id).Count() > 0)
            {
                throw new Exception("exsit same train");
            }
            Trains.Add(Train);
        }
        public void RemoveTrain(Train Train)
        {
            if (Trains == null)
            {
                Trains = new List<Train>();
            }
            if (Trains.Where(o => o.Id == Train.Id).Count() == 0)
            {
                throw new Exception("not exsit train");
            }
            Trains.Remove(Train);
        }

        public void AddTrainTicketPrice(TrainTicketPrice TrainTicketPrice)
        {
            if (TrainTicketPrices == null)
            {
                TrainTicketPrices = new List<TrainTicketPrice>();
            }
            if (TrainTicketPrices.Where(o => o.StartTrainStation == TrainTicketPrice.StartTrainStation && o.EndTrainStation == TrainTicketPrice.EndTrainStation).Count() > 0)
            {
                throw new Exception("exsit same TrainTicketPrice");
            }
            TrainTicketPrices.Add(TrainTicketPrice);
        }

        public void RemoveTrainTicketPrice(TrainTicketPrice TrainTicketPrice)
        {
            if (TrainTicketPrices == null)
            {
                TrainTicketPrices = new List<TrainTicketPrice>();
            }
            if (TrainTicketPrices.Where(o => o.StartTrainStation == TrainTicketPrice.StartTrainStation && o.EndTrainStation == TrainTicketPrice.EndTrainStation).Count() == 0)
            {
                throw new Exception("not exsit  TrainTicketPrice");
            }
            TrainTicketPrices.Remove(TrainTicketPrice);
        }



        public void AddTrainStation(TrainStation TrainStation)
        {
            if (TrainStations == null)
            {
                TrainStations = new List<TrainStation>();
            }
            TrainStations.Add(TrainStation);
            foreach (var item in TrainStations.Where(o => o.Order >= TrainStation.Order))
            {
                item.SetOrder(item.Order + 1);
            }
        }

        public void RemoveTrainStation(TrainStation TrainStation)
        {
            if (TrainStation == null)
            {
                throw new NullReferenceException("TrainCarriage is not null");
            }
            TrainStations.Remove(TrainStation);
            foreach (var item in TrainStations.Where(o => o.Order >= TrainStation.Order))
            {
                item.SetOrder(item.Order - 1);
            }
        }

        public decimal GetTrainStationWayPrice(TrainStationWay TrainStationWay, SeatTypeConfig SeatType, ContractUserType TicketUserType = ContractUserType.Adult)
        {
            if (TrainStationWay == null)
            {
                throw new ArgumentNullException("TrainStationWay");
            }
            decimal price = 0;
            decimal decutPrice = 0;


            var list = TrainTicketPrices.Where(o => o.StartTrainStation >= TrainStationWay.StartTrainStation && o.EndTrainStation <= TrainStationWay.EndTrainStation);

         
            foreach (var item in list)
            {
                var trainSeatPrices = item.TrainSeatPrices.Where(o => o.SeatType == SeatType).FirstOrDefault();
                if (trainSeatPrices == null)
                {
                    throw new Exception($"车次{Code} {item}未配置{SeatType.Name}座位类型");
                }
                price += trainSeatPrices.Price;

                if (TicketUserType == ContractUserType.Children)
                {
                    decutPrice += trainSeatPrices.Price / 2;
                }

                if (TicketUserType == ContractUserType.Student)
                {
                    var defaultTrainSeatPrice = item.TrainSeatPrices.Where(o => o.IsDefault).FirstOrDefault();
                    if (defaultTrainSeatPrice == null)
                    {
                        throw new Exception($"车次{Code} {item}");
                    }
                    decutPrice += defaultTrainSeatPrice.Price;
                }
            }

            price -= decutPrice;

            //待处理学生价格
            return price;

        }


    }

}
