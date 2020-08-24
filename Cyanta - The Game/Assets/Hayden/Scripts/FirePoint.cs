using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject firePoint, bullet;

    public static List<GameObject> bulletList;
    
    public ParticleSystem burst, muzzle;

    InputMaster controls;

    new int name = 0;

    Transform cam;

    Quaternion rotation;

    public float pitch = 0.0f;
    public float yaw = 0.0f;

    public static int shootCount = 0;

    void Start() {
        cam = Camera.main.transform;
        bulletList = new List<GameObject>();
    }

    void Update()
    {
        Vector3 direction = (cam.position + new Vector3(0f, -0.4f, 0f)) - transform.position;
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

    public static void destroyBuellets() { //static to make it callable from the DamageNheal script
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet"); //creating an array of gameobjects contining all with the tag "Bullet"
        foreach (GameObject Bullet in bullets)
            GameObject.Destroy(Bullet);
    }

    void Shoot() {
        FindObjectOfType<audiomanager>().Play("Shoot");
        Debug.Log("Schießen");
        burst.Play(true);
        muzzle.Play(true); // playing particlesystems for effects
        GameObject bulletObject =  Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        bulletObject.transform.parent = gameObject.transform;
        bulletObject.transform.position = transform.position - transform.forward * 0.2f;
        bulletObject.transform.forward = (firePoint.transform.forward * -1);
        bulletObject.transform.parent = null;
        shootCount++;
        bulletList.Add(bulletObject);
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

