using System;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Modules.LifeManager.Runtime
{
    [Serializable]
    public class Status
    {
        private const float DefaultInterval = 0.2f;
        [SerializeField] public float _duration;
        [SerializeField] public float _interval;
        [SerializeField] public float _amount;

        [SerializeField]public bool _infinite;
        //private MonoBehaviour caller;
        public Coroutine coroutine;
    
        //duration, amount, interval
        
        public Status()
        {
            
        }
        public Status(float totalAmount, float duration)
        {
            this._duration = duration;
            _interval = DefaultInterval;
        
            _amount = totalAmount / (duration / _interval);
        }

        public static Status CreateIntervalAmountStatus(float totalAmount, float interval, float amount)
        {
            if ((totalAmount > 0 && amount < 0) || (totalAmount < 0 && amount > 0) 
                                                || (Mathf.Abs(totalAmount) < Mathf.Abs(amount))
                                                || (totalAmount % amount != 0))
                Debug.LogWarning("Total amount and amount incompatible");
            if (interval < 0)
                interval = DefaultInterval;
            return new Status{_interval = interval, _duration = (totalAmount / amount) * interval,_amount = amount};
        }
        
        public static Status CreateIntervalDurationStatus(float totalAmount, float interval, float duration)
        {
            if ((duration < 0) || (interval < 0)
                               || (interval > duration)
                               || duration % interval != 0)
                Debug.LogWarning("Duration and interval incompatible");
            return new Status{_interval = interval, _duration = duration ,_amount = totalAmount / (duration / interval)};
        }
    }
}
