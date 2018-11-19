using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance; // Create a singleton variable for this class

    //Declare Variables
    private Transform tf;             // Create a variable to store our transform component
    public GameObject bullet;         // Create a variable to store a bullet gameObject
    public float speed = 0.05f;       // Create a variable to change movement speed
    public float rotSpeed = 5f;       // Create a variable to change rotation speed

    void Awake() {
        if (instance == null) {             // As long as there is not an instance already set
            instance = this;                // Store THIS instance of the class in the instance variable
            DontDestroyOnLoad(gameObject);  // Don't delete this object if we load a new scene
        } else {
            instance.gameObject.transform.position = new Vector3(0, 0, 0);      // Load player in the middle of the screen
            Destroy(this.gameObject);                                           // There can only be one - delete new object
        }
    }

    // Use this for initialization
    void Start () {
        tf = GetComponent<Transform>();    // Load transform component into variable
    }
	
	// Update is called once per frame
	void Update () {                            // Handles Input and player movement
        if (Input.GetKey(KeyCode.UpArrow)) {    // Move Forward
            tf.position += tf.right * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow)) { // Rotate Right
            tf.Rotate(0,0,-rotSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {  // Rotate Left
            tf.Rotate(0,0,rotSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {  // Shoot bullet
            Shoot();
        }
    }

    // Create a function fo the player to be able to shoot
    void Shoot() {
        if (bullet != null) {                                                   // If have a bullet gameObject
            Instantiate(bullet, tf.position + (tf.right * 1.5f), tf.rotation);  // Instantiate our object
        } else {
            Debug.Log("Warning: No gameObject attached");
        }
    }
}
