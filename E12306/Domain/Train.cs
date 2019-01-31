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
    /// 火车 实体
    /// </summary>
    [Table("Train")]   
    public class Train : EntityBase
    {

        public Train(string Code) : this(Code, null)
        {
        }

        public Train(string Code, IList<TrainCarriage> TrainCarriages) : this(Code, null, TrainCarriages)
        {           

        }

        public Train(string Code, TrainNumber TrainNumber, IList<TrainCarriage> TrainCarriages) : base()
        {
            this.Code = Code;
            this.TrainNumber = TrainNumber;
            this.TrainCarriages = TrainCarriages ?? new List<TrainCarriage>();

            TrainNumber?.Trains?.Add(this);

        }

        [Required]
        [ForeignKey("TrainNumberId")]
        public virtual TrainNumber TrainNumber { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; private set; }

        public virtual IList<TrainCarriage> TrainCarriages { get; private set; }

        public void AddTrainCarriage(TrainCarriage TrainCarriage)
        {
            foreach (var item in TrainCarriages.Where(o => o.Order >= TrainCarriage.Order))
            {
                item.SetOrder(item.Order + 1);
            }
            TrainCarriages.Add(TrainCarriage);
        }

        public void RemoveTrainCarriage(TrainCarriage TrainCarriage)
        {
            TrainCarriages.Remove(TrainCarriage);
            foreach (var item in TrainCarriages.Where(o => o.Order >= TrainCarriage.Order))
            {
                item.SetOrder(item.Order - 1);
            }
        }

    }
}
