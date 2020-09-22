using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 x0, x1, x2, x3, x4;

    public List<GameObject> pfeilList;

    public Mesh mesh;


    public GameObject copy;

    int i = 0, j = 0;
    public float amplitude = 0.01f, frequency = 0.2f, placeX = 30f, placeY = -5f, placeZ = 10f;
 
    Rigidbody rb;
    void Start()
    {
        MeshRenderer meshRender = gameObject.AddComponent<MeshRenderer>();
        GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));

        gameObject.AddComponent<MeshFilter>();
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        mesh = new Mesh();

        // MeshCollider col = gameObject.AddComponent<MeshCollider>();
        
        

        // rb = gameObject.AddComponent<Rigidbody>();
        // rb.useGravity = false;
        meshFilter.mesh = new Mesh();
        mesh = meshFilter.sharedMesh;
        

        x0 = new Vector3(0.5f, 0, 0.5f);
        x1 = new Vector3(0, 3, 0);
        x2 = new Vector3(1, 3, 0);
        x3 = new Vector3(0, 3, 1);
        x4 = new Vector3(1, 3, 1);

        

        mesh.Clear();
        mesh.vertices = new Vector3[] { x0, x1, x2, x3, x4 };
        mesh.triangles = new int[]{
            1,2,0,
            2,4,0,
            4,3,0,
            3,1,0,
            2,1,3,
            4,2,3
        };

        mesh.name = "Zapfen";
        mesh.RecalculateNormals();
        // mesh.RecalculateBounds();
        mesh.Optimize();
        gameObject.AddComponent<BoxCollider>();
        Collider col = gameObject.GetComponent<Collider>();
        col.isTrigger = true;
        // rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

        // MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        // meshCollider.sharedMesh = mesh;


            // while (i < 3) {
            //     while(j < 2) {
            //         copy = Instantiate(gameObject, new Vector3(j, 0, i), Quaternion.identity);
            //         // copy.transform.parent = gameObject.transform;
            //         copy.name = "Spitze" + i + j;
            //         // pfeilList.Add(copy);
            //         j++;
            //     }
            //     i++;
            //     j = 0;
            // }

        // Debug.Log(pfeilList.Count);

        // for (int i = pfeilList.Count -1; i >= 0; i--) {
        //     // Debug.Log(pfeilList[i].name + " Index: " + i);
        // }

        // for (int i = 0; i < 8; i++) {
        //     pfeilList[i].transform.parent = gameObject.transform;
        //     pfeilList[i].transform.position += new Vector3(placeX , placeY, placeZ);
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
