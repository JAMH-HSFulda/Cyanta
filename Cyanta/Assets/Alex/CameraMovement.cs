using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    float xRotation;
    //-------------------------------------

    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;

    private Vector3 previousPosition;

    InputMaster controls;

    Vector2 look;

    void Start() {
        Screen.lockCursor = true; 
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

        yaw += speedH * look.x;
        pitch -= speedV * look.y;

        pitch = Mathf.Clamp(pitch, 0f, 70f);

        cam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

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

        
    }
}
