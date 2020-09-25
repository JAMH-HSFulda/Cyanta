using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Controller : MonoBehaviour {
    private float timer = 0.0f;
    private float visualTime = 0.0f;
    private float waitTime = 3.6f;

    public float distance;
    public GameObject player;
    public float speed_magnet = 5f;

    public float speed_up = 0.2f;
    public float height = 2.0f;

    private int up;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody> ();
        player = GameObject.Find ("Player");
    }

    // Update is called once per frame
    void Update () {
        distance = Vector3.Distance (transform.position, player.transform.position);
        timer += Time.deltaTime;

        if (distance < 3) {
            float step = speed_magnet * Time.deltaTime;
            transform.position = Vector3.MoveTowards (transform.position, player.transform.position, step);
        }

        Vector3 startposition = transform.position;
        float newY = Mathf.Sin (Time.time * speed_up);
        transform.position = new Vector3 (startposition.x, newY, startposition.z) * height;

        if (timer > waitTime) {
            int random_spin = Random.Range (1, 15);
            if (random_spin % 2 == 0) {
                random_spin = random_spin * -1;
            }
            rb.transform.Rotate (0, random_spin, 0, Space.Self);

            visualTime = timer;
            // Remove the recorded 0.5 seconds.
            timer = timer - waitTime;
        }

    }
}