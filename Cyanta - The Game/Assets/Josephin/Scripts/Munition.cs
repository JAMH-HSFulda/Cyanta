using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munition : MonoBehaviour {
    int[] xOrb = { 6, 0, 4, 18, 35, 18, 66, 87, 78, 63, 42, 15, 0, 6, 3, 9, 27, 6, 18, 15, 25, 27, 29, 30, 36, 45, 45, 39, 54, 60, 54, 72, 80, 84, 78, 87, 69, 75, 69, 63, 54 };
    int[] zOrb = { 3, 9, 24, 9, 3, 23, 3, 3, 14, 17, 21, 36, 33, 48, 69, 60, 59, 78, 83, 51, 48, 30, 18, 75, 60, 69, 41, 42, 27, 39, 54, 21, 33, 57, 66, 81, 83, 45, 60, 84, 73 };

    public Gradient colour_particles;
    public Material material_particles;
    public Material myMaterial;
    public Light glow;
    GameObject okta;
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    
    Vector3 m_Center;

    // Start is called before the first frame update
    void Start () {
        buildOktaeder ();
        updateOktaeder ();
        placeOrbs ();
    }

    // Update is called once per frame
    void buildOktaeder () {
        //Erstellen des GO mit benötigten Componenten
        okta = new GameObject ("Glow Orb");
        okta.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
        Renderer renderer = okta.AddComponent<MeshRenderer> ();
        renderer.material = myMaterial;
        okta.AddComponent<MeshFilter> ();
        mesh = okta.GetComponent<MeshFilter> ().mesh;
        //Anpassen vom Collider, sodass die Drehung ohne Probleme stattfindet
        CapsuleCollider mc_okta = okta.AddComponent<CapsuleCollider> ();
        mc_okta.isTrigger = true;
        mc_okta.center = new Vector3 (0.5f, 0, 0.5f);
        mc_okta.height = 2;
        mc_okta.radius = 0.55f;

        m_Center = mc_okta.bounds.center;

        Rigidbody rb_okta = okta.AddComponent<Rigidbody> ();
        rb_okta.useGravity = false;

        //Rauskopiert vom OG Skript, dient dem Hinzufügen des Partikelsystems
        okta.AddComponent<ParticleSystem> ();
        var ps = okta.GetComponent<ParticleSystem> ();

        //Zuweisen des Materials
        var ps_renderer = okta.GetComponent<ParticleSystemRenderer> ();
        ps_renderer.material = material_particles;

        //Zuweisen der Partikelfarben durch ausgewählten Gradient
        var main = ps.main;
        var randomColors = new ParticleSystem.MinMaxGradient(colour_particles);
        randomColors.mode = ParticleSystemGradientMode.RandomColor;
        main.startColor = randomColors;
        /* //random Nummer auswählen für zufällige Farbe
        int random_colour = Random.Range (1, 4);
        if (random_colour == 1) {
            //Die Anzahl an Farben und auch die Farben selbst können geändert werden
            //alternativ durch
            main.startColor = new Color (0, 184, 217, 85);
            //main.startColor = Color.red;
        }
        if (random_colour == 2) {
            main.startColor = new Color (67, 200, 223, 88);
            //main.startColor = Color.green;
        }
        if (random_colour == 3) {
            main.startColor = new Color (135, 209, 222, 87);
            //main.startColor = Color.blue;
        } */
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
        lights.intensityMultiplier = 0.7f;
        lights.light = glow;

        vertices = new Vector3[] {
            new Vector3 (0, 0, 0), //unten links
            new Vector3 (0.5f, 1, 0.5f), //oben
            new Vector3 (1, 0, 0), //unten rechts
            new Vector3 (0.5f, -1, 0.5f), //unten
            new Vector3 (0, 0, 1), //unten links unter OG
            new Vector3 (1, 0, 1) //unten rechts unter OG

        };
        triangles = new int[] {
            0,
            1,
            2, //oben OG
            0,
            2,
            3, //unten OG
            4,
            1,
            0, //oben links OG
            4,
            0,
            3, //unten links OG
            5,
            1,
            4, //unten oben unter OG
            5,
            4,
            3, //unten unter unten OG
            2,
            1,
            5, //rechts oben
            2,
            5,
            3
        };

        okta.AddComponent<Spin_Around> ();

    }
    void placeOrbs () {
        for (int z = 0; z < zOrb.Length; z++) {
            GameObject clone = Instantiate (okta);
            clone.name = "Glow Orb";
            clone.transform.position = new Vector3 (xOrb[z], 1.25f, zOrb[z]);

            var ps = clone.GetComponent<ParticleSystem> ();
            var main = ps.main;

            /* int random_colour = Random.Range (1, 4);
            if (random_colour == 1) {
                //Die Anzahl an Farben und auch die Farben selbst können geändert werden
                //alternativ durch
                main.startColor = new Color (0, 184, 217, 85);
                //main.startColor = Color.red;
            }
            if (random_colour == 2) {
                main.startColor = new Color (67, 200, 223, 88);
                //main.startColor = Color.green;
            }
            if (random_colour == 3) {
                main.startColor = new Color (135, 209, 222, 87);
                //main.startColor = Color.blue;
            } */
        }
    }
    void updateOktaeder () {
        mesh.Clear ();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals ();
    }
}