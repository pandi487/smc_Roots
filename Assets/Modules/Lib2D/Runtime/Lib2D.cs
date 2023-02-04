using UnityEngine;

namespace Modules.Lib2D.Runtime
{
    public static class Lib2D
    {
        public static void LookAt2D(Transform source, Transform target, int offSet = 90)
        {
            Vector3 diff = target.position - source.position;
            diff.Normalize();
 
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            source.rotation = Quaternion.Euler(0f, 0f, rot_z - 90 + offSet);
        }

        public static void MoveTo2D(Transform source, Transform target, float speed = 1)
        {
            MoveTo2D(source, target.position, speed);
        }
        public static void MoveTo2D(Transform source, Vector3 target, float speed = 1)
        {
            float step = speed * Time.deltaTime;

            source.position = Vector2.MoveTowards(source.position, target, step);
        }
    }
}
