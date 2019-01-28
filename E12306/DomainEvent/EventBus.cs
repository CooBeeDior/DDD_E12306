using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.DomainEvent
{
    public class EventBus
    {

        public static void Publish<TEvent>(TEvent @event) where TEvent : EventDomain
        {
            var subscribeTypes = EventCollection.GetSubscribes<TEvent>();
            if (subscribeTypes != null)
            {
                foreach (var item in subscribeTypes)
                {
                    var instance = Activator.CreateInstance(item);
                    var eventHandle = instance as IEventHandle<TEvent>;
                    eventHandle?.Handle(@event);
                }
            }

        }
    }
}
