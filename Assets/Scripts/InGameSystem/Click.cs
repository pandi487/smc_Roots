using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public bool isGame = true;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGame)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if(hit.collider != null)
            {
                Debug.Log(hit.collider);
                if(hit.collider.gameObject.tag == "Npc")
                {
                    Debug.Log("npc click");
                }
            }
        }
           
    }
}
