using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DamageNheal : MonoBehaviour
{
    public HealthSystem healthSystem = new HealthSystem(3);
    public HealthBar healthBar;
    public GameObject Player;
    public GameObject respawnPoint;
    //public Movement movementScript;
    public int gameCounter = 0;

    //weil true automatisch zu false wird (Bug?!)
    public bool damageOn = false;

    //Collision mit Fallen
    void OnTriggerEnter(Collider collisionInfo){
        Debug.Log("Damage" + damageOn);
        //Kollision mit Fallen, Name muss angepasst werden
        if(collisionInfo.name == "Trap(Clone)") {
            if(!damageOn) {
                healthSystem.Damage(1);
                //StartCoroutine("CoolDown");
            }
            
        }
        //Kollision mit Gegner, Name muss angepasst werden
        if(collisionInfo.name == "Gegner") {
            healthSystem.Damage(1);
        }
        //Kollision mit Munition, Name muss angepasst werden
        if(collisionInfo.name == "Fish") {
            healthSystem.Heal(1);
        }      
    }

    //Methode Zeitabfrage nach Damage
    IEnumerator CoolDown() {
        Debug.Log(damageOn);
        damageOn = true;
        yield return new WaitForSeconds(1f);
        damageOn = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //HealthBar gleich maximale Health
        healthBar.SetMaxHealth(3);

        //Skript zuweisen
        //movementScript = GameObject.Find("Player").GetComponent<Movement>();

        //Empty für den Respawnpunkt
        respawnPoint = new GameObject("respawn");
        respawnPoint.transform.position = new Vector3(51f, 0.2f, 0);

    }

    void Update() {

        //Health gleich 0 --> Spieler stirbt
        if (healthSystem.GetHealth() <= 0) {
            Respawn();
            gameCounter++;
        }

        //Player fällt runter
        if(Player.transform.position.y < -5) {
            Respawn();
            gameCounter++;
            FirePoint.destroyBuellets(); //destroying all bullets once fallen
        }

        //if(gameCounter >= 3) {
        //    FindObjectOfType<GameManager>().EndGame();
        //}

        healthBar.SetHealth(healthSystem.GetHealth());


    }

    //Respawn, was passiert, wenn Player stirbt
    public void Respawn() {
        
        transform.position = respawnPoint.transform.position;
        //movementScript.targetRotation = respawnPoint.transform.rotation;
        //transform.rotation = movementScript.targetRotation;

        healthSystem.SetHealth(3);        
    }
}
