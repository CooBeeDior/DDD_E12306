using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.DomainEvent.Impl
{
    public class WxPaymentSucessEventDomain : EventDomain
    {
        public string CustomeInfo { get; set; }

        public string OrderInfo { get; set; }
    }
}
