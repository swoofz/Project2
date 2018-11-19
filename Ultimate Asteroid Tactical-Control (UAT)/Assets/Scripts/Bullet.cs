using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform tf;   // Create a variable to store our transform component
    public float speed;     // Create a variable to change movement speed

    // Use this for initialization
    void Start () {
        tf = GetComponent<Transform>();   // Load transform component into variable
    }
	
	// Update is called once per frame
	void Update () {
        tf.position += tf.right * speed;    // Move forward in the direction it is facing
        Destroy(gameObject, 5);             // Destory after 5 sec

        if (PlayerController.instance == null) {    // If there is not PlayerContoller in the scene
            Destroy(gameObject);                    // Destory all gameObject with this component
        }
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {  // If collides with enemy
            Destroy(collision.gameObject);          // Destory enemy
            EnemyController.enemies -= 1;           // Update EnemyController component
            Destroy(gameObject);                    // Destory bullet 
        }
    }
}
