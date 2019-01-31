using E12306.Common;
using E12306.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{



    /// <summary>
    /// 座位 实体
    /// </summary>
    [Table("Seat")]
    public class Seat : EntityBase
    {
        protected Seat()
        {
        }
        public Seat(TrainCarriage TrainCarriage, int Row, string Code, SeatTypeConfig SeatType) : base()
        {

            this.TrainCarriage = TrainCarriage;
            this.Row = Row;
            this.Code = Code;
            this.SeatType = SeatType;

            TrainCarriage.AddSeat(this);
        }

        [Required]
        public virtual TrainCarriage TrainCarriage { get; private set; }
        /// <summary>
        /// 座位编号
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Code { get; private set; }

        /// <summary>
        /// 第几排
        /// </summary>
        [Required]
        public int Row { get; private set; }

        [Required]
        public virtual SeatTypeConfig SeatType { get; }

    }


}
