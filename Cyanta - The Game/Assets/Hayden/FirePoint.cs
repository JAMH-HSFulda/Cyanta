using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bullet;

    public ParticleSystem burst;
    public ParticleSystem muzzle;

    new int name = 0;

    //private float yaw = 0f;
    //private float pitch = 0f;

    // Update is called once per frame
    void Update()
    {
        //Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hitInfo;

        //if (Physics.Raycast(rayOrigin, out hitInfo)) {
        //    if (hitInfo.collider != null) {
        //        gameObject.transform.rotation = Quaternion.LookRotation(hitInfo.point); 
        //    }
        //}

        //yaw += 5 * Input.GetAxis("Mouse X");
        //pitch += 2 * Input.GetAxis("Mouse Y");

        //transform.eulerAngles = new Vector3(pitch, yaw, 0);

        if (Input.GetMouseButtonDown(0))
        {
            burst.Play(true);
            muzzle.Play(true); // continue at 22:30 https://www.youtube.com/watch?v=xenW67bXTgM 
            GameObject test =  Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            test.name = "Bullet +" + name;
            name++;
        }
    }

}

