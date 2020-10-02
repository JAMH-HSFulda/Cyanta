using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conPlayer : MonoBehaviour
{
    InputMaster controls;
    public float speed = 10f;
    private float padSpeed;
    private float turnSpeed = 15f;
    public float jumpVelocity = 10f;
    public Vector3 gravity = new Vector3(0f, -9.81f, 0f);
    private float distanceGround;
    public bool isGround;
    public float fallMultiplier = 2f;
    public float lowJumpMultiplier = 2.5f;
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

        distanceGround = GetComponent<Collider>().bounds.extents.y;
        distanceGround = 1.0f;
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        float x = move.x;
        float z = move.y;
        Vector3 direction = (cam.right * x) + (cam.forward * z);
        direction.y = 0f;

        if (Mathf.Abs(move.x) < Mathf.Abs(move.y)) {
            // gameObject.GetComponent<Animation>().Play();
            padSpeed = Mathf.Abs(move.y);
        } else if( Mathf.Abs(move.x) < Mathf.Abs(move.y)) {
            padSpeed = 1;
        }
         else {
            padSpeed = Mathf.Abs(move.x);
        }

        if (direction.magnitude >= 0.1f) {
            rb.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
            // rb.velocity = transform.forward * speed + gravity ;
            rb.MovePosition(transform.position + speed * Time.deltaTime * transform.forward * padSpeed);
        }  
        // else {
        //     rb.velocity = Vector3.zero;
        //     rb.angularVelocity = Vector3.zero;
        // }

        if(Physics.Raycast(transform.position,-Vector3.up, out hit, distanceGround+0.1f)) {
            if (hit.collider.tag == "ground") {
                isGround = true;
            }  
        } else {
            isGround = false;
        }

        if (rb.velocity.y > 0) { 
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y <= 0) {
              rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        

        
    }

    void Jump() {
        if(isGround) {
            rb.velocity = Vector3.up * jumpVelocity;
        }
        
    }


    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Disable();
    }
}
