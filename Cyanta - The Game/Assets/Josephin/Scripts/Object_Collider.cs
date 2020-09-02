using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object_Collider : MonoBehaviour {

    void OnTriggerEnter (Collider other) {
        /*Es muss im statement dann bezug auf die GUI/Munitionsanzeige genommen werden und ggf. die Animation gestartet werden*/
        if (other.gameObject.name == "Glow Orb") {
            Debug.Log (this.name + " löscht " + other.gameObject.name);

            //Sound beim Munition Einsammeln //Marcia
            FindObjectOfType<audiomanager> ().Play ("MunitionSammeln");
            //

            Destroy (other.gameObject);
            //Bei Kontakt mit nem Glow - Orb erhöht sich die Anzahl von X-en bzw. die Schussanzahl verringert sich
            if (Ammo.counter < 5) {
                Ammo.counter += 1;
            }

        }
        if (other.gameObject.name == "Fish") {
            Destroy (other.gameObject);
        }
    }
    //Abfragen der Position und dann laden der Scene
    /* void Update () {
        if (transform.position.x > 35 && transform.position.y > 85) {
            Debug.Log ("ANANAS");
            SceneManager.LoadScene (2); 
        }
    } */
}