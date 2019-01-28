using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E12306.Domain
{
    public class EntityBase
    {
        [Key]
        public virtual Guid Id { get; protected set; }

        [Timestamp]
        public virtual byte[] Version { get; protected set; }

        public virtual DateTimeOffset AddTime { get; protected set; }

        public virtual Guid AddUserId { get; protected set; }

        public virtual DateTimeOffset UpdateTime { get; protected set; }

        public virtual Guid UpdateUserId { get; protected set; }


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
