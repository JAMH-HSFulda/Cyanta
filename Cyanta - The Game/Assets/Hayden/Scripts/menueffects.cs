using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class menueffects : MonoBehaviour
{

    public GameObject bullet;

    public Text startb;
    public Text goalb;
    public Text exitb;

    Color fade = Color.cyan;
    Color fade2 = Color.cyan;
    Color fade3 = Color.cyan;
    public float spawnTime;
    
    void Start()
    {
        fade.a = 0;
        startb.color = fade; //individual colors in order to set them differently
        goalb.color = fade;
        exitb.color = fade;

        FindObjectOfType<audiomanager>().Play("BG");
        GameObject bulletInGround = Instantiate(bullet, new Vector3(55, .8f, 2.342f), Quaternion.identity);
        bulletInGround.transform.eulerAngles = new Vector3(bulletInGround.transform.eulerAngles.x+65,0,0); //bullet close to player as light source

        spawnTime = Time.time;
    }

    void Update()
    {
        if (fade.a < 1) 
        {
            SetAlpha((Time.time - spawnTime) * .1f); //call function to slowly fade in the text of the buttons
        }   
    }

    void SetAlpha(float alpha) 
    {        
        fade.a = Mathf.Clamp(alpha, 0, 1);
        fade2.a = Mathf.Clamp(alpha*.7f, 0, 1); //alpha*x is different so they appear one after the other
        fade3.a = Mathf.Clamp(alpha*.5f, 0, 1);

        startb.color = fade;
        goalb.color = fade2;
        exitb.color = fade3;
    }

}
