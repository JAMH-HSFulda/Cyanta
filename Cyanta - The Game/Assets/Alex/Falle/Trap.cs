using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 x0, x1, x2, x3, x4;

    public List<GameObject> pfeilList;

    GameObject copy;

    int i = 0, j = 0;

    private Vector3 tempPos;
    public float amplitude = 0.01f, frequency = 0.2f, placeX = 30f, placeY = -5f, placeZ = 10f;
 
    Rigidbody rb;
    void Start()
    {
        // gameObject.transform.position = new Vector3(51.22f, -2.5f, 0.14f);

        copy = gameObject;
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRender = gameObject.AddComponent<MeshRenderer>();
        gameObject.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));

        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        

        x0 = new Vector3(0.5f, 3, 0.5f);
        x1 = new Vector3(0, 0, 0);
        x2 = new Vector3(1, 0, 0);
        x3 = new Vector3(0, 0, 1);
        x4 = new Vector3(1, 0, 1);

        Mesh mesh = meshFilter.sharedMesh;
        if (mesh == null)
        {
            meshFilter.mesh = new Mesh();
            mesh = meshFilter.sharedMesh;
        }
        mesh.Clear();
        mesh.vertices = new Vector3[] { x0, x1, x2, x3, x4 };
        mesh.triangles = new int[]{
            2,1,0,
            4,2,0,
            3,4,0,
            1,3,0,
            1,2,3,
            2,4,3
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();



            while (i < 5) {
                while(j < 4) {
                    GameObject pfeil = Instantiate(copy, new Vector3(j, 0, i), Quaternion.identity);
                    // pfeil.transform.parent = gameObject.transform;
                    pfeil.name = "Spitze" + i;
                    
                    pfeilList.Add(pfeil);
                    
                    j++;
                }
                i++;
                j = 0;
            }

        Debug.Log(pfeilList.Count);

        for (int i = 0; i < 8; i++) {
            pfeilList[i].transform.parent = gameObject.transform;
            pfeilList[i].transform.position += new Vector3(placeX , placeY, placeZ);
        }

        pfeilList[4].transform.position += new Vector3(0,5f,0);
        pfeilList[5].transform.position += new Vector3(0,5f,0);
        pfeilList[6].transform.position += new Vector3(0,5f,0);
        pfeilList[7].transform.position += new Vector3(0,5f,0);

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 tempPos0 = pfeilList[0].transform.position;
        Vector3 tempPos1 = pfeilList[1].transform.position;
        Vector3 tempPos2 = pfeilList[2].transform.position;
        Vector3 tempPos3 = pfeilList[3].transform.position;

        tempPos0.y += Mathf.Sin(Time.time * 4f) * Time.deltaTime * frequency;
        tempPos1.y += Mathf.Sin(Time.time * 4f) * Time.deltaTime * frequency;
        tempPos2.y += Mathf.Sin(Time.time * 4f) * Time.deltaTime * frequency;
        tempPos3.y += Mathf.Sin(Time.time * 4f) * Time.deltaTime * frequency;

        pfeilList[0].transform.position = tempPos0;
        pfeilList[1].transform.position = tempPos1;
        pfeilList[2].transform.position = tempPos2;
        pfeilList[3].transform.position = tempPos3;

        Vector3 tempPos4 = pfeilList[4].transform.position ;
        Vector3 tempPos5 = pfeilList[5].transform.position;
        Vector3 tempPos6 = pfeilList[6].transform.position;
        Vector3 tempPos7 = pfeilList[7].transform.position;

        tempPos4.y += Mathf.Sin(Time.time * 4f + 2) * Time.deltaTime * frequency;
        tempPos5.y += Mathf.Sin(Time.time * 4f + 2) * Time.deltaTime * frequency;
        tempPos6.y += Mathf.Sin(Time.time * 4f + 2) * Time.deltaTime * frequency;
        tempPos7.y += Mathf.Sin(Time.time * 4f + 2) * Time.deltaTime * frequency;

        pfeilList[4].transform.position = tempPos4;
        pfeilList[5].transform.position = tempPos5;
        pfeilList[6].transform.position = tempPos6;
        pfeilList[7].transform.position = tempPos7;

        

        // for (int k = 1; k < 10;k++) {
        //     tempPos = pfeilList[k].transform.position;
        //     tempPos.y += Mathf.Sin(Time.time * 4f) * Time.deltaTime * frequency;
        //     pfeilList[k].transform.position = tempPos;
        // }        
    }
}
