using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCollider : MonoBehaviour
{
    public ShakeMaze shakeMaze;
    public GameObject erdbebentrigger;

    // Start is called before the first frame update
    void Start()
    {
        erdbebentrigger.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider colInfo) {
        if(colInfo.name == "Erdbebentrigger") {
            StartCoroutine(shakeMaze.shake(1f, 1f));
            Destroy(erdbebentrigger);
        }
    }
}
