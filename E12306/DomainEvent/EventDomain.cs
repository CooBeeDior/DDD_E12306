using E12306.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.DomainEvent
{
    public class EventDomain
    {
        public AggregateRoot Root { get; set; }
        public DateTime PublishTime { get; set; }
    }
}
