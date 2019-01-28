using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E12306.DomainEvent
{
    public class EventCollection
    {
        private static Dictionary<Type, IList<Type>> eventCollection = new Dictionary<Type, IList<Type>>();

        public static IList<Type> GetSubscribes<TEvent>() where TEvent : EventDomain
        {
            return GetSubscribes(typeof(TEvent));
        }

        public static IList<Type> GetSubscribes(Type type)
        {
            var typeList = eventCollection.Where(o => o.Key == type).Select(o => o.Value).FirstOrDefault();
            return typeList;
        }

        public static void Subscribe<TEvent>(IEventHandle<TEvent> eventHandle) where TEvent : EventDomain
        {
            Subscribe(eventHandle.GetType());
        }

        public static void Subscribe(Type type)
        {
            var tInterface = type.GetInterface(typeof(IEventHandle<>).Name);
            if (tInterface == null)
            {
                throw new Exception("类型错误");
            }
            var tEventType = tInterface.GetGenericArguments().FirstOrDefault(); 
            var typeDic = eventCollection.Where(o => o.Key == tEventType).FirstOrDefault();
            if (typeDic.Key == null)
            {
                eventCollection.Add(tEventType, new List<Type>() { type });
            }
            else
            {
                if (!typeDic.Value.Contains(type))
                {
                    typeDic.Value.Add(type);
                }
                else
                {
                    throw new Exception("已经订阅过该类型");
                }
            }
        }

        public static void Subscribes<TEvent>(IEventHandle<TEvent> eventHandle) where TEvent : EventDomain
        {
            UnSubscribe(eventHandle.GetType());
        }
        public static void UnSubscribe(Type type)
        {
            var tInterface = type.GetInterface(typeof(IEventHandle<>).Name);
            if (tInterface == null)
            {
                throw new Exception("类型错误");
            }
            var tEventType = tInterface.GetGenericTypeDefinition();

            var typeDic = eventCollection.Where(o => o.Key == tEventType).FirstOrDefault();
            if (typeDic.Key == null)
            {
                throw new Exception("未订阅过该类型");
            }
            else
            {
                if (typeDic.Value.Contains(type))
                {
                    typeDic.Value.Remove(type);
                }
                else
                {
                    throw new Exception("未订阅过该类型");
                }
            }
        }
    }
}
