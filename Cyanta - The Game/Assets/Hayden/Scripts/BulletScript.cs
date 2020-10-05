using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletScript : MonoBehaviour
{
    public float scale;

    public ParticleSystem burst, muzzle, centerbeam;

    private new Light light;
    
    float timer = 0;

    Boolean move = true;
    Boolean hit = false;

    Boolean calledRot = false;

    private Rigidbody rig;

    public Material materialM;

    void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>(); 
        MeshRenderer mR = gameObject.AddComponent<MeshRenderer>();

        rig = gameObject.AddComponent<Rigidbody>();
        rig.useGravity = true;
        rig.interpolation = RigidbodyInterpolation.Interpolate;
        rig.collisionDetectionMode = CollisionDetectionMode.Continuous;

        scale = 0.7f;
        transform.localScale *= scale;

        Vector3 p0 = new Vector3(-.125f, .1f, 0); 
        Vector3 p1 = new Vector3(.125f, .1f, 0);
        Vector3 p2 = new Vector3(0, -.1f, 0);
        Vector3 p3 = new Vector3(0, 0, .25f);

        Mesh mesh = meshFilter.sharedMesh;
        meshFilter.mesh = new Mesh();
        mesh = meshFilter.sharedMesh;
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

        mR.material = materialM; 

        light = gameObject.AddComponent<Light>();
        gameObject.GetComponent<Light>().range = 12;
        gameObject.GetComponent<Light>().intensity = 1f;
        gameObject.GetComponent<Light>().color = Color.cyan;
        gameObject.GetComponent<Light>().shadows = LightShadows.Hard;
    }

    private void Update()
    {
        if(move)
        {
            rig.velocity = transform.forward * 15;
            rig.AddForce(new Vector3(0, -20, 0)); //as gravity alternative
            if (calledRot)
            {
                rotate();
            }
        }

        timer += Time.deltaTime; 
        if (timer > 5 && hit == false) { //if bullet has not hit anything destroy to save resources
            Destroy(gameObject);
        }
    }

    void rotate() {
        calledRot = true;
        var downrotation = Quaternion.LookRotation(Vector3.down);
        if (move) {
            transform.rotation = Quaternion.Slerp(transform.rotation, downrotation, Time.deltaTime*1.5f); //testing, go back to above if not useful
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

            Destroy(light); //destorys light that was active during the fly, once collided the particle system emits enough light

            Vector3 minus = Vector3.forward;
            
            burst.transform.position = transform.position - minus; //- minus so that the ParticleSys is visible when hitting the ground
            burst.transform.rotation = transform.rotation;

            muzzle.transform.position = transform.position;
            muzzle.transform.rotation = transform.rotation;

            centerbeam.transform.position = transform.position;
            centerbeam.transform.rotation = transform.rotation;
            centerbeam.startColor = Color.cyan; //throughs log but is most efficient way

            burst.Play(true);
            muzzle.Play(true);
            centerbeam.Play(true);
        }
        if (collision.gameObject.tag.Equals("Player")) {
            return;
        }
        if (collision.gameObject.tag.Equals("enemy")) { 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("untagged")) {
            Debug.LogWarning("Ice detected");
        }
    }
}