using E12306.Common;
using E12306.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{



    /// <summary>
    /// 作为 (实体)
    /// </summary>
    [Table("Seat")]
    public class Seat : EntityBase
    {
        protected Seat()
        {
        }
        public Seat(TrainCarriage TrainCarriage,int Row, string Code, SeatTypeConfig SeatType)
        {
            base.Id = Guid.NewGuid();
            this.TrainCarriage = TrainCarriage;
            this.Row = Row;
            this.Code = Code; 
            this.SeatType = SeatType;

            Version = 0;
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;

            TrainCarriage.AddSeat(this);
        }


        public TrainCarriage TrainCarriage { get; private set; }
        /// <summary>
        /// 座位编号
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 第几排
        /// </summary>
        public int Row { get; private set; }

        public SeatTypeConfig SeatType { get; private set; }

    }


}
