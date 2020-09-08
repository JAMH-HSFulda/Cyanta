using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleTrap : MonoBehaviour
{

    public GameObject icicle, player;
    public List<GameObject> ListIcicle;
    public float startHeight = 4f, distanceToPlayer = 5f;
    

    GameObject clone;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 3; j++)  {
                clone = Instantiate(icicle, new Vector3(i + icicle.transform.position.x , icicle.transform.position.y + startHeight, j + icicle.transform.position.z), icicle.transform.rotation);
                clone.transform.parent = gameObject.transform;
                ListIcicle.Add(clone);
            }
        }
        Destroy(icicle);
        
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
            }
        }

        
        
    }
}
