using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_fish : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject fish;
    void Start () {
        placeFish ();
    }

    // Update is called once per frame
    void placeFish () {
        int random = Random.Range (0, 15);

        for (int i = 0; i < random; i++) {
            GameObject clone = Instantiate (fish);
            clone.name = "Fish";
            clone.transform.position = new Vector3 (Random.Range (0, 30), 5, Random.Range (0, 30));
            //clone.AddComponent<Rigidbody> ();
            //var rigidbody_sphere = clone.GetComponent<Rigidbody>();
        }
    }
}