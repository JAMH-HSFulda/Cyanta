using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float scale;

    public ParticleSystem burst;
    public ParticleSystem muzzle;
    public ParticleSystem centerbeam;

    private new Light light;
    
    float timer = 0;

    Boolean move = true;
    Boolean hit = false;

    private Rigidbody rig;

    void Start()
    { 
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>(); 
        MeshRenderer mR = gameObject.AddComponent<MeshRenderer>();

        rig = gameObject.AddComponent<Rigidbody>();
        rig.useGravity = true;
        rig.interpolation = RigidbodyInterpolation.Interpolate;
        rig.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        scale = 0.7f;
        transform.localScale *= scale;

        //Vector3 p0 = new Vector3(-.25f, 0, -.25f); //0,0,0 zentriert //Nach obenschauend
        //Vector3 p1 = new Vector3(.25f, 0, -.25f);
        //Vector3 p2 = new Vector3(0, 0, .25f);
        //Vector3 p3 = new Vector3(0, Mathf.Sqrt(0.5f), 0);

        Vector3 p0 = new Vector3(-.125f, .1f, 0); 
        Vector3 p1 = new Vector3(.125f, .1f, 0);
        Vector3 p2 = new Vector3(0, -.1f, 0);
        Vector3 p3 = new Vector3(0, 0, .25f);

        Mesh mesh = meshFilter.sharedMesh;
        if (mesh == null)
        {
            meshFilter.mesh = new Mesh();
            mesh = meshFilter.sharedMesh;
        }
        mesh.Clear();
        mesh.vertices = new Vector3[] { p0, p1, p2, p3 };
        mesh.triangles = new int[]{
            0,1,2,
            0,2,3,
            2,1,3,
            0,3,1
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();

        mR.material.color = Color.green; //change for specific material, color,texture?

        light = gameObject.AddComponent<Light>();
        gameObject.GetComponent<Light>().range = 16;
        gameObject.GetComponent<Light>().intensity = 1f;
        gameObject.GetComponent<Light>().color = Color.cyan;
        gameObject.GetComponent<Light>().shadows = LightShadows.Hard;

    }

    private void Update()
    {
        if(move)
        {
            transform.position += transform.forward * .1f;
            //float angle = Mathf.Atan2(rig.velocity.x, rig.velocity.y) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, transform.forward); //trying to turn nozzle towards floor, not working yet
        }

        timer += Time.deltaTime; //for test purpose
        if (timer > 4 && hit == false) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.name.StartsWith("Bullet")
        if (collision.gameObject.tag.Equals("Bullet")) {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("ground"))
        {
            FindObjectOfType<audiomanager>().Play("Impact");
            hit = true;
            move = false;
            rig.constraints = RigidbodyConstraints.FreezeAll;

            Destroy(light);

            Vector3 minus = Vector3.forward;
            
            burst.transform.position = transform.position - minus;
            burst.transform.rotation = transform.rotation;

            muzzle.transform.position = transform.position;
            muzzle.transform.rotation = transform.rotation;

            centerbeam.transform.position = transform.position;
            centerbeam.transform.rotation = transform.rotation;
            centerbeam.startColor = Color.cyan; 


            burst.Play(true);
            muzzle.Play(true);
            centerbeam.Play(true);
        }
        if (collision.gameObject.tag.Equals("enemy")) { 
            //eine int static bei Seal hochzaehlen, wenn int == 2 Destroy(seal)
        }
        
        
        //Destroy(gameObject);
    }
}