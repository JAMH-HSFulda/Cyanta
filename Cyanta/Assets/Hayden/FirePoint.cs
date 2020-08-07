using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> list = new List<GameObject>();

    private GameObject effectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = list[0];
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            SpawnVFX();
        }
    }

    void SpawnVFX() {
        GameObject list = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
        
    }

}

