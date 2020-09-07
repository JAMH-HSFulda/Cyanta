using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oktaeder : MonoBehaviour {
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    // Start is called before the first frame update
    void Start () {
        buildmesh ();
        updateMesh ();
    }

    void buildmesh () {
        mesh = new Mesh ();
        GetComponent<MeshFilter> ().mesh = mesh;
        vertices = new Vector3[] {
            new Vector3 (0, 0, 0), //unten links
            new Vector3 (0.5f, 1, 0.5f), //oben
            new Vector3 (1, 0, 0), //unten rechts
            new Vector3 (0.5f, -1, 0.5f), //unten
            new Vector3 (0, 0, 1), //unten links unter OG
            new Vector3 (1, 0, 1) //unten rechts unter OG

        };
        triangles = new int[] {
            0,
            1,
            2, //oben OG
            0,
            2,
            3, //unten OG
            4,
            1,
            0, //oben links OG
            4,
            0,
            3, //unten links OG
            5,
            1,
            4, //unten oben unter OG
            5,
            4,
            3, //unten unter unten OG
            2,
            1,
            5, //rechts oben
            2,
            5,
            3
        };
    }

    void updateMesh () {
        mesh.Clear ();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals ();
    }

}