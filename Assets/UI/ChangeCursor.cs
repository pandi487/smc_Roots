using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField]
    Texture2D cursorImg;
    [SerializeField]
    Texture2D cursorClk;

    bool isDown;

    private void Start()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorClk, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    
}