using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using USES.EditorUtils;

namespace USES
{
    [Serializable]
    public class PayloadUnityEvent : UnityEvent<Payload>
    {
        public PayloadUnityEvent()
        {
        }

        public PayloadUnityEvent(UnityAction<Payload> call)
        {
            AddListener(call);
        }
    }

    [Serializable]
    public class EventListener
    {
        [ReadOnly] public GameObject subscriber;
        public Event @event;
        public PayloadUnityEvent response;

        public EventListener(Event @event, PayloadUnityEvent response)
        {
            this.@event = @event;
            this.response = response;
        }

        public void UnregisterSelf() => @event.Unregister(this);
        public void OnEventRaised(Event evt, Payload payload) => response.Invoke(payload);
    }

    public class UsesEventListener : MonoBehaviour
    {
        public List<EventListener> eventsToListen = new List<EventListener>();
        private void OnEnable() => eventsToListen.ForEach(c => c.@event.Register(c, gameObject));
        private void OnDisable() => eventsToListen.ForEach(c => c.@event.Unregister(c));
    }
}