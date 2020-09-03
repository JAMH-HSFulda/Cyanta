using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menueffects : MonoBehaviour
{

    public GameObject bullet;
    
    void Start()
    {
        GameObject bulletInGround = Instantiate(bullet, new Vector3(52, .7f, .4f), Quaternion.identity);
        bulletInGround.transform.eulerAngles = new Vector3(bulletInGround.transform.eulerAngles.x+65,0,0);
    }

}
