using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class controlPlayer : MonoBehaviour
{
    Rigidbody rb;
    InputMaster controls;
    Vector3 lookVector;

    //move
    [SerializeField]
    CharacterController controller;
    public float speed = 10.0f;

    float turnSmoothVelocity;
    float turnSmoothTime = 0.1f;

    
    //-----------------

    public Vector2 move;

    //rotation
    public Vector2 look;

    


    //Jump
    public float fallMultiplier = 30f;
    public float lowJumpMultiplier = 20f;
    private float playerHight;

    Collider playerCollider;

    void Awake() {
        controls = new InputMaster();

        controls.Gameplay.Shoot.performed += ctx => Shoot();

        // controls.Gameplay.Jump.performed += ctx => jumpHeight = ctx.ReadValue<bool>();
        
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        controls.Gameplay.Look.canceled += ctx => look = Vector2.zero;
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        playerHight = transform.position.y;
        playerCollider = GetComponent<Collider>();
        controller = GetComponent<CharacterController>();
        Camera mycam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    void FixedUpdate() {
        Move();

        
    }

    

    void Shoot() {
        Debug.Log("Shoot!");
    }

    void Move() {
        float x = move.x;
        float z = move.y;
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f,targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // isGrounded = Physics.CheckBox(groundCheck.position, new Vector3(0,-1,0), new Quaternion(1, 1 , 1, 1));

        // if (isGrounded && velocity.y < 0) {
        //     velocity.y = -2f;
        // }

        // float x = move.x;
        // float z = move.y;
        // Vector3 moves = transform.right * x + transform.forward * z;
        // controller.Move(move * speed * Time.deltaTime);
        // velocity.y += gravity * Time.deltaTime;
        // controller.Move(velocity * Time.deltaTime);
        

        // cam = new Vector3(cam.x, 0 ,cam.z);
        // float angle = Vector3.Angle(cam, transform.forward);
        // -------------------------------
        // float targetAngle = Mathf.Atan2(cam.x,cam.y) * Mathf.Rad2Deg;
        // currentRotation= Quaternion.Euler(0f, targetAngle, 0f);
        // transform.rotation = currentRotation ;
        

        

        // if ((move.x < 0.09f && move.x > -0.09f) && (move.y < 0.09f && move.y > -0.09f)) {
        //     moveVector = new Vector3(0, 0, 0);
        // } else {
        //     moveVector = new Vector3(move.x, 0, move.y);
        //     Vector3 actualPosition = transform.position ;
        //     rb.MovePosition(transform.position + Camera.main.transform.forward  * speed * Time.deltaTime );
        // }

        // cam = new Vector3(cam.x, 0 ,cam.z);
        // moveVector = new Vector3(look.x , 0,  look.y);
        // transform.LookAt(transform.position + moveVector);


        
        
        
        
        //---------------------------------------

        // moveVector = new Vector3(move.x * 10f, rb.velocity.y,  move.y);
        // transform.LookAt(transform.position + new Vector3(move.x, 0, move.y));
        // rb.velocity = moveVector;
        

        // heading += move.x * Time.deltaTime * 180;
        // camPivot.rotation = Quaternion.Euler(0, heading, 0);

        // move = Vector2.ClampMagnitude(move, 1);

        // Vector3 camF = cam.forward;
        // Vector3 camR = cam.right;

        // camF.y = 0;
        // camR.y = 0;
        // camF = camF.normalized;
        // camR = camR.normalized;

        // rb.MovePosition(( camF * move.y + camR * move.x) * Time.deltaTime * speed);

        // 

        //  moveVector.Set(move.x, 0, move.y);
        // if (move.x != 0 || move.y != 0) {
        //     rb.MoveRotation(Quaternion.LookRotation(moveVector));
        // }
        // moveVector = moveVector.normalized * speed * Time.deltaTime;
        // rb.MovePosition(transform.position + moveVector);

        
    }

    void Jump() {
        // Debug.Log("Jump!");
        // if ( rb.velocity.y == 0 ) {
        //     Vector3 jumpVelocity = new Vector3 (0, lowJumpMultiplier, 0);
        //     rb.velocity += jumpVelocity * Time.deltaTime;
        // } else if (rb.velocity.y < 0 ) {
        //      Vector3 jumpVelocity = new Vector3 (0, fallMultiplier, 0);
        //     rb.velocity += jumpVelocity * Time.deltaTime;
        // }
        // Debug.Log("Jump!");
        // Debug.Log(rb.velocity.y);
        // if (rb.velocity.y > 0) { 
        //     rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        // } else if (rb.velocity.y == 0) {
        //       rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        // }
    }
        

    void Turn() {
        if ((look.x < 0.09f && look.x > -0.09f) && (look.y < 0.09f && look.y > -0.09f)) {
            lookVector = new Vector2(0, 0);
        } else {
            lookVector = new Vector2(look.x, look.y);
        }
        

    }

    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Disable();
    }
    
}
