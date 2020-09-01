using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 x0, x1, x2, x3, x4;

    Rigidbody rb;
    void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRender = gameObject.AddComponent<MeshRenderer>();

        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        

        x0 = new Vector3(0.5f, 3, 0.5f);
        x1 = new Vector3(0, 0, 0);
        x2 = new Vector3(1, 0, 0);
        x3 = new Vector3(0, 0, 1);
        x4 = new Vector3(1, 0, 1);

        Mesh mesh = meshFilter.sharedMesh;
        if (mesh == null)
        {
            meshFilter.mesh = new Mesh();
            mesh = meshFilter.sharedMesh;
        }
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
