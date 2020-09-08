using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_Around : MonoBehaviour {
    public GameObject target;
    public GameObject player;
    int speed = 15;

    Collider m_Collider;
    Vector3 m_Center;
    // Start is called before the first frame update
    void Start () {
        m_Collider = GetComponent<Collider> ();
        m_Center = m_Collider.bounds.center;
    }

    // Update is called once per frame
    void Update () {
        if (player.transform.position.x > 60) {
            speed = 30;
        }
        transform.RotateAround (m_Center, Vector3.up, speed * Time.deltaTime);

    }
}