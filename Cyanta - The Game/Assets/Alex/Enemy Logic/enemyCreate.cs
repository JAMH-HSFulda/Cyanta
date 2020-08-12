using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCreate : MonoBehaviour
{
  
    
    public Transform player;
    public GameObject enemy;
    private Rigidbody rb;

    private Vector3 position;
    private Quaternion angle;
    private List<GameObject> enemyList;

    public int anzEnemy = 0;
    public float enemyTurnSpeed = 4f;
    public int width = 30;
    public int length = 30;
    

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        enemyList = new List<GameObject>();
        enemyList.Add(Generate());
            
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = player.position - enemy.transform.position;
        rb.rotation = Quaternion.Lerp(enemy.transform.rotation, Quaternion.LookRotation(direction), enemyTurnSpeed * Time.deltaTime);
    }

    GameObject Generate() {     
        float x = Random.Range((width/2) * -1, width/2);
        float z = Random.Range((length/2) * -1, length/2);

        enemy.name = "enemy ";
        
        enemy.transform.position = new Vector3(x,1,z);
        return enemy;
    }


}