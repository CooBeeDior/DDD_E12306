using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.DomainEvent
{
    public interface IEventHandle<TEvent> where TEvent:EventDomain
    {
        void Handle(TEvent @event);     
      
    }
}
