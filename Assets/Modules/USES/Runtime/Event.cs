using System.Collections.Generic;
using USES.Payloads;
using UnityEngine;
using UnityEngine.Events;

namespace USES
{
    [CreateAssetMenu(menuName = "Scriptables/Event")]
    public class Event : ScriptableObject
    {
        public static bool DebugEvents;
        [SerializeField] private List<EventListener> listeners = new List<EventListener>();

        public EventListener Register(UnityAction<Payload> response, GameObject subscriber = null)
        {
            return Register(new PayloadUnityEvent(response), subscriber);
        }

        public EventListener Register(PayloadUnityEvent callback, GameObject subscriber = null)
        {
            var l = new EventListener(this, callback);
            if (subscriber) l.subscriber = subscriber;
            return Register(l, subscriber);
        }

        public EventListener Register(EventListener l, GameObject subscriber = null)
        {
            if (subscriber) l.subscriber = subscriber;
            listeners.Add(l);
            return l;
        }

        public void Unregister(GameObject subscriber)
        {
            Unregister(listeners.Find(listener => listener.subscriber == subscriber));
        }

        public void Unregister(EventListener l) => listeners.Remove(l);

        private void PrintDebug(Payload payload)
        {
            switch (payload)
            {
                case IntPayload intPayload:
                    Debug.Log($"RAISE {name} with {typeof(Payload)} : [{intPayload.Data}]");
                    break;
                case StringPayload stringPayload:
                    Debug.Log($"RAISE {name} with {typeof(Payload)} : [{stringPayload.Data}]");
                    break;
                default:
                    Debug.Log($"RAISE {name} with {typeof(Payload)}");
                    break;
            }
        }

        public void Raise(Payload payload)
        {
            if (DebugEvents) PrintDebug(payload);
            foreach (var listener in listeners)
                listener.OnEventRaised(this, payload);
        }

        //Helpers for standard payloads
        public void Raise() => Raise(new Payload {name = name});
        public void Raise(string s) => Raise(new StringPayload(s) {name = name});
        public void Raise(int i) => Raise(new IntPayload(i) {name = name});
        public void Raise(float f) => Raise(new FloatPayload(f) {name = name});
    }
}