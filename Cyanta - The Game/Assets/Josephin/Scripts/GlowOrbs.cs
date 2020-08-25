using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowOrbs : MonoBehaviour {

    //Koordinaten der Orbs
    int[] xOrb = { 6, 0, 4, 18, 35, 18, 66, 87, 78, 63, 42, 15, 0, 6, 3, 9, 27, 6, 18, 15, 25, 27, 29, 30, 36, 45, 45, 39, 54, 60, 54, 72, 80, 84, 78, 87, 69, 75, 69, 63, 54 };
    int[] zOrb = { 3, 9, 24, 9, 3, 23, 3, 3, 14, 17, 21, 36, 33, 48, 69, 60, 59, 78, 83, 51, 48, 30, 18, 75, 60, 69, 41, 42, 27, 39, 54, 21, 33, 57, 66, 81, 83, 45, 60, 84, 73 };
    //Benötigt für die Particle Systems
    public Material material_particles;
    public Light glow;

    void Start () {
        placeOrbs ();
    }

    void placeOrbs () {
        //Erstellen des OG Orbs
        GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);

        for (int z = 0; z < zOrb.Length; z++) {
            //Orb wird geklont, benannt und den Array-Koordinaten nach positioniert
            GameObject clone = Instantiate (sphere);
            clone.name = "Glow Orb";
            clone.transform.position = new Vector3 (xOrb[z], 1.25f, zOrb[z]);
            var sc = clone.GetComponent<SphereCollider> ();
            sc.isTrigger = true;
            //Hinzufügen des Scripts für's Floaten
            clone.AddComponent<Floater> ();
            //Hinzufügen eines Partikel systems, welches accessible ist via main
            clone.AddComponent<ParticleSystem> ();
            var ps = clone.GetComponent<ParticleSystem> ();
            var main = ps.main;
            //Zuweisen des Materials
            var renderer = clone.GetComponent<ParticleSystemRenderer> ();
            renderer.material = material_particles;

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
            //Nutzen des public Prefab Lights für den Glühwürmchen-Effekt 
            lights.light = glow;
            clone.transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
        }
        //Zerstören der OG sphere
        Destroy (sphere);
    }
}