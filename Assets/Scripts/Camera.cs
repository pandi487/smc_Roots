using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //public Transform Target_Transform;
    public Vector3 Camera_Offset; 

    [Range(0.1f, 10f)]
    public float Speed = 2f; 
    // Projection의 Orthorgraphic
    public float targetZoomSize = 0.7f; 
    public float smoothTime = 0.5f;    
    private float lastZoomSpeed; 

    void FixedUpdate()
    {
       //Zoom();
        //Follow();
    }


    private void Follow()
    {
        //transform.position = Vector3.Lerp(transform.position,
           // Target_Transform.position + Camera_Offset, Time.deltaTime * Speed);
    }

    private void Zoom()
    {
        //카메라 사이즈, 줌 속도 설정
        float smoothZoomSize = Mathf.SmoothDamp(UnityEngine.Camera.main.orthographicSize, targetZoomSize,
                                            ref lastZoomSpeed, smoothTime);

        UnityEngine.Camera.main.orthographicSize = smoothZoomSize;
    }

}
