using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public HealthSystem healthSystem = new HealthSystem(3);
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float clamp = 60;
    public float camDown;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    float xRotation;
    public int gameCounter = 0;
    //-------------------------------------

    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;

    private Vector3 previousPosition;
    InputMaster controls;

    Vector2 look;
    public float rotat;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
     void Awake() {
        controls = new InputMaster();
        

        controls.Gameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        controls.Gameplay.Look.canceled += ctx => look = Vector2.zero;
    }


    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Disable();
    }

    private void Update() {

        //Player fällt runter
        if(target.transform.position.y < -5) {
            pitch = 10;
            yaw = 0;
        }

        if (healthSystem.GetHealth() <= 0) {
            pitch = 10;
            yaw = 0;
        }

        yaw += speedH * look.x;
        pitch -= speedV * look.y;

        pitch = Mathf.Clamp(pitch, 0f, clamp);

        if(look != null) {
            cam.transform.rotation = Quaternion.Euler(new Vector3(pitch + camDown, yaw, 0.0f));
        } 

        Vector3 input = new Vector3(look.x, 0 , look.y);
        previousPosition = cam.ScreenToViewportPoint(input);

        Vector3 newPosition = cam.ScreenToViewportPoint(input);
        Vector3 direction = previousPosition - newPosition;

        float rotationAroundYAxis = -direction.x * 180; 
        float rotationAroundXAxis = direction.y * 180;

        cam.transform.position = target.position;
        
        cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
        cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);
        
        cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

        previousPosition = newPosition;

        rotat = cam.transform.rotation.eulerAngles.y;

        
    }

    public void Respawn() {
        float yRotation = cam.transform.eulerAngles.y;
        
        Debug.Log("MACH WAS!");
    }
}
