using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCollider : MonoBehaviour
{
    public Blitz blitz;
    public ShakeMaze shakeMaze;
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
        if(shakeMaze.isShaking == true) {
            shakeMaze.shake();
        }
    }

    void OnTriggerEnter (Collider colInfo) {
        if(colInfo.name == "Erdbebentrigger") {
            StartCoroutine(blitz.visibility());
            
            shakeMaze.isShaking = true;

            FindObjectOfType<audiomanager>().Play("Erdbeben");

            //StartCoroutine(shakeMaze.shake(0.5f, staerke));
            
            Destroy(erdbebentrigger);
            
        }
    }

    
}
