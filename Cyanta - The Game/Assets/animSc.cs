using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animSc : MonoBehaviour
{
    Animator anim;
    InputMaster controls;
    // Start is called before the first frame update

    void Awake() {
        controls = new InputMaster();
       
        controls.Gameplay.Jump.performed += ctx => Jump();

    }
    void Start()
    {
        anim = GetComponent<Animator>();    

    }

    // Update is called once per frame

    void Jump() {
        anim.SetTrigger("jumps");
        Debug.Log("Jump");
    }
    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Disable();
    }
}