using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowOrbs : MonoBehaviour {
    //Es muss nach starten des Skripts über die GUI bei "Particle System"
    //im Abschnitt "Renderer" das Material "Default-Particle" ausgewählt werden
    //damit den Partikeln das passende Material zugeordnet wird...
    //Das gleiche gilt für das Light, dort muss ein Prefab ausgewählt werden
    // - ansonsten leuchten sie nicht!

    void Start () {
        placeOrbs ();
    }

    void placeOrbs () {
        //Erstellen des OG Orbs
        GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
        //Random Anzahl, welche die anzal von Orbs vorgibt
        int random = Random.Range (5, 25);
        for (int z = 0; z < random; z++) {
            //Orb wird geklont, benannt und random positioniert
            GameObject clone = Instantiate (sphere);
            clone.name = "Glow Orb";
            clone.transform.position = new Vector3 (Random.Range (0, 25), 0.5f, Random.Range (0, 25));
            //Hinzufügen eines Partikel systems, welches accessible ist via main
            clone.AddComponent<ParticleSystem> ();
            var ps = clone.GetComponent<ParticleSystem> ();
            var main = ps.main;
            //random Nummer auswählen für zufällige Farbe
            int random_colour = Random.Range (1, 4);
            if (random_colour == 1) {
                //Die Anzahl an Farben und auch die Farben selbst können geändert werden
                //alternativ durch
                //main.startColor = new Color (236, 224, 121, 255);
                main.startColor = Color.red;
            }
            if (random_colour == 2) {
                main.startColor = Color.green;
            }
            if (random_colour == 3) {
                main.startColor = Color.blue;
            }
            //Generelle Einstellungen am Partikel System um den Glühwürmchen-Effekt zu erzielen
            main.startLifetime = 10.0f;
            main.startSpeed = 0.2f;
            main.startSize = new ParticleSystem.MinMaxCurve (0.1f, 0.1f);;
            main.maxParticles = 10;
            //Einstellungen im Abschnitt "Lights"
            var lights = ps.lights;
            lights.enabled = true;
            lights.ratio = 1.0f;
            lights.useRandomDistribution = false;
            lights.sizeAffectsRange = false;
            lights.intensityMultiplier = 0.5f;
            //Somehow fetch the Prefab of FirelyLight? 
            //lights.light = Instantiate (Resources.Load ("FireflyLight")) as Light;
        }
        //Zerstören der OG sphere
        Destroy (sphere);
    }
}