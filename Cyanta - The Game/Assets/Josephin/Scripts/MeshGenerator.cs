using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    Color[] colours;

    public Vector3 position;

    public Gradient gradient;
    float hoehe;
    float tiefe;

    int xSize = 40;
    int zSize = 40;

    // Start is called before the first frame update
    void Start () {
        mesh = new Mesh ();
        GetComponent<MeshFilter> ().mesh = mesh;
        transform.position = position;
        CreateShape ();
    }

    private void Update () {
        UpdateMesh ();
    }

    void CreateShape () {

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        //landhoehe = new float[xSize * zSize];

        for (int i = 0, z = 0; z <= zSize; z++) {
            for (int x = 0; x <= xSize; x++) {
                float y = Mathf.PerlinNoise (x * .3f, z * .3f) * 2f;
                vertices[i] = new Vector3 (x, y, z);

                if (y > tiefe) {
                    tiefe = y;
                }
                if (y < hoehe) {
                    hoehe = y;
                }
                i++;
            }
        }
        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++) {
            for (int x = 0; x < xSize; x++) {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;

                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

            }
            vert++;
        }

        colours = new Color[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++) {
            for (int x = 0; x <= xSize; x++) {
                float height = Mathf.InverseLerp (hoehe, tiefe, vertices[i].y);
                colours[i] = gradient.Evaluate (height);
                i++;
            }
        }
    }
    void UpdateMesh () {

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colours;

        mesh.RecalculateNormals ();
    }

}