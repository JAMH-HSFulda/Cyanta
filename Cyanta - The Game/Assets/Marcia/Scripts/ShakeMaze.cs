using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMaze : MonoBehaviour
{
    Vector3 originalPos;

    public IEnumerator shake (float dauer, float staerke) {
        originalPos = transform.localPosition;

        float zeit = 0;

        while(zeit < dauer) {
            float x = Random.Range(-0.2f, 0.2f) * staerke;
            float z = Random.Range(-0.2f, 0.2f) * staerke;

            Vector3 neuePos = new Vector3(x, originalPos.y, z);
            transform.localPosition += neuePos;
            zeit += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
