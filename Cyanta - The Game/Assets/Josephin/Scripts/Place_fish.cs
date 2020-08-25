using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_fish : MonoBehaviour {
    //Koordinaten für das Platzieren der Fische
    int[] xFish = { 3, 6, 0, 12, 51, 81, 67, 78, 63, 52, 42, 24, 30, 6, 14, 6, 18, 42, 24, 9, 36, 54, 36, 45, 57, 72, 69, 87, 81, 66, 72};
    int[] zFish = { 3, 12, 23, 27, 0, 3, 9, 20, 20, 15, 15, 20, 33, 36, 42, 54, 75, 55, 60, 66, 36, 36, 72, 78, 66, 66, 75, 76, 46, 45, 30};

    // Start is called before the first frame update
    public GameObject fish;
    void Start () {
        placeFish ();
    }

    // Update is called once per frame
    void placeFish () {

        for (int i = 0; i < xFish.Length; i++) {
            GameObject clone = Instantiate (fish);
            clone.name = "Fish";
            clone.transform.position = new Vector3 (xFish[i], 0.55f, zFish[i]);
            var rb = clone.GetComponent<Rigidbody> ();
            rb.useGravity = false;
            clone.AddComponent<BoxCollider> ();
            var collider = clone.GetComponent<BoxCollider> ();
            collider.isTrigger = true;
        }
    }
}