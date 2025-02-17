using System.Collections.Generic;
using Singleton;
using UnityEngine.Events;

namespace Utility
{
    public class EventCenter : Singleton<EventCenter>
    {
        private readonly Dictionary<EventType, List<AbstractEventInfo>> _eventDict = new();

        public void RegisterObserver(EventType eventType, UnityAction action)
        {
            if (!_eventDict.TryGetValue(eventType, out var value))
            {
                _eventDict.Add(eventType, new List<AbstractEventInfo> { new EventInfo(action) });
            }
            else
            {
                value.Add(new EventInfo(action));
            }
        }

        public void RegisterObserver<T>(EventType eventType, UnityAction<T> action)
        {
            if (!_eventDict.TryGetValue(eventType, out var value))
            {
                _eventDict.Add(eventType, new List<AbstractEventInfo> { new EventInfo<T>(action) });
            }
            else
            {
                value.Add(new EventInfo<T>(action));
            }
        }

        public void NotifyObserver(EventType eventType)
        {
            if (_eventDict.TryGetValue(eventType, out var value))
            {
                foreach (var eventInfo in value)
                {
                    if (eventInfo is EventInfo info)
                    {
                        info.Invoke();
                    }
                }
            }
        }

        public void NotifyObserver<T>(EventType eventType, T param)
        {
            if (_eventDict.TryGetValue(eventType, out var value))
            {
                foreach (var eventInfo in value)
                {
                    if (eventInfo is EventInfo<T> info)
                    {
                        info.Invoke(param);
                    }
                }
            }
        }

        public void ClearObservers()
        {
            foreach (var kv in _eventDict)
            {
                ClearObserver(kv.Key);
            }
        }

        public void ClearObserver(EventType eventType)
        {
            if (_eventDict.TryGetValue(eventType, out var value))
            {
                for (var i = value.Count - 1; i >= 0; i--)
                {
                    var eventInfo = value[i];
                    if (!eventInfo.IsPermanent)
                    {
                        value.Remove(eventInfo);
                    }
                }
            }
        }

        public void UnRegisterObserver(EventType eventType, UnityAction action)
        {
            if (_eventDict.TryGetValue(eventType, out var value))
            {
                value.RemoveAll(x => x is EventInfo info && info.Action == action);
            }
        }

        public void UnRegisterObserver<T>(EventType eventType, UnityAction<T> action)
        {
            if (_eventDict.TryGetValue(eventType, out var value))
            {
                value.RemoveAll(x => x is EventInfo<T> info && info.Action == action);
            }
        }
    }

    public enum EventType
    {
        SceneLoadComplete,
        SelectPlayerBegin,
        SelectPlayerFinish,
        SelectPlayerCancel,
    }

    public abstract class AbstractEventInfo
    {
        public bool IsPermanent;
    }

    public class EventInfo : AbstractEventInfo
    {
        public UnityAction Action { get; }

        public EventInfo(UnityAction action, bool isPermanent = false)
        {
            Action = action;
            IsPermanent = isPermanent;
        }

        public void Invoke()
        {
            Action?.Invoke();
        }
    }

    public class EventInfo<T> : AbstractEventInfo
    {
        public UnityAction<T> Action { get; }

        public EventInfo(UnityAction<T> action, bool isPermanent = false)
        {
            Action = action;
            IsPermanent = isPermanent;
        }

        public void Invoke(T param)
        {
            Action?.Invoke(param);
        }
    }
}