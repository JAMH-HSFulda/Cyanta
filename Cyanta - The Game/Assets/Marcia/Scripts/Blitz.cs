using System.Collections;
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
    private MeshRenderer rend;
    private MeshFilter filter;
    public Material material;
    public bool visible = false;
    //public int counter = 0;
    public GameObject BlitzEmpty;

    // Start is called before the first frame update
    void Start()
    {
  
        blitz = new GameObject("Blitz");
        rend = blitz.AddComponent<MeshRenderer>();
        rend.material = material;
        blitz.AddComponent<MeshFilter>();

        //Mesh den Blitz zuweisen
        mesh = blitz.GetComponent<MeshFilter>().mesh;
        //rend.enabled = visible;
        Debug.Log("visib" + visible);

        //blitz.transform.localPosition = new Vector3(-2, 10, 5);
        blitz.transform.localRotation = Quaternion.Euler(0, 160, 0);

        makeBlitz(0.5f, 1.2f, 0.5f);

        blitz.transform.parent = BlitzEmpty.transform;
        blitz.transform.position = BlitzEmpty.transform.position + new Vector3(-2, 5, 10);
        
    }

    // Update is called once per frame
    void Update()
    {
        rend.enabled = visible;
    }

    public void makeBlitz (float x, float y, float z) {
        //Vertices
        Vector3 a = new Vector3(- 1 * x, + 1 * y, 0 * z);
        Vector3 b = new Vector3(+ 1 * x, + 1 * y, 0 * z);
        Vector3 c = new Vector3(- 2 * x, - 1 * y, 0 * z);
        Vector3 d = new Vector3(0 * x, - 1 * y, 0 * z);

        Vector3 e = new Vector3(- 0.5f * x, - 0.5f * y, 0 * z);
        Vector3 f = new Vector3(+ 1.5f * x, - 0.5f * y, 0 * z);
        Vector3 g = new Vector3(- 1.5f * x, - 2.5f * y, 0 * z);
        Vector3 h = new Vector3(+ 0.5f * x, - 2.5f * y, 0 * z);

        Vector3 i = new Vector3(0 * x, - 2 * y, 0 * z);
        Vector3 j = new Vector3(+ 2 * x, - 2 * y, 0 * z);
        Vector3 k = new Vector3(- 1 * x, - 4 * y, 0 * z);

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
        
        mesh.vertices = vertices.ToArray();
        
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

    public IEnumerator visibility () {
        visible = true;
        Debug.Log("visib" + visible);
        yield return new WaitForSeconds(0.2f);
        visible = false;
        Debug.Log("visib" + visible);
    }
}
