using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject spawnPoint;

    public float scale;
    public Material myMat;

    public ParticleSystem burst;
    public ParticleSystem muzzle;

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
        //mR.material = myMat;

        light = gameObject.AddComponent<Light>();
        gameObject.GetComponent<Light>().range = 20;
        gameObject.GetComponent<Light>().intensity = 2f;
        gameObject.GetComponent<Light>().color = Color.cyan;
    }

    private void Update()
    {
        if(move)
        {
            transform.position += transform.forward * .1f;
        }

        timer += Time.deltaTime; //for test purpose
        if (timer > 3 && hit == false) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.name.StartsWith("Bullet")
        if (collision.gameObject.tag.Equals("Bullet")) {
            Destroy(gameObject);
        }
        if (!collision.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<audiomanager>().Play("Impact");
            hit = true;
            move = false;
            rig.constraints = RigidbodyConstraints.FreezeAll;

            Destroy(light);

            GameObject lightGameObject = new GameObject("The Light");
            Light lightComp = lightGameObject.AddComponent<Light>();
            lightComp.color = Color.cyan;
            lightComp.intensity = 5;

            Vector3 minus = Vector3.forward;
            
            lightGameObject.transform.position = transform.position + minus * 2;
            
            burst.transform.position = transform.position - minus;
            burst.transform.rotation = transform.rotation;

            muzzle.transform.position = transform.position;
            muzzle.transform.rotation = transform.rotation;

            burst.Play(true);
            muzzle.Play(true);
        }
        
        //Destroy(gameObject);
    }
}