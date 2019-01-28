using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.DomainEvent.Impl
{
    public class WxPaymentSucessEventHandle : IEventHandle<WxPaymentSucessEventDomain>
    {
        public void Handle(WxPaymentSucessEventDomain @event)
        {
            Console.WriteLine($"{@event.CustomeInfo}微信支付陈宫通知,商品:{@event.OrderInfo}");
        }
    }
}
