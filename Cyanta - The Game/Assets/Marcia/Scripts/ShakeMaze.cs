using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMaze : MonoBehaviour
{
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
       
            //StartCoroutine(shake(1f, 2f));

    }

    public IEnumerator shake (float dauer, float staerke) {
        float zeit = 0;

        while(zeit < dauer) {
            float x = Random.Range(-1f, 1f) * staerke;
            float z = Random.Range(-1f, 1f) * staerke;

            Vector3 neuePos = new Vector3(x, originalPos.y, z);
            transform.localPosition += neuePos;
            zeit += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
