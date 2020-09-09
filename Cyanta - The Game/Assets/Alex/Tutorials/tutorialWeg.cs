using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialWeg : MonoBehaviour
{
    // Start is called before the first frame update
    Mesh mesh;
    Rigidbody rb;
    public Vector3 x0, x1, x2, x3, x4, x5, x6, x7;
    void Start()
    {
        MeshRenderer meshRender = gameObject.AddComponent<MeshRenderer>();
        GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        mesh = new Mesh();
        rb = gameObject.AddComponent<Rigidbody>();
        
        rb.useGravity = false;

        x0 = new Vector3(0, 0, 0);
        x1 = new Vector3(1, 0, 0);
        x2 = new Vector3(1, 1, 0);
        x3 = new Vector3(0, 1, 1);
        x4 = new Vector3(0, 0, 0);
        x5 = new Vector3(1, 0, 0);
        x6 = new Vector3(1, 1, 0);
        x7 = new Vector3(0, 1, 1);

        meshFilter.mesh = new Mesh();
        mesh = meshFilter.sharedMesh;

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
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
