using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 x0, x1, x2, x3, x4;

    public List<GameObject> pfeilList;

    GameObject copy;

    int i = 0, j = 0;
    public float amplitude = 0.01f, frequency = 0.2f, placeX = 30f, placeY = -5f, placeZ = 10f;
 
    Rigidbody rb;
    void Start()
    {
        

        MeshRenderer meshRender = gameObject.AddComponent<MeshRenderer>();
        GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        
        

        x0 = new Vector3(0.5f, 0, 0.5f);
        x1 = new Vector3(0, 3, 0);
        x2 = new Vector3(1, 3, 0);
        x3 = new Vector3(0, 3, 1);
        x4 = new Vector3(1, 3, 1);

        meshFilter.mesh = new Mesh();
        mesh = meshFilter.sharedMesh;

        mesh.Clear();
        mesh.vertices = new Vector3[] { x0, x1, x2, x3, x4 };
        mesh.triangles = new int[]{
            2,1,0,
            4,2,0,
            3,4,0,
            1,3,0,
            1,2,3,
            2,4,3
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();


            while (i < 3) {
                while(j < 2) {
                    GameObject pfeil = Instantiate(gameObject, new Vector3(j, 0, i), Quaternion.identity);
                    // pfeil.transform.parent = gameObject.transform;
                    pfeil.name = "Spitze" + i + j;
                    pfeilList.Add(pfeil);
                    j++;
                }
                i++;
                j = 0;
            }

        // Debug.Log(pfeilList.Count);

        for (int i = pfeilList.Count -1; i >= 0; i--) {
            // Debug.Log(pfeilList[i].name + " Index: " + i);
        }

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
