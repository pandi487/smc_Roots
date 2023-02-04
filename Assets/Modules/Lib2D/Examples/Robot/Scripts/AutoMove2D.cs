using UnityEngine;

public class AutoMove2D : MonoBehaviour
{
    private int way = 1;


    void FixedUpdate()
    {
        transform.position += new Vector3(0, 2 * way * Time.deltaTime, 0);
        if (transform.position.y > 3 || transform.position.y < -3)
            way *= -1;
    }
}
