using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorscript : MonoBehaviour
{
    public Texture2D cursor;
    void Start()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);   
    }
}
