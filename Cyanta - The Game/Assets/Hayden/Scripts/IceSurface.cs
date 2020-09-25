﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSurface : MonoBehaviour
{
    public PhysicMaterial iceSurface;
    public Material iceMat;

    Mesh meshI;

    Vector3 a, b, c, d, e, f;

    public List<Vector3> vertices = new List<Vector3>();
    public List<Vector3> normals = new List<Vector3>();
    public List<Vector2> uv = new List<Vector2>();
    public List<int> triangles = new List<int>();

    GameObject ramp;

    List<Vector3> positions = new List<Vector3>();
    List<Quaternion> rotation = new List<Quaternion>();

    // Start is called before the first frame update
    void Start()
    {
        positions.Add(new Vector3(40.5f, 0.2f, 41.5f));
        positions.Add(new Vector3(50f, 0.2f, 60.5f));
        positions.Add(new Vector3(34.5f, .5f, 22.5f));
       
        rotation.Add(new Quaternion(0, 0, 0, 1));
        rotation.Add(new Quaternion(0, 0, 0, 1));
        rotation.Add(new Quaternion(0, 90, 0, 1));

       

        ramp = new GameObject();
        ramp.AddComponent<MeshFilter>();
        MeshFilter meshFilter = ramp.GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = ramp.AddComponent<MeshRenderer>();
        ramp.AddComponent<MeshCollider>();
        MeshCollider mcs =  ramp.GetComponent<MeshCollider>();
        a = new Vector3(0, .7f, 0);
        b = new Vector3(0, .7f, 1);
        c = new Vector3(1, 0, 0);
        d = new Vector3(1, 0, 1);
        
        e = new Vector3(0, 0, 0);
        f = new Vector3(0, 0, 1);  

        vertices.Add(a);
        vertices.Add(b);
        vertices.Add(c);
        vertices.Add(d);
        vertices.Add(e);
        vertices.Add(f);
       
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);

        triangles.Add(1);
        triangles.Add(3);
        triangles.Add(2);
        
        triangles.Add(0);
        triangles.Add(2);
        triangles.Add(4);
        
        triangles.Add(5);
        triangles.Add(3);
        triangles.Add(1);
        
        triangles.Add(4);
        triangles.Add(1);
        triangles.Add(0);

        triangles.Add(5);
        triangles.Add(1);
        triangles.Add(4);
                
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);

        uv.Add(new Vector2(1, 0)); //1,0
        uv.Add(new Vector2(0, 0)); //0,0
        uv.Add(new Vector2(0, 1)); //0,1
        uv.Add(new Vector2(1, 1)); //1,1
        uv.Add(new Vector2(1, 0)); 
        uv.Add(new Vector2(0, 0)); 

        meshI = new Mesh();
        meshI.name = "ice";

        meshI.vertices = vertices.ToArray();
        meshI.uv = uv.ToArray();
        meshI.triangles = triangles.ToArray();
        meshI.normals = normals.ToArray();
        meshI.RecalculateNormals();

        meshFilter.mesh = meshI;
        meshRenderer.material = iceMat;

        mcs.sharedMesh = meshI;
        mcs.material = iceSurface;


        for (int i = 0; i < positions.Count; i++)
        {
            GameObject tmp = Instantiate(ramp, positions[i], rotation[i]);
            tmp.transform.localScale = new Vector3(2, 1, 2);
            tmp.name = "IceRamp" + i;
            tmp.isStatic = true;
        }
    }
}
