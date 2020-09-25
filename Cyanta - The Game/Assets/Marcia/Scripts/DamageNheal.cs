using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageNheal : MonoBehaviour
{
    public HealthSystem healthSystem = new HealthSystem(3);
    public HealthBar healthBar;
    public GameObject player;
    private GameObject respawnPoint;
    public GameObject setRespawnPoint;
    public Camera cam;
    //public Movement movementScript;
    public int gameCounter = 0;

    //weil true automatisch zu false wird (Bug?!)
    // Überflüssig wegen Knockback
    //public bool damageOn = false;
    public float force = 1f;

    //Collision mit Fallen
    void OnTriggerEnter(Collider collisionInfo){
        
        //Kollision mit Fallen, Name muss angepasst werden
        if(collisionInfo.gameObject.tag == "Trap") {
            
            healthSystem.Damage(1);
            Vector3 pushDirection = collisionInfo.transform.position - transform.position;
            pushDirection =- pushDirection.normalized;
            GetComponent<Rigidbody>().AddForce(pushDirection * force * 100);
            
            //if(!damageOn) {
                //StartCoroutine("CoolDown");
            //}
            
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

    //Methode Zeitabfrage nach Damage // Überflüssig wegen Knockback
    /*IEnumerator CoolDown() {
        Debug.Log(damageOn);
        damageOn = true;
        yield return new WaitForSeconds(1f);
        damageOn = false;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        //HealthBar gleich maximale Health
        healthBar.SetMaxHealth(3);

        //Skript zuweisen
        //movementScript = GameObject.Find("Player").GetComponent<Movement>();

        //Empty für den Respawnpunkt
        respawnPoint = new GameObject("respawn");
        respawnPoint.transform.position = setRespawnPoint.transform.position;
        

    }

    void FixedUpdate() {

        //Health gleich 0 --> Spieler stirbt
        if (healthSystem.GetHealth() <= 0) {
            Respawn();
            gameCounter++;
        }

        //Player fällt runter
        if(player.transform.position.y < -5.0f) {
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
        
        gameObject.transform.position = respawnPoint.transform.position;
        //movementScript.targetRotation = respawnPoint.transform.rotation;
        //transform.rotation = movementScript.targetRotation;

        healthSystem.SetHealth(3);        
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
