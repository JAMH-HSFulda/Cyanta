using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_Around : MonoBehaviour {
    GameObject player;
    Collider m_Collider;
    Vector3 m_Center;
    // Start is called before the first frame update
    void Start () {
        m_Collider = GetComponent<Collider> ();
        m_Center = m_Collider.bounds.center;
        player = GameObject.Find ("Player");
    }

    // Update is called once per frame
    void Update () {
        if (transform.position.x - player.transform.position.x < 5 /* || transform.position.z - player.transform.position.z < 3 */) {
            transform.RotateAround (m_Center, Vector3.up, 60 * Time.deltaTime);
        } else if (transform.position.x - player.transform.position.x < 10 /* || transform.position.z - player.transform.position.z < 5 */) { 
            transform.RotateAround (m_Center, Vector3.up, 30 * Time.deltaTime);
        } else {
            transform.RotateAround (m_Center, Vector3.up, 0 * Time.deltaTime);
        }

    }
}