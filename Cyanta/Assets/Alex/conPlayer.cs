using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conPlayer : MonoBehaviour
{
    InputMaster controls;
    public float speed = 10f;
    public float turnSpeed = 2f;
    public float jumpVelocity = 5f;
    public Vector3 gravity = new Vector3(0f, -9.81f, 0f);
    public Vector2 move;
    Rigidbody rb;

    Transform cam;

    void Awake() {
        controls = new InputMaster();
       
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
        controls.Gameplay.Jump.performed += ctx => Jump();

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        cam = Camera.main.transform;
        Physics.gravity= new Vector3(0f, -9.81f, 0f);
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float x = move.x;
        float z = move.y;
        Vector3 direction = (cam.right * x) + (cam.forward * z);
        direction.y = 0f;

        if (direction.magnitude >= 0.1f) {
            rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
            // rb.velocity = transform.forward * speed + gravity ;
            rb.MovePosition(transform.position + Time.deltaTime * speed *transform.forward);
        }  
    }

    void Jump() {
        rb.velocity = Vector3.up * jumpVelocity;
    }




    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Disable();
    }
}
