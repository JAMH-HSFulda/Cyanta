using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menueffects : MonoBehaviour
{

    public GameObject bullet;
    
    void Start()
    {
        FindObjectOfType<audiomanager>().Play("BG");
        GameObject bulletInGround = Instantiate(bullet, new Vector3(52, .8f, 1.42f), Quaternion.identity);
        bulletInGround.transform.eulerAngles = new Vector3(bulletInGround.transform.eulerAngles.x+65,0,0);
    }

}
