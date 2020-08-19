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


    void Start() {
        cam = Camera.main.transform;
    }

    void Update() {
        Vector3 direction = (cam.right) + (cam.forward);
        // Quaternion rotation = Quaternion.LookRotation(gameObject.transform.position, cam.transform.position);
        // transform.rotation = rotation;
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
    }

    void Awake() {
        controls = new InputMaster();

        controls.Gameplay.Shoot.performed += ctx => Shoot();
    }

    void Shoot() {
        burst.Play(true);
        muzzle.Play(true); // continue at 22:30 https://www.youtube.com/watch?v=xenW67bXTgM 
        GameObject bulletObject =  Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        bulletObject.transform.parent = gameObject.transform;
        bulletObject.transform.position = transform.position - transform.forward * 0.2f + new Vector3(1f, 0, 0);
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

