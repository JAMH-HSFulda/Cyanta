using System.Collections;
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

    GameObject ramp, player;

    List<Vector3> positions = new List<Vector3>();
    List<Quaternion> rotation = new List<Quaternion>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        positions.Add(new Vector3(40.5f, 0.2f, 41.5f));
        positions.Add(new Vector3(50f, 0.2f, 60.5f));
        positions.Add(new Vector3(34.5f, .5f, 22.5f));
        positions.Add(new Vector3(56, .5f, 7f));
       
        rotation.Add(new Quaternion(0, 0, 0, 1));
        rotation.Add(new Quaternion(0, 0, 0, 1));
        rotation.Add(new Quaternion(0, 90, 0, 1));
        rotation.Add(new Quaternion(0, 90, 0, 1));

        ramp = new GameObject(); //new gameobject so error of "Meshrenderer already attatched" with instantiate doesn't appear
        ramp.AddComponent<MeshFilter>(); //giving the ramp all the components that shall have been given to this gameobject 
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

        triangles.Add(5); //bottom of mesh doesn't need triangles since it is not shown anyways. 
        triangles.Add(1);
        triangles.Add(4);
                
        normals.Add(Vector3.up); //so its visible to the outside
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

        gameObject.transform.position = new Vector3(7, 0.2f, 27.5f);

        for (int i = 0; i < positions.Count; i++)
        {
            GameObject tmp = Instantiate(ramp, positions[i], rotation[i]);
            tmp.transform.localScale = new Vector3(2.5f, 1.5f, 2.5f);
            tmp.name = "IceRamp" + i;
            tmp.isStatic = true;
        }
    }
}
