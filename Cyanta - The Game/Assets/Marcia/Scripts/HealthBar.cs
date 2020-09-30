using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    //Farbverlauf der Healthbar
    public Gradient gradient;
    public Image fill;

    private HealthSystem healthSystem;

    public void Setup(HealthSystem healthSystem) {
        this.healthSystem = healthSystem;
    }
    
    //Maximale Health zu Beginn
    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
        //Anfangsfarbe der Healthbar
        fill.color = gradient.Evaluate(1f);
    }

    //Anpassen an Slider 
    public void SetHealth (int health) {
        slider.value = health;
        //wechselnde Farben der Healthbar
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
