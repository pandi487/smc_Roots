using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{

    public CharAppearance pictureGuy;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = this.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("Npc"))
                {
                    if (hit.collider.GetComponent<CharAppearance>().isFather(pictureGuy))
                        Debug.Log("success");
                    else
                        Debug.Log("failure");
                    
                }
            }
        }
    }
}
