using System;
using UnityEngine;

namespace Modules.Lib2D.Runtime
{
    public abstract class CharacterController2D : MonoBehaviour
    {
        private Transform lookingAt;
        private Vector3 movingTo;
        private bool moving;
        private Transform following;
        private float movingSpeed = 1f;
        private Action arrivalCallback;
        void FixedUpdate()
        {
            if (lookingAt)
                global::Modules.Lib2D.Runtime.Lib2D.LookAt2D(transform, lookingAt);
            if (moving)
            {
                global::Modules.Lib2D.Runtime.Lib2D.MoveTo2D(transform, movingTo, movingSpeed);
                if (Vector3.Distance(transform.position, movingTo) < 0.1f)
                    OnArrival();
            }
            else if (following)
                global::Modules.Lib2D.Runtime.Lib2D.MoveTo2D(transform, following, movingSpeed);
        }

        private void OnArrival()
        {
            arrivalCallback?.Invoke();
            moving = false;
        }
    
        #region public functions

        protected void MoveTo2D(Transform newTarget, float speed = 1, Action callback = null)
        {
            MoveTo2D(newTarget.position, speed, callback);
        }
        protected void MoveTo2D(Vector3 pos, float speed = 1, Action callback = null)
        {
            arrivalCallback = callback;
            movingSpeed = speed;
            movingTo = pos;
            moving = true;
        }

        protected void StopMovingTo2D()
        {
            moving = false;
        }
    
        protected void Follow2D(Transform newTarget, float speed = 1)
        { 
            movingSpeed = speed;
            following = newTarget;
        }
        protected void StopFollowing()
        {
            following = null;
        }
    
        protected void LookAt2D(Transform newTarget)
        {
            lookingAt = newTarget;
        }
        protected void StopLookAt2D()
        {
            lookingAt = null;
        }
    
        #endregion
    }
}
