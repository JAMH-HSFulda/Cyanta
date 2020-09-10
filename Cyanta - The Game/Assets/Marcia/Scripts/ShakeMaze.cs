using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMaze : MonoBehaviour
{
    Vector3 originalPos;
    public float shakeLength = 0.7f;
    public float shakeTimer;
    public float shakeAmount = 0.2f;
    public float shakeSpeed = 2;
    public bool isShaking = false;
    public Transform cameraTrans;
    

    public void Start () {
        shakeTimer = shakeLength;
        
    }

    public void shake() {
        originalPos = cameraTrans.localPosition;
        if (shakeTimer > 0) {
            cameraTrans.localPosition = Vector3.Lerp(cameraTrans.localPosition, originalPos + Random.insideUnitSphere * shakeAmount, shakeSpeed);
            shakeTimer -= Time.deltaTime;
        } else {
            cameraTrans.position = originalPos;
            shakeTimer = 0;
            isShaking = false;
        }
    }

}
