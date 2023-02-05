using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEffect : MonoBehaviour
{
    public Image img;
    public float lasttime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClick()
    {
        StartCoroutine("Click", lasttime);
    }

    private IEnumerator Click(float lasttime)
    {
        img.color = new Color(1,1,1,0);
        var cur = lasttime;
        while (cur > 0f)
        {
            cur -= Time.deltaTime;
            img.color = new Color(1,1,1,cur / lasttime);
            yield return null;
        }
    }
}
