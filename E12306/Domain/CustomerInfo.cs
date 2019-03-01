using E12306.Common;
using E12306.Common.Enum;
using E12306.DomainEvent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace E12306.Domain
{
    /// <summary>
    /// 用户 聚合根
    /// </summary>
    [Table("CustomerInfo")]
    public class CustomerInfo : AggregateRoot
    {
        private CustomerInfo()
        {

        }
        public CustomerInfo(string Name, string PhoneNumber) : this(Name, PhoneNumber, null)
        {

        }

        public CustomerInfo(string Name, string PhoneNumber, string Email) : this(Name, PhoneNumber, Email, null)
        {

        }

        public CustomerInfo(string Name, string PhoneNumber, string Email, string IdCard, IList<Address> Addresses = null, IList<UserContract> UserContracts = null) : base()
        {
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.IdCard = IdCard ?? "";
            this.TrainOrders = new List<TrainOrder>(); ;
            this.UserContracts = UserContracts ?? new List<UserContract>();
            this.Addresses = Addresses ?? new List<Address>();
        }



        [MaxLength(50)]
        [Required]
        public string Name { get; private set; }

        [EmailAddress]
        [MaxLength(50)]
        [Required]     
        public string Email { get; set; }

        [Phone]
        [MaxLength(50)]
        [Required]
        public string PhoneNumber { get; private set; }


        [CreditCard]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = true)]
        public string IdCard { get; private set; }


        public virtual IList<Address> Addresses { get; private set; }

        public virtual IList<TrainOrder> TrainOrders { get; private set; }

        public virtual IList<UserContract> UserContracts { get; private set; }

        public void AddAddress(Address Address)
        {
            this.Addresses.Add(Address);
        }
        public void RemoveAddress(Address Address)
        {
            this.Addresses.Remove(Address);
        }
        public void AddUserContract(UserContract UserContract)
        {
            UserContracts.Add(UserContract);
        }

        public void RemoveUserContracts(UserContract UserContract)
        {
            UserContracts.Remove(UserContract);
        }

        public (bool, string, TrainOrder) BookTrainTicket(TrainShift TrainShift, TrainStation StartTrainStation, TrainStation EndTrainStation, SeatTypeConfig SeatType, CustomerInfo CustomerInfo, UserContract UserContract)
        {
            return BookTrainTicket(TrainShift, StartTrainStation, EndTrainStation, new List<SeatTypeConfig> { SeatType }, CustomerInfo, UserContract);
        }
        public (bool, string, TrainOrder) BookTrainTicket(TrainShift TrainShift, TrainStation StartTrainStation, TrainStation EndTrainStation, IList<SeatTypeConfig> SeatTypes, CustomerInfo CustomerInfo, UserContract UserContract)
        {
            return BookTrainTicket(TrainShift, StartTrainStation, EndTrainStation, SeatTypes, CustomerInfo, new List<UserContract>() { UserContract });
        }
        public (bool, string, TrainOrder) BookTrainTicket(TrainShift TrainShift, TrainStation StartTrainStation, TrainStation EndTrainStation, SeatTypeConfig SeatType, CustomerInfo CustomerInfo, IList<UserContract> UserContracts)
        {
            return BookTrainTicket(TrainShift, StartTrainStation, EndTrainStation, new List<SeatTypeConfig> { SeatType }, CustomerInfo, UserContracts);
        }

        public (bool, string, TrainOrder) BookTrainTicket(TrainShift TrainShift, TrainStation StartTrainStation, TrainStation EndTrainStation, IList<SeatTypeConfig> SeatTypes, CustomerInfo CustomerInfo, IList<UserContract> UserContracts)
        {
            if (StartTrainStation == null)
            {
                throw new ArgumentNullException("StartTrainStation");
            }
            if (!StartTrainStation.IsSale)
            {
                throw new ArgumentNullException($"{StartTrainStation} is Not Sale");
            }
            if (EndTrainStation == null)
            {
                throw new ArgumentNullException("EndTrainStation");
            }
            if (SeatTypes == null)
            {
                throw new ArgumentNullException("SeatTypes");
            }
            if (UserContracts == null || UserContracts.Count == 0)
            {
                throw new ArgumentNullException("UserContract");
            }
            if (UserContracts.Count(o => o.UserType != ContractUserType.Children) == 0)
            {
                throw new Exception("儿童不能单独买票");
            }
            if (StartTrainStation.Order > EndTrainStation.Order)
            {
                throw new ArgumentNullException("StartTrainStation same EndTrainStation Order");
            }
            if (StartTrainStation.Order > EndTrainStation.Order)
            {
                var temp = StartTrainStation;
                StartTrainStation = EndTrainStation;
                EndTrainStation = temp;
            }

            var trainStationWay = new TrainStationWay(StartTrainStation, EndTrainStation);

            IList<Seat> seats = isMatchSeats(TrainShift, StartTrainStation, EndTrainStation, SeatTypes);
            //匹配优先在同一车厢
            if (seats == null || seats.Count == 0)
            {
                seats = TrainShift.ExtraSeatInfos.Select(o => o.Seat).Where(o => SeatTypes.Contains(o.SeatType)).GroupBy(o => o.TrainCarriage).Where(o => o.Count() >= UserContracts.Count).FirstOrDefault().Take(UserContracts.Count).ToList();

                if (seats == null)
                {
                    seats = TrainShift.ExtraSeatInfos.Select(o => o.Seat).Where(o => SeatTypes.Contains(o.SeatType)).Take(UserContracts.Count).ToList();
                    if (seats == null || seats.Count < UserContracts.Count)
                    {
                        throw new Exception("余票不足，建议单独购买");
                    }
                }

            }
            else if (seats.Count < UserContracts.Count)
            {
                foreach (var item in seats)
                {
                    seats = seats.Union(TrainShift.ExtraSeatInfos.Select(o => o.Seat).Where(o => SeatTypes.Contains(o.SeatType) && o.TrainCarriage == item.TrainCarriage).Take(UserContracts.Count - seats.Count).ToList()).ToList();
                    if (seats.Count == UserContracts.Count)
                    {
                        break;
                    }
                }

                if (seats.Count < UserContracts.Count)
                {
                    seats = seats.Union(TrainShift.ExtraSeatInfos.Select(o => o.Seat).Where(o => SeatTypes.Contains(o.SeatType)).Take(UserContracts.Count - seats.Count).ToList()).ToList();
                    if (seats.Count < UserContracts.Count)
                    {
                        throw new Exception("余票不足，建议单独购买");
                    }
                }
            }
            else
            {
                seats = seats.GroupBy(o => o.TrainCarriage).Where(o => o.Count() >= UserContracts.Count).FirstOrDefault().Take(UserContracts.Count).ToList();
                if (seats == null || seats.Count == 0)
                {
                    seats = seats.Take(UserContracts.Count).ToList();
                }

            }
            if (seats == null || UserContracts.Count > seats.Count)
            {
                throw new Exception("余票不足");
            }

            IList<TrainOrderItem> trainOrderItems = new List<TrainOrderItem>();
            for (int i = 0; i < seats.Count; i++)
            {

                var seat = seats[i];
                var userContract = UserContracts[i];
                var b = TrainShift.ExtraSeatInfos.Remove(new ExtraSeatInfo(TrainShift, seat));


                new FreezeSeatInfo(TrainShift, new DestinationSeat(seat, new List<TrainStationWay>() { trainStationWay }));
                new FreezeSeatInfo(TrainShift, new DestinationSeat(seat, new List<TrainStationWay>() { trainStationWay }));

                var price = TrainShift.TrainNumber.GetTrainStationWayPrice(trainStationWay, seat.SeatType);
                TrainOrderItem trainOrderItem = new TrainOrderItem(seat, userContract, price);
                trainOrderItems.Add(trainOrderItem);
            }


            TrainOrder trainOrder = new TrainOrder(trainStationWay.StartTrainStation, trainStationWay.EndTrainStation, CustomerInfo, trainOrderItems);
            return (true, "预定成功", trainOrder);
        }



        /// <summary>
        /// 判断是否有重叠区域
        /// </summary>
        /// <param name="StartTrainStation"></param>
        /// <param name="EndTrainStation"></param>
        /// <param name="SeatTypes"></param>
        /// <returns></returns>
        private IList<Seat> isMatchSeats(TrainShift TrainShift, TrainStation StartTrainStation, TrainStation EndTrainStation, IList<SeatTypeConfig> SeatTypes)
        {
            IList<Seat> list = new List<Seat>();

            foreach (var item in TrainShift.SaleSeatInfos.Select(o => o.DestinationSeat))
            {
                int count = item.TrainStationWays.Count(o => (StartTrainStation < o.EndTrainStation && EndTrainStation > o.EndTrainStation)
                  || (EndTrainStation > o.StartTrainStation && EndTrainStation < o.EndTrainStation)
                  || (StartTrainStation >= o.StartTrainStation && EndTrainStation <= o.EndTrainStation)
                  || (StartTrainStation <= o.StartTrainStation && EndTrainStation >= o.EndTrainStation)
                  );
                if (count == 0 && SeatTypes.Contains(item.Seat.SeatType))
                {
                    list.Add(item.Seat);
                }
            }
            return list;

        }

        private Seat isMatchSeat(TrainShift TrainShift, TrainStation StartTrainStation, TrainStation EndTrainStation, IList<SeatTypeConfig> SeatTypes)
        {
            foreach (var item in TrainShift.SaleSeatInfos.Select(o => o.DestinationSeat))
            {
                int count = item.TrainStationWays.Count(o => (StartTrainStation < o.EndTrainStation && EndTrainStation > o.EndTrainStation)
                  || (EndTrainStation > o.StartTrainStation && EndTrainStation < o.EndTrainStation)
                  || (StartTrainStation >= o.StartTrainStation && EndTrainStation <= o.EndTrainStation)
                  || (StartTrainStation <= o.StartTrainStation && EndTrainStation >= o.EndTrainStation)
                  );
                if (count == 0 && SeatTypes.Contains(item.Seat.SeatType))
                {
                    return item.Seat;
                }
            }
            return null;

        }

    }
}
