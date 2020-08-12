using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour {
    public static int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullAmmo;
    public Sprite emptyAmmo;

    void Update () {
        
        for (int i = 0; i < hearts.Length; i++) {
            if (i < health) {
                hearts[i].sprite = fullAmmo;
            } else {
                hearts[i].sprite = emptyAmmo;
            }
        }

    }
}