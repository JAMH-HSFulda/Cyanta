using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCameraShake : MonoBehaviour
{
  public Blitz blitz;
    public ShakeCamera shakeCamera;
    public GameObject erdbebentrigger;
    public float staerke = 1f;

    // Start is called before the first frame update
    void Start()
    {
        erdbebentrigger.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeCamera.isShaking == true) {
            shakeCamera.shake();
        }
    }

    void OnTriggerEnter (Collider colInfo) {
        if(colInfo.name == "Erdbebentrigger") {
            StartCoroutine(blitz.visibility());
            
            shakeCamera.isShaking = true;

            FindObjectOfType<audiomanager>().Play("Erdbeben");
            
            Destroy(erdbebentrigger);

            //StartCoroutine(shakeMaze.shake(0.5f, staerke));
            
        }
    }

    
}
