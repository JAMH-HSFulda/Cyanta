using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCameraShake : MonoBehaviour
{
    public Blitz blitz;
    public ShakeCamera shakeCamera;
    public GameObject gewittertrigger;
    public float staerke = 1f;
    void Start()
    {
        //Gewittertrigger unsichtbar machen
        gewittertrigger.GetComponent<Renderer>().enabled = false;
    }
    void Update()
    {
        if(shakeCamera.isShaking == true) {
            shakeCamera.shake();
        }
    }
    void OnTriggerEnter (Collider colInfo) {
        if(colInfo.name == "Gewittertrigger") {
            StartCoroutine(blitz.visibility()); //Blitz sichtbar
            shakeCamera.isShaking = true; //KameraShaken
            FindObjectOfType<audiomanager>().Play("Erdbeben");
            Destroy(gewittertrigger); //--> nur einmal
            //StartCoroutine(shakeMaze.shake(0.5f, staerke));
            
        }
    }

    
}
