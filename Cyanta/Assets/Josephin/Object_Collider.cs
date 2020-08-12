using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object_Collider : MonoBehaviour {

    void OnTriggerEnter (Collider other) {
        /*es muss im statement dann bezug auf die GUI/Munitionsanzeige genommen werden und ggf. die Animation gestartet werden*/
        if (other.gameObject.name == "Glow Orb") {
            Debug.Log (this.name + " löscht " + other.gameObject.name);
            Destroy (other.gameObject);
            //Bei Kontakt mit nem Glow - Orb erhöht sich die Anzahl von X-en bzw. die Schussanzahl verringert sich
            if (Ammo.health < 5) {
                Ammo.health += 1;
            } 
            if (Ammo.health == 5) {
                SceneManager.LoadScene ("GameOver");
            }

        }
        if (other.gameObject.name == "Fish" || other.gameObject.name == "Plane") {
            Debug.Log (this.name + " frisst " + other.gameObject.name);
            Destroy (other.gameObject);
            //Wenn Fisch gefressen wurde wird Munition erhöht
            //HOWEVER es kann kein Fisch auf vorrat gefressen werden 
            //(Leben bunkern, war n bug den i gefixt habe)
            if (Ammo.health > 0) {
                Ammo.health -= 1;
            } else if (Ammo.health == 0) {
                Ammo.health = 0;
            }

        }
        //Debug.Log (this.name + " kollidiert mit " + other.gameObject.name);
    }
}