using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    Vector3 originalPos;
    public float shakeLength = 0.5f;
    public float shakeTimer;
    public float shakeAmount = 0.1f;
    public float shakeSpeed = 1.5f;
    public bool isShaking = false;
    public Transform cameraTrans;
    

    public void Start () {
        shakeTimer = shakeLength;
        
    }

    public void shake() {
        originalPos = cameraTrans.localPosition;
        
        if (shakeTimer > 0) {
            Debug.Log("Camera is shaking");
            cameraTrans.localPosition = Vector3.Lerp(cameraTrans.localPosition, originalPos + Random.insideUnitSphere * shakeAmount, shakeSpeed);
            shakeTimer -= Time.deltaTime;
        } else {
            cameraTrans.position = originalPos;
            shakeTimer = 0;
            isShaking = false;
        }
    }
}
