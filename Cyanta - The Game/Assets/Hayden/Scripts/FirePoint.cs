using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bullet;
    

    public ParticleSystem burst;
    public ParticleSystem muzzle;

    InputMaster controls;

    new int name = 0;

    Transform cam;

    Quaternion rotation;

    public float pitch = 0.0f;
    public float yaw = 0.0f;


    void Start() {
        cam = Camera.main.transform;
    }

    void Update() {
        Vector3 direction = (cam.position + new Vector3(0f, -0.4f, 0f)) - transform.position ;
        rotation = Quaternion.LookRotation(direction);
        // transform.rotation = rotation;
        
        gameObject.transform.rotation = rotation;

        // yaw +=  direction.x;
        // pitch -=  direction.y;

        // pitch = Mathf.Clamp(pitch, 0f, 0f);

        // gameObject.transform.eulerAngles = new Vector3(pitch , yaw, 0.0f);
    }

    void Awake() {
        controls = new InputMaster();

        controls.Gameplay.Shoot.performed += ctx => Shoot();
    }

    void Shoot() {
        Debug.Log("Schießen");
        burst.Play(true);
        muzzle.Play(true); // continue at 22:30 https://www.youtube.com/watch?v=xenW67bXTgM 
        GameObject bulletObject =  Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        bulletObject.transform.parent = gameObject.transform;
        bulletObject.transform.position = transform.position - transform.forward * 0.2f;
        bulletObject.transform.forward = (firePoint.transform.forward * -1);
        bulletObject.transform.parent = null;
        //bulletObject.name = "Bullet +" + name;
        //name++;
    }

    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Disable();
    }

}

