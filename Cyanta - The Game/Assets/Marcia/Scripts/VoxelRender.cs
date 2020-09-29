using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rendern des Mesh-Labyrinth

[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer))]
public class VoxelRender : MonoBehaviour
{
    
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;
    Vector2[] uvs;
    public float scale = 1f;
    float adjScale;
    //public Material material;
    
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        // gameObject.AddComponent<MeshRenderer>();
        // gameObject.GetComponent<MeshRenderer>().material = material;
        adjScale = scale * 0.5f;
    }

    void Start()
    { 
        GenerateVoxelMesh(new VoxelData());
        UpdateMesh();
        gameObject.AddComponent<MeshCollider>();
    }

    void GenerateVoxelMesh(VoxelData data) {
        //data.fillData(); --> bei zufälligem Füllen des Arrays
        vertices = new List<Vector3> ();
        triangles = new List<int> ();

        for(int z = 0; z < data.Depth; z++) {
            for(int x = 0; x < data.Width; x++) {
                if (data.GetCell (x, z) == 0) {
                    continue;
                }
                MakeCube(adjScale, new Vector3((float) x * scale, 0, (float) z * scale), x, z, data);
            }
        }

        uvs = new Vector2[vertices.Count];
        for(int i = 0; i < uvs.Length; i++) {                   
                    uvs[i] = new Vector2(vertices[i].x, vertices[i].z);                                     
        }
    }

    void MakeCube(float cubeScale, Vector3 cubePos, int x, int z, VoxelData data) {
        for (int i = 0; i < 6; i++) {
            if(data.GetNeighbor(x, z, (Direction)i) == 0) {
                MakeFace((Direction)i, cubeScale, cubePos);
            }
        }
    }

    void MakeFace(Direction dir, float faceScale, Vector3 facePos) {
        vertices.AddRange(CubeMeshData.faceVertices(dir, faceScale, facePos));
        int vCount = vertices.Count;

        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 1);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 + 3);

    }

    void UpdateMesh() {
        mesh.Clear();

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        mesh.uv = uvs;
    }
}
