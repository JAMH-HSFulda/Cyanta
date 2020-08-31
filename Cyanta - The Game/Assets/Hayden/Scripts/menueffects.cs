using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menueffects : MonoBehaviour
{

    public GameObject bullet;
    
    void Start()
    {
        GameObject bulletInGround = Instantiate(bullet, new Vector3(52, .6f, .4f), Quaternion.identity);
        bulletInGround.transform.eulerAngles = new Vector3(bulletInGround.transform.eulerAngles.x+90,0,0);
    }

}
