using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyRamp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(gameObject, new Vector3(31.5f, 0.2f, 32f), Quaternion.identity);
        Instantiate(gameObject, new Vector3(49.3f, -.2f, 55.5f), Quaternion.identity);
    }

}
