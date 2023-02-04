using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudManager : MonoBehaviour
{
    public GameObject cloud;
    public Sprite[] clouds;
    void Start()
    {
        Invoke(nameof(SpawnCloud), 0);
    }

    void SpawnCloud()
    {
        var tmp = Instantiate(cloud, transform);
        var newspeed = Random.Range(0.5f, 1.2f);
        tmp.GetComponent<Cloud>().speed = newspeed;
        tmp.GetComponent<RectTransform>().localPosition += new Vector3(0, Random.Range(-100, 100), newspeed);
        tmp.GetComponent<Image>().sprite = clouds[Random.Range(0, clouds.Length)];
        Invoke(nameof(SpawnCloud), Random.Range(5f, 25f));
    }
}
