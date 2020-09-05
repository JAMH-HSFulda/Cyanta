using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZieltorMesh : MonoBehaviour
{

    public Mesh torMesh;
    public GameObject zieltor;
    public List<Vector3> vertices;
    public List<int> faces;
    public List<Vector3> normals;
    public List<Vector2> uvs;
    public int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //Material material = new Material(Shader.Find("Finish_Line"));

        zieltor = new GameObject("Zieltor");
        Renderer rend = zieltor.AddComponent<MeshRenderer>();
        rend.material = new Material(Shader.Find("Specular"));;
        zieltor.AddComponent<MeshFilter>();

        //Mesh dem Tor zuweisen
        torMesh = zieltor.GetComponent<MeshFilter>().mesh; 

        zieltor.transform.localPosition = new Vector3(50, 0, 2);

        cube(0.5f, 0.5f, 0.5f);
        //cube(2.5f, 1f, 2.5f);
        //cube(1, 4, 1);

    }

    public void cube(float x, float y, float z) {
        Debug.Log("CubeTor");

        //Vertices
        //vorne
        Vector3 a = new Vector3(x - 1, y, z - 1);
        Vector3 b = new Vector3(x + 1, y, z - 1);
        Vector3 c = new Vector3(x - 1, y + 2, z - 1);
        Vector3 d = new Vector3(x + 1, y + 2, z - 1);

        //hinten
        Vector3 e = new Vector3(x - 1, y, z + 1);
        Vector3 f = new Vector3(x + 1, y, z + 1);
        Vector3 g = new Vector3(x - 1, y + 2, z + 1);
        Vector3 h = new Vector3(x + 1, y + 2, z + 1);

        Vector3 normal = getNormals(a, b, c);

        vertices.Add(a); normals.Add(normal); uvs.Add(new Vector2(0.0f, 0.0f)); //0
        vertices.Add(b); normals.Add(normal); uvs.Add(new Vector2(1.0f, 0.0f)); //1
        vertices.Add(c); normals.Add(normal); uvs.Add(new Vector2(0.0f, 1.0f)); //2
        vertices.Add(d); normals.Add(normal); uvs.Add(new Vector2(1.0f, 1.0f)); //3
        vertices.Add(e); normals.Add(normal); uvs.Add(new Vector2(0.0f, 0.0f)); //4
        vertices.Add(f); normals.Add(normal); uvs.Add(new Vector2(1.0f, 0.0f)); //5
        vertices.Add(g); normals.Add(normal); uvs.Add(new Vector2(0.0f, 1.0f)); //6
        vertices.Add(h); normals.Add(normal); uvs.Add(new Vector2(1.0f, 1.0f)); //7

        torMesh.vertices = vertices.ToArray();

        //Faces

        //vorne
        faces.Add(1 + counter);
        faces.Add(2 + counter);
        faces.Add(0 + counter);
        faces.Add(3 + counter);
        faces.Add(2 + counter);
        faces.Add(1 + counter);

        //hinten
        faces.Add(4 + counter);
        faces.Add(7 + counter);
        faces.Add(5 + counter);
        faces.Add(6 + counter);
        faces.Add(7 + counter);
        faces.Add(4 + counter);

        //rechts
        faces.Add(5 + counter);
        faces.Add(3 + counter);
        faces.Add(1 + counter);
        faces.Add(7 + counter);
        faces.Add(3 + counter);
        faces.Add(5 + counter);

        //links
        faces.Add(0 + counter);
        faces.Add(6 + counter);
        faces.Add(4 + counter);
        faces.Add(2 + counter);
        faces.Add(6 + counter);
        faces.Add(4 + counter);

        //oben
        faces.Add(3 + counter);
        faces.Add(6 + counter);
        faces.Add(2 + counter);
        faces.Add(7 + counter);
        faces.Add(6 + counter);
        faces.Add(3 + counter);

        //unten
        faces.Add(5 + counter);
        faces.Add(0 + counter);
        faces.Add(4 + counter);
        faces.Add(1 + counter);
        faces.Add(0 + counter);
        faces.Add(5 + counter);

        torMesh.triangles = faces.ToArray();
        torMesh.normals = normals.ToArray();
        torMesh.uv = uvs.ToArray();

        counter += 6;
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
