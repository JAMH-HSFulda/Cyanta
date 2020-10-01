using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBrain : MonoBehaviour
{
  // Start is called before the first frame update

    public AudioClip augaug;
    public AudioSource audioSource;
    Rigidbody rb;
    public Transform player;
    private Vector3 movement;
    public float enemySpeed = 5;
    public float enemyRadius = 10f;

    public float rotSpeed = 3f;
    void Start()
    {
        // gameObject.AddComponent<Rigidbody>();
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        gameObject.AddComponent<AudioSource>();
        audioSource = gameObject.GetComponent<AudioSource>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;

        if (direction.magnitude <= enemyRadius) {
            rb.rotation = Quaternion.Lerp(rb.rotation,Quaternion.AngleAxis(angle, Vector3.up), rotSpeed * Time.deltaTime);
            direction.Normalize();
            movement = direction;
            rb.MovePosition((Vector3)transform.position + (direction * enemySpeed * Time.deltaTime));
        }
        
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Bullet") {
            Destroy(other.gameObject);
            Destroy(gameObject);
            audioSource.PlayOneShot(augaug,0.4f);
        }
    }
}