using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour {
    //Man hat am Anfang 5 Schuss
    public static int counter = 5;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullAmmo;
    public Sprite emptyAmmo;

    void Update () {

        for (int i = 0; i < hearts.Length; i++) {
            if (i < counter) {
                hearts[i].sprite = fullAmmo;
            } else {
                hearts[i].sprite = emptyAmmo;
            }
        }

    }
}