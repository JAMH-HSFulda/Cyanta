﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBoxSc : MonoBehaviour
{
	public GameObject player;
	GameObject[] all;
    // Start is called before the first frame update
    void Start()
    {
		all = FindObjectsOfType<GameObject>();

		MeshFilter filter = GetComponent(typeof(MeshFilter)) as MeshFilter;
		if (filter != null)
		{
			Mesh mesh = filter.mesh;

			Vector3[] normals = mesh.normals;
			for (int i = 0; i < normals.Length; i++)
				normals[i] = -normals[i];
			mesh.normals = normals;

			for (int m = 0; m < mesh.subMeshCount; m++)
			{
				int[] triangles = mesh.GetTriangles(m);
				for (int i = 0; i < triangles.Length; i += 3)
				{
					int temp = triangles[i + 0];
					triangles[i + 0] = triangles[i + 1];
					triangles[i + 1] = temp;
				}
				mesh.SetTriangles(triangles, m);
			}
		}


	}


    private void Update()
    {
		gameObject.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
    }

}
