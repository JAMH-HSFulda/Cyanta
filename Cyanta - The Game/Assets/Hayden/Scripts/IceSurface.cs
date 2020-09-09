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

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshCollider mcs = gameObject.AddComponent<MeshCollider>();

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

        transform.position = new Vector3(34.5f, .5f, 22.5f);
        transform.localScale = new Vector3(2, 1, 2);
        transform.Rotate(0, 90, 0 , Space.Self);

        GameObject ice2 = Instantiate(gameObject, new Vector3(31.5f, 0.2f, 32f), Quaternion.identity);
        GameObject ice3 = Instantiate(gameObject, new Vector3(49.3f, -.2f, 55.5f), Quaternion.identity);
    }
}
