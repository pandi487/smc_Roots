using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private GameObject clock_hand;
    [SerializeField]
    private float clock_amount = 1f;
    [SerializeField]
    private float time_amount;
    [SerializeField]
    private Image clock_image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        clock_hand.transform.rotation = Quaternion.Euler(0, 0, -clock_amount * 360);
        clock_image.fillAmount = clock_amount; 
    }
}
