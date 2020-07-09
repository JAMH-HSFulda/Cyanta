using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Collider : MonoBehaviour {

    void OnTriggerEnter (Collider other) {
        /*es muss im statement dann bezug auf die GUI/Munitionsanzeige genommen werden und ggf. die Animation gestartet werden*/
        if (other.gameObject.name == "Glow Orb") {
            Debug.Log (this.name + " löscht " + other.gameObject.name);
            Destroy (other.gameObject);
        }
        Debug.Log (this.name + " kollidiert mit " + other.gameObject.name);
    }
}