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
    
    // Start is called before the first frame update
    void Start()
    {
        Material material = new Material(Shader.Find("Finish_Line"));

        zieltor = new GameObject("Zieltor");
        Renderer rend = zieltor.AddComponent<MeshRenderer>();
        rend.material = material;
        zieltor.AddComponent<MeshFilter>();

        //Mesh dem Tor zuweisen
        torMesh = zieltor.GetComponent<MeshFilter>().mesh; 
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
