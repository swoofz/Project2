using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform tf;   // Create a variable to store our transform component
    public float speed;     // Create a variable to change movement speed

    // Use this for initialization
    void Start () {
        // Load transform component into variable
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        // Move forward in the direction it is facing
        tf.position += tf.up * speed;
        // Destory after 5 sec
        Destroy(gameObject, 5);
	}

    void OnTriggerEnter2D(Collider2D collision) {
        // Check if collides with enemy
        if (collision.gameObject.tag == "Enemy") {
            Destroy(collision.gameObject);  // Destory enemy
            Destroy(gameObject);            // Destory bullet 
        }
    }
}
