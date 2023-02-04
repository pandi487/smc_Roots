using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 1f;
    public RectTransform rect;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        if (rect.transform.position.x > 1200f || rect.transform.position.x < -1200f)
            Destroy(gameObject);
    }
}
