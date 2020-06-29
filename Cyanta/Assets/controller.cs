using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    CharacterController control;

    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
     void Start () {
        gameObject.AddComponent<CharacterController>();
        control = gameObject.GetComponent<CharacterController>();
        control.center = new Vector3(0, 1, 0);
     }
     
     // Update is called once per frame
     void Update () {
          groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
     }
}
