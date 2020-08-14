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

    void Awake() {
        controls = new InputMaster();

        controls.Gameplay.Shoot.performed += ctx => Shoot();
    }

    void Shoot() {
        burst.Play(true);
        muzzle.Play(true); // continue at 22:30 https://www.youtube.com/watch?v=xenW67bXTgM 
        GameObject test =  Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        test.transform.position = transform.position - transform.forward *0.2f + new Vector3(0, .5f, 0);
        test.transform.forward = (firePoint.transform.forward * -1);

        //test.name = "Bullet +" + name;
        //name++;
    }

    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Disable();
    }

}

