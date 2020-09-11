using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animSc : MonoBehaviour
{
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();    
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("idle");
        if (Input.GetKeyDown("space")) {
            anim.Play("jump");
        }
        
    }
}
