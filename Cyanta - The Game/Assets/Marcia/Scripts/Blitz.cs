﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blitz : MonoBehaviour
{

    public Mesh mesh;
    public GameObject blitz;
    public List<Vector3> vertices;
    public List<int> faces;
    public List<Vector3> normals;
    public List<Vector2> uvs;
    //public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

        blitz = new GameObject("Zieltor");
        Renderer rend = blitz.AddComponent<MeshRenderer>();
        rend.material = new Material(Shader.Find("Specular"));;
        blitz.AddComponent<MeshFilter>();

        //Mesh dem Tor zuweisen
        mesh = blitz.GetComponent<MeshFilter>().mesh; 

        blitz.transform.localPosition = new Vector3(50, 0, 2);

        makeBlitz(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeBlitz (float x, float y, float z) {
        //Vertices
        Vector3 a = new Vector3(x - 1, y + 1, z);
        Vector3 b = new Vector3(x + 1, y + 1, z);
        Vector3 c = new Vector3(x - 2, y - 1, z);
        Vector3 d = new Vector3(x, y - 1, z);

        Vector3 e = new Vector3(x - 0.5f, y - 0.5f, z);
        Vector3 f = new Vector3(x + 1.5f, y - 0.5f, z);
        Vector3 g = new Vector3(x - 1.5f, y - 2.5f, z);
        Vector3 h = new Vector3(x + 0.5f, y - 2.5f, z);

        Vector3 i = new Vector3(x, y - 2, z);
        Vector3 j = new Vector3(x + 2, y - 2, z);
        Vector3 k = new Vector3(x - 1, y - 4, z);

        Vector3 normal = getNormals(a, b, c);

        vertices.Add(a); normals.Add(normal); uvs.Add(new Vector2(0.0f, 0.0f)); //0
        vertices.Add(b); normals.Add(normal); uvs.Add(new Vector2(1.0f, 0.0f)); //1
        vertices.Add(c); normals.Add(normal); uvs.Add(new Vector2(0.0f, 1.0f)); //2
        vertices.Add(d); normals.Add(normal); uvs.Add(new Vector2(1.0f, 1.0f)); //3
        vertices.Add(e); normals.Add(normal); uvs.Add(new Vector2(0.0f, 0.0f)); //4
        vertices.Add(f); normals.Add(normal); uvs.Add(new Vector2(1.0f, 0.0f)); //5
        vertices.Add(g); normals.Add(normal); uvs.Add(new Vector2(0.0f, 1.0f)); //6
        vertices.Add(h); normals.Add(normal); uvs.Add(new Vector2(1.0f, 1.0f)); //7
        vertices.Add(i); normals.Add(normal); uvs.Add(new Vector2(0.0f, 0.0f)); //8
        vertices.Add(j); normals.Add(normal); uvs.Add(new Vector2(1.0f, 0.0f)); //9
        vertices.Add(k); normals.Add(normal); uvs.Add(new Vector2(0.0f, 1.0f)); //10
        
        faces.Add(0);
        faces.Add(2);
        faces.Add(1);
        faces.Add(2);
        faces.Add(3);
        faces.Add(1);

        faces.Add(4);
        faces.Add(6);
        faces.Add(5);
        faces.Add(6);
        faces.Add(7);
        faces.Add(5);

        faces.Add(8);
        faces.Add(10);
        faces.Add(9);
        
        mesh.triangles = faces.ToArray();
        mesh.normals = normals.ToArray();
        mesh.uv = uvs.ToArray();

    }

    public Vector3 getNormals(Vector3 a, Vector3 b, Vector3 c) {
        Vector3 eins = c-a;
        Vector3 zwei = b-a;
        
        Vector3 kreuzprodukt;
        kreuzprodukt.x = eins.y * zwei.z - eins.z * zwei.y;
        kreuzprodukt.y = eins.z * zwei.x - eins.x * zwei.z;
        kreuzprodukt.z = eins.x * zwei.y - eins.y * zwei.y;
        
        return kreuzprodukt;

    }
}
