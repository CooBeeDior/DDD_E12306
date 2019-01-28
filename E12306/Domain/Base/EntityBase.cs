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

        public virtual int Version { get; protected set; }
        public virtual DateTimeOffset AddTime { get; protected set; }

        public virtual Guid AddUserId { get; protected set; }

        public virtual DateTimeOffset UpdateTime { get; protected set; }

        public virtual Guid UpdateUserId { get; protected set; }

    }
}
