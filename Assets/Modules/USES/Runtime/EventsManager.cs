using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using USES.EditorUtils;

namespace USES
{
    [Serializable]
    public class EventsManager
    {
        [ReadOnly] public List<Event> events;

        public void AddEvent(Event @event)
        {
            if (events.Contains(@event))
            {
                //Debug.Log($"Event [{@event}] wasn't added because it already exists");
                return;
            }

            events.Add(@event);
            Debug.Log($"Event [{@event}] was added to list");
        }

        public EventListener RegisterEvent(GameObject subscriber, string name, UnityAction<Payload> callback)
        {
            var evt = GetEvent(name);
            return evt == null
                ? null
                : evt.Register(new EventListener(evt, new PayloadUnityEvent(callback)), subscriber);
        }

        public Event GetEvent(string name)
        {
            foreach (var @event in events)
                if (@event.name == name)
                    return @event;

            Debug.LogWarning($"Couldn't find event [{name}]");
            return null;
        }

        public void Raise(string name, Payload p) => GetEvent(name).Raise(p);

        //Shortcuts for easy use
        public void Raise(string name) => GetEvent(name).Raise();
        public void Raise(string name, string s) => GetEvent(name).Raise(s);
        public void Raise(string name, int i) => GetEvent(name).Raise(i);
        public void Raise(string name, float f) => GetEvent(name).Raise(f);
    }
}