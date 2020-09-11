using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    private Animator anim;

    public Quaternion rotationBazooka;
    public float y;
    public GameObject firePoint, bullet;

    public static List<GameObject> bulletList;
    
    public ParticleSystem burst, muzzle;

    InputMaster controls;

    float limitZ, limitY, limitX;

    Transform cam;
    public Transform player;

    Quaternion rotation;

    public static int shootCount = 0;

    float speed = 5;
    float torsoRotation = 0;

    void Start() {
        cam = Camera.main.transform;
        bulletList = new List<GameObject>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 direction = (cam.position + new Vector3(0f, -0.0f, 0f)) - transform.position;
        rotation = Quaternion.LookRotation(direction);
        gameObject.transform.rotation = rotation;

        limitY = Mathf.Clamp(gameObject.transform.localEulerAngles.y, 140, 240);
        limitX = Mathf.Clamp(gameObject.transform.localEulerAngles.x, -70, 8);
        limitZ = Mathf.Clamp(gameObject.transform.localEulerAngles.z, 0, 0);
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(limitX + gameObject.transform.eulerAngles.x, limitY + player.transform.eulerAngles.y, limitZ)); //limit + player.transform.eulerAngles.y // + player.transform.eulerAngles.y

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
        if (Ammo.counter > 0)
        {
            anim.SetTrigger("shoots");
            FindObjectOfType<audiomanager>().Play("Shoot");
            burst.Play(true);
            muzzle.Play(true); // playing particlesystems for effects
            GameObject bulletObject = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            //bulletObject.transform.parent = gameObject.transform;
            bulletObject.transform.position = transform.position - transform.forward * 0.2f;
            bulletObject.transform.forward = (firePoint.transform.forward * -1);
            //bulletObject.transform.parent = null;
            shootCount++;
            bulletList.Add(bulletObject);
            Ammo.counter--; //für Testzwecke ausgeschaltet
        }
        else
        {
            FindObjectOfType<audiomanager>().Play("emptyg");
        }
    }

    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Disable();
    }
}

