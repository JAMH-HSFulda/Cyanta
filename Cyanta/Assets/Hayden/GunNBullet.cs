//Hayden script
//Bullet
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    public Light light;

    public Rigidbody rb; 

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject lightGameObject = new GameObject("Light");

        Light lightComp = lightGameObject.AddComponent<Light>();

        lightComp.color = Color.blue;
        lightComp.intensity = 1;

        lightGameObject.transform.position = gameObject.transform.position - new Vector3(1,0,0);
        
        Destroy(gameObject);
    }
}

//Gun
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float range = 100f;
    public float damage = 10f;

    public Camera fpsCam;

    public Transform firePoint;

    public GameObject bulletPre;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }
    void Shoot() {
        Instantiate(bulletPre, firePoint.position, firePoint.rotation);
    }
}
