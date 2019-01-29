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

        public Train(string Code, IList<TrainCarriage> TrainCarriages)
        {
            Id = Guid.NewGuid();
            this.Code = Code;
            this.TrainCarriages = TrainCarriages;


            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }



        [Required]
        [MaxLength(50)]
        public string Code { get; private set; }

        public IList<TrainCarriage> TrainCarriages { get; private set; }

        public void AddTrainCarriage(TrainCarriage TrainCarriage)
        {
            if (TrainCarriages == null)
            {
                TrainCarriages = new List<TrainCarriage>();
            }

            foreach (var item in TrainCarriages.Where(o => o.Order >= TrainCarriage.Order))
            {
                item.SetOrder(item.Order + 1);
            }
            TrainCarriages.Add(TrainCarriage);
        }

        public void RemoveTrainCarriage(TrainCarriage TrainCarriage)
        {
            if (TrainCarriage == null)
            {
                throw new NullReferenceException("TrainCarriage is not null");
            }
            TrainCarriages.Remove(TrainCarriage);
            foreach (var item in TrainCarriages.Where(o => o.Order >= TrainCarriage.Order))
            {
                item.SetOrder(item.Order - 1);
            }
        }

    }
}
