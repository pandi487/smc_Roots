using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.LifeManager.Runtime
{
    public class LifeManager
    {
        private float life = 0;
        private UnityEvent OnDeath = new UnityEvent();
        private MonoBehaviour caller;
        private List<Status> statuses = new List<Status>();
        public LifeManager(float life = 10f)
        {
            this.life = life;
        }

        public float GetLife()
        {
            return life;
        }

        private void Modify(float amount)
        {
            life += amount;
            if (life < 0)
                life = 0;
            IsDead();
        }

        public void LooseLife(float lifeLost) { Modify(-lifeLost); }
        public void GainLife(float lifeGained) { Modify(lifeGained); }
        private void AddStatus(Status status, MonoBehaviour self)
        {
            caller = self;
            statuses.Add(status);
            status.coroutine = self.StartCoroutine(ApplyStatus(status));
        }
        public void LooseOverTime(float lifeLost, float duration, MonoBehaviour self)
        {
            AddStatus(new Status(-lifeLost, duration), self);
        }
        public void GainOverTime(float lifeGained, float duration, MonoBehaviour self)
        {
            AddStatus(new Status(lifeGained, duration), self);
        }
        public void LooseAtInterval(float lifeLost, float interval, float amount, MonoBehaviour self)
        {
            AddStatus(Status.CreateIntervalAmountStatus(-lifeLost, interval, amount), self);
        }
        public void GainAtInterval(float lifeGained, float interval, float amount, MonoBehaviour self)
        {
            AddStatus(Status.CreateIntervalAmountStatus(lifeGained, interval, amount), self);
        }
        public void LooseOvertimeInterval(float lifeLost, float interval, float duration, MonoBehaviour self)
        {
            AddStatus(Status.CreateIntervalDurationStatus(-lifeLost, interval, duration), self);
        }
        public void GainOvertimeInterval(float lifeGained, float interval, float duration, MonoBehaviour self)
        {
            AddStatus(Status.CreateIntervalDurationStatus(-lifeGained, interval, duration), self);
        }
    
        IEnumerator ApplyStatus(Status status)
        {
            var time = status._duration;
            while (status._infinite || time > 0f)
            {
                time -= status._interval;
                Modify(status._amount);
                yield return new WaitForSeconds(status._interval);
            }
        }
    
        public void DoOnDeath(UnityAction action)
        {
            OnDeath.AddListener(action);
        }
    
        public bool IsDead()
        {
            if (life > 0)
                return false;
            if (caller)
                foreach (var status in statuses)
                { 
                    caller.StopCoroutine(status.coroutine);
                }
            OnDeath.Invoke();
            return false;
        }

    }
}
