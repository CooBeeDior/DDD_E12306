using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.DomainEvent.Impl
{
    public class OrderShippingEventDomain : EventDomain
    {

        public string CustomeInfo { get; set; }

        public string OrderInfo { get; set; }
        public string Address { get; set; }
    }
}
