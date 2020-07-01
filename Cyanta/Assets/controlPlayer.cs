using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class controlPlayer : MonoBehaviour
{
    Rigidbody rb;
    InputMaster controls;
    Quaternion currentRotation;
    Vector3 moveVector;
    public Vector3 actualPosition;
    private InputMaster inputAction;

    public float speed = 10.0f;

    public Vector2 move;

    //rotation
    public Vector2 look;


    //Jump
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    void Awake() {
        controls = new InputMaster();

        controls.Gameplay.Shoot.performed += ctx => Shoot();

        controls.Gameplay.Jump.performed += ctx => Jump();
        
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        controls.Gameplay.Look.canceled += ctx => look = Vector2.zero;
    }

    void Start() {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate() {
        Move();
        Turn();
    }

    

    void Shoot() {
        Debug.Log("Hello!");
    }

    void Move() {
        Vector3 actualPosition = transform.position;
        moveVector = new Vector3(move.x, 0, move.y);
        rb.MovePosition(actualPosition + moveVector * Time.deltaTime * speed);
    }

    void Jump() {
        Debug.Log("Jump!");
        Debug.Log(rb.velocity.y);
        if (rb.velocity.y > 0) { 
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y == 0) {
              rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
        

    void Turn() {
        float targetAngle = Mathf.Atan2(look.x,look.y) * Mathf.Rad2Deg;
        currentRotation= Quaternion.Euler(0f, targetAngle, 0f);
        transform.rotation = currentRotation;
    }

    bool isGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, 1.0f);
    }

    void Cam1(){
        Camera.main.transform.position = new Vector3(0,2.0f,-9.9f);
        Camera.main.transform.Rotate(45f,0,0);
        Camera.main.transform.parent = gameObject.transform;
    }

    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Disable();
    }
    
}
