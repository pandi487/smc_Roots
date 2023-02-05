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
    private float clock_amount = 15;
    private float time_amount = 0;
    [SerializeField]
    private Image clock_image;
    // Start is called before the first frame update
    void Start()
    {
        time_amount = clock_amount;
    }

    // Update is called once per frame
    void SetClockAmount(float amount)
    {
        clock_hand.transform.rotation = Quaternion.Euler(0, 0, -amount * 360);
        clock_image.fillAmount = amount;
    }

    public void NextAge()
    {
        time_amount--;
        SetClockAmount(time_amount / clock_amount);
    }
}
