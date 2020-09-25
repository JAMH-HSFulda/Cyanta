using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Object_Collider : MonoBehaviour {

    public int maxMunition = 15, muniProGloworb = 3;
    public int StartMunition = 3;
    public Slider bazooka;
    public Text display_counterAmmo;
    public int deaths = 0;
    public Text deathText;
    public Image skull;
    public ParticleSystem confetti;

    void Start () {
        //Death Counter und Anzahl werden am Anfang nicht angezeigt, est wenn man runtergefallen ist!
        skull.enabled = false;
        deathText.enabled = false;
        Ammo.counter = StartMunition;
        bazooka.value = Ammo.counter;

        

    }

    void OnTriggerEnter (Collider other) {
        /*Es muss im statement dann bezug auf die GUI/Munitionsanzeige genommen werden und ggf. die Animation gestartet werden*/
        if (other.gameObject.name == "Glow Orb") {
            Debug.Log (this.name + " löscht " + other.gameObject.name);

            /* bazooka.value++; */

            //Sound beim Munition Einsammeln //Marcia
            FindObjectOfType<audiomanager> ().Play ("MunitionSammeln");
            //

            Destroy (other.gameObject);
            //Bei Kontakt mit nem Glow - Orb erhöht sich die Anzahl von X-en bzw. die Schussanzahl verringert sich
            if (Ammo.counter < maxMunition) {
                Ammo.counter += muniProGloworb;
            }
        }
        if (other.gameObject.name == "Fish") {
            Destroy (other.gameObject);
        }

        if (other.gameObject.name == "Tut1") {
            SceneManager.LoadScene (2);
        }
        if (other.gameObject.name == "Zieltor") {
            SceneManager.LoadScene (5);
        }
        if (other.gameObject.name == "Finishline") {
            confetti.GetComponent<ParticleSystem> ().Play ();
        }
        if (other.gameObject.name == "Ziellandschaft") {
            deaths += 1;

            skull.enabled = true;
            deathText.enabled = true;

            deathText.text = deaths.ToString ();

            /* Munition.placeOrbs (); */
            if (Ammo.counter < 11) {
                Ammo.counter = 12;
            }

            if (deaths == 3) {
                SceneManager.LoadScene (2);
            }

            //Vielleicht noch nen kleinen "Schrei" abspielen, wenn der Pinguin fällt?
        }
    }

    void Update () {
        bazooka.value = Ammo.counter;
        display_counterAmmo.text = bazooka.value.ToString ();
    }
}