using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Declare Variables
    private Transform tf;             // Create a variable to store our transform component
    public GameObject bullet;         // Create a variable to store a bullet gameObject
    public float speed = 0.05f;       // Create a variable to change movement speed
    public float rotSpeed = 5f;       // Create a variable to change rotation speed

	// Use this for initialization
	void Start () {
        // Load transform component into variable
        tf = GetComponent<Transform>();
        // Load player in the middle of the screen
        tf.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () { // Handles Input and player movement
        // Move Forward
        if (Input.GetKey(KeyCode.UpArrow)) {
            tf.position += tf.up * speed;
        }
        // Rotate Right
        if (Input.GetKey(KeyCode.RightArrow)) {
            tf.Rotate(0,0,-rotSpeed);
        }
        // Rotate Left
        if (Input.GetKey(KeyCode.LeftArrow)) {
            tf.Rotate(0,0,rotSpeed);
        }
        // Shoot bullet
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    // Create a function fo the player to be able to shoot
    void Shoot() {
        // If have a bull gameObject
        if (bullet != null) {
            // Instantiate our object
            Instantiate(bullet, tf.position + (tf.up * 1.5f), tf.rotation);
        } else {
            Debug.Log("Warning: No gameObject attached");
        }
    }
}
