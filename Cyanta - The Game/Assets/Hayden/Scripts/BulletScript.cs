using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float scale;
    public Material myMat;

    public ParticleSystem burst;
    public ParticleSystem muzzle;
    
    float timer = 0;

    Boolean move = true;

    private Rigidbody rig;

    void Start()
    {        
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>(); 
        MeshRenderer mR = gameObject.AddComponent<MeshRenderer>();

        rig = gameObject.AddComponent<Rigidbody>();
        rig.useGravity = false;
        rig.interpolation = RigidbodyInterpolation.Interpolate;

        scale = 0.7f;
        gameObject.transform.localScale *= scale;

        //vector3 p0 = new vector3(-.5f, 0, 0); Original
        //vector3 p1 = new vector3(.5f, 0, 0);
        //vector3 p2 = new vector3(0.5f, 0, 1);
        //vector3 p3 = new vector3(0.5f, mathf.sqrt(0.75f), (mathf.sqrt(0.75f) / 3));

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

        gameObject.transform.localPosition = new Vector3(0, 0, 0);
        //transform.rotation *= Quaternion.AngleAxis(180, transform.up);

        mR.material.color = Color.green; //change for specific material, color,texture?
        mR.material = myMat;

        gameObject.AddComponent<Light>();
        gameObject.GetComponent<Light>().range = 10;
        gameObject.GetComponent<Light>().intensity = 1f;
        gameObject.GetComponent<Light>().color = Color.cyan;

    }

    private void Update()
    {
        if(move)
        {
            gameObject.transform.position += Vector3.forward * .1f;
        }

        timer += Time.deltaTime;
        if (timer > 3) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.name.StartsWith("Bullet")
        if (collision.gameObject.tag.Equals("Bullet")) {
            Destroy(gameObject);
        }
        move = false;
        rig.constraints = RigidbodyConstraints.FreezeAll;

        Vector3 minus = Vector3.forward;

        burst.transform.position = collision.transform.position - minus;
        burst.transform.rotation = collision.transform.rotation;

        muzzle.transform.position = collision.transform.position;
        muzzle.transform.rotation = collision.transform.rotation;

        burst.Play(true);
        muzzle.Play(true);
        
        //Destroy(gameObject);
    }
}

