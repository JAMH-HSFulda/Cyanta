using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leveldesign : MonoBehaviour
{
    int munition = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI() {
        GUIStyle style = new GUIStyle();
        style.fontSize = 27;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 0, 0, 0), "Remaining munitions:" + munition,  style);
    }
}
