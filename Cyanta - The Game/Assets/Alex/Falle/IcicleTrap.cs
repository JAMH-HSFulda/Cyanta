using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleTrap : MonoBehaviour
{

    public GameObject player, icicle;
    public List<GameObject> ListIcicle;
    public List<Vector3> actualPos;
    public float startHeight = 4f, distanceToPlayer = 5f;
    public float time, x, z, upTime;

    public Mesh mesh;

    public Vector3 x0, x1, x2, x3, x4;
 
    public bool[] boolArray;   
    // private GameObject[][] IcicleArr = new int[number][];

    GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        
        // GameObject[][] IcicleArr = new int[numTraps][,];

        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 3; j++)  {
                clone = Instantiate(icicle, new Vector3(i + icicle.transform.position.x , icicle.transform.position.y + startHeight, j + icicle.transform.position.z), icicle.transform.rotation);
                // MeshRenderer meshRender = clone.AddComponent<MeshRenderer>();
                
                clone.AddComponent<BoxCollider>();
                clone.AddComponent<Rigidbody>();
                clone.AddComponent<MeshRenderer>();

                clone.GetComponent<BoxCollider>().center = new Vector3(0.5f, 3.8f, 0.5f);
                clone.GetComponent<BoxCollider>().isTrigger = true;
                clone.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
                // Bounds bounds = clone.GetComponent<MeshFilter>().mesh.bounds;
                // float yHeight = clone.GetComponent<MeshFilter>().sharedMesh.bounds.size.y;
                clone.GetComponent<BoxCollider>().size = new Vector3(1, 2, 1);
                clone.GetComponent<Rigidbody>().useGravity = false;
                clone.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
               
                clone.transform.parent = gameObject.transform;
                ListIcicle.Add(clone);
            }
        }

        boolArray = new bool[ListIcicle.Count];   

        for (int j = 0; j < boolArray.Length; j++) {
            boolArray[j] = false;
        }

        gameObject.transform.position = new Vector3(x, 1, z);
        icicle.transform.parent = gameObject.transform;

        for (int i = 0; i < ListIcicle.Count; i++) {
            actualPos.Add(ListIcicle[i].transform.position);
        }


    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        
        for (int i = 0; i < ListIcicle.Count;i++) {
            Vector3 direction = ListIcicle[i].transform.position - player.transform.position;
            if (direction.magnitude <= distanceToPlayer) {
                ListIcicle[i].GetComponent<Rigidbody>().useGravity = true;
                time = 0;   
            }

            if (ListIcicle[i].transform.position.y <= -2f) {
                ListIcicle[i].GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePosition;
                boolArray[i] = true;
            } 
        }  
        if (boolArray.Length > 0) {
            if (boolArray[0] == true || boolArray[1] == true || boolArray[2] == true || boolArray[3] == true || boolArray[4] == true ) {
                    time += Time.deltaTime;
            }
        } 

        if  (time >= upTime) {
            for ( int i = 0; i < boolArray.Length;i++) {
                if (ListIcicle[i].transform.position != actualPos[i]) {
                    ListIcicle[i].transform.position = Vector3.MoveTowards(ListIcicle[i].transform.position, actualPos[i], 0.1f);              
                } else {
                    boolArray[i] = false;
                    ListIcicle[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    ListIcicle[i].GetComponent<Rigidbody>().useGravity = false;   
                }
                // if(ListIcicle[i].transform.position == actualPos[i]) {
                //     Debug.Log("Funzt " + i);  
                // }
            }  
        //     if (time > upTime) {
        //     time = 0;
        // } 
        }
        
 
        

        

    }
}
