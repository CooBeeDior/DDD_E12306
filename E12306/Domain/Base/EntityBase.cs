using E12306.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();

            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }
        [Key]
        [Column(Order = 1)]
        public virtual Guid Id { get; private set; }


        [Required]
        [Timestamp]
        [Column(Order = 999)]
        public virtual byte[] Version { get; private set; }
        [Column(Order = 999)]
        public virtual DateTimeOffset AddTime { get; private set; }
        [Column(Order = 999)]
        public virtual Guid AddUserId { get; private set; }
        [Column(Order = 999)]
        public virtual DateTimeOffset UpdateTime { get; private set; }
        [Column(Order = 999)]
        public virtual Guid UpdateUserId { get; private set; }


        public override bool Equals(object obj)
        {
            var other = obj as EntityBase;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();

        }


        public static bool operator ==(EntityBase left, EntityBase right)
        {
            return left?.Id == right?.Id;
        }
        public static bool operator !=(EntityBase left, EntityBase right)
        {
            return left?.Id != right?.Id;
        }

    }
}
