using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector3 Screen_Postion;
    private Vector3 WorldPosition;

    void Start()
    {
        
    }
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        Screen_Postion = Input.mousePosition;

        transform.position = WorldPosition;
    }

}
