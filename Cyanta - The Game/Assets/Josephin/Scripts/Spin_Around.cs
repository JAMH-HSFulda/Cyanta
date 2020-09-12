using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_Around : MonoBehaviour {
    //Mithilfe der Unity Dokumentation erstellt 
    //https://docs.unity3d.com/ScriptReference/Transform.RotateAround.html

    GameObject player;
    Collider m_Collider;
    Vector3 m_Center;
    public int speed = 7;
    // Start is called before the first frame update
    void Start () {
        m_Collider = GetComponent<Collider> ();
        m_Center = m_Collider.bounds.center;
        player = GameObject.Find ("Player");
    }

    // Update is called once per frame
    void Update () {
        //Das Tempo der Drehung kann adjustiert werden mithilfe von speed
        transform.RotateAround (m_Center, Vector3.up,
            180 / Vector3.Distance (player.transform.position, transform.position) * speed * Time.deltaTime);

    }
}