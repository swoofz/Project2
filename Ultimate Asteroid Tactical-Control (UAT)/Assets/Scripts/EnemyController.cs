using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public static int enemies;      // Create a variable to keep track of how many gameobject have the EnemyController component
   

    private Transform tf;           // Create a variable to store our transform component
    private Vector3 moveDir;        // Create a variable to store a vector3 for directional movement
    public bool ship;               // Create a variable for what kind of enemy this component is 
    public float speed = 0.05f;     // Create a variable to adjust the movement speed
    public float rotSpeed = 1;      // Create a variable to adjust the rotspeed;
    public int scoreGiver;          // Create a variable to add to score after defeat


    // Use this for initialization
    void Start () {
        enemies += 1;                       // Intailize value when created
        tf = GetComponent<Transform>();     // Load our transform component into a variable
        GetMoveDir();                       // Get the direction to move
    }
	
	// Update is called once per frame
	void Update () {

        if (PlayerController.instance != null) {    // If there is a playerController in the scene
            tf.position += moveDir * speed;         // Move torward the target's position when instantiated

            if (ship) {                         // If the is a ship type enemy
                GetMoveDir();                   // Move torwards the target always  
                tf.right = moveDir * rotSpeed;  // Rotate torwards player
            }
        } else {                    // If not playerController
            Destroy(gameObject);    // Destory all objects with this component
            enemies = 0;            // Reset enemy count
        }
	}

    void GetMoveDir() {
        moveDir = PlayerController.instance.gameObject.transform.position - tf.position;    // Find the distance needed to travel torwards the player
        moveDir.Normalize();                                                                // Set magnitude to 1
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {     // If collided with player
            Destroy(collision.gameObject);              // Destory player object
            GameManager.instance.PlayerDied();          // Tell the GameManager that player has died
        }
    }

    public void AddScore() {
        GameManager.score += scoreGiver;
    }
}
