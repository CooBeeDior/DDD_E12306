﻿using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.DomainEvent.Impl
{
    public class WxOrderShippingEventHandle : IEventHandle<OrderShippingEventDomain>
    {
        public void Handle(OrderShippingEventDomain @event)
        {
            Console.WriteLine($"{@event.CustomeInfo}微信发货通知,商品:{@event.OrderInfo},地址:{@event.Address}");
        }
    }
}
