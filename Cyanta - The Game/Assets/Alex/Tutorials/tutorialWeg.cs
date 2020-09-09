using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialWeg : MonoBehaviour
{
    // Start is called before the first frame update
    Mesh mesh;
    Rigidbody rb;
    public Vector3 x0, x1, x2, x3, x4, x5, x6, x7;
    public float length = 10, width = 2;
    void Start()
    {
        MeshRenderer meshRender = gameObject.AddComponent<MeshRenderer>();
        GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        mesh = new Mesh();
        rb = gameObject.AddComponent<Rigidbody>();
        
        rb.useGravity = false;

        x0 = new Vector3(0, 0, 0);
        x1 = new Vector3(1 + width , 0, 0);
        x2 = new Vector3(1 + width , 1, 0);
        x3 = new Vector3(0, 1, 0);
        x4 = new Vector3(0, 0, 0 + length);
        x5 = new Vector3(1 + width , 0, 0 + length);
        x6 = new Vector3(1 + width , 1, 0 + length);
        x7 = new Vector3(0, 1, 0 + length);

        meshFilter.mesh = new Mesh();
        mesh = meshFilter.sharedMesh;

        mesh.Clear();
        mesh.vertices = new Vector3[] {x0, x1, x2, x3, x4, x5, x6, x7};
        mesh.triangles = new int[]{
            0,2,1, // v1
            0,3,2, // v2
            4,5,6, // h1
            4,6,7, // h2
            1,6,5, // r1
            1,2,6, // r2
            2,7,6, // o1
            2,3,7, // o2
            0,7,3, // l1
            0,4,7, // l2
            0,5,4, // u1
            0,1,5  // u2
        };

        mesh.name = "Steg";
        mesh.RecalculateNormals();
        // mesh.RecalculateBounds();
        mesh.Optimize();
        gameObject.AddComponent<BoxCollider>();
        Collider col = gameObject.GetComponent<Collider>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        gameObject.transform.position = new Vector3(-1.5f, -3.0f ,-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
