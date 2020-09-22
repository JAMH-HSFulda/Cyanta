using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleTrap : MonoBehaviour
{

    public GameObject icicle, player;
    public List<GameObject> ListIcicle;
    private Hashtable table;
    public float startHeight = 4f, distanceToPlayer = 5f;
    public float time;

    Rigidbody rb;

    public bool[] boolArray;    

    GameObject clone;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 3; j++)  {
                clone = Instantiate(icicle, new Vector3(i + icicle.transform.position.x , icicle.transform.position.y + startHeight, j + icicle.transform.position.z), icicle.transform.rotation);
                clone.AddComponent<Rigidbody>();
                clone.GetComponent<Rigidbody>().useGravity = false;
                clone.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                
                clone.transform.parent = gameObject.transform;
                ListIcicle.Add(clone);
            }
        }
        Destroy(icicle);

        boolArray = new bool[ListIcicle.Count];   

        for (int j = 0; j < boolArray.Length; j++) {
            boolArray[j] = false;
        }
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        
        for (int i = 0; i < ListIcicle.Count;i++) {
            Vector3 direction = ListIcicle[i].transform.position - player.transform.position;
            if (direction.magnitude <= distanceToPlayer) {
                ListIcicle[i].GetComponent<Rigidbody>().useGravity = true;
                
            }

            if (ListIcicle[i].transform.position.y <= 0f) {
                ListIcicle[i].GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePosition;
                boolArray[i] = true;
            } 

            if (boolArray[i] == true) {
                time = time + Time.deltaTime;
                
                // if (time > 5) {
                //     // while (Time.deltaTime < 10) {

                //     // }
                // }
            }  
        }  
    }
}
