using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;  // Create a singleton variable for this class
    public static int score;             // Create a variable to keep track of score

    private float respawnTime = 5;      // Create a variable to detemine how long till respawn
    private float timeToRespawn;        // Create a variable to count the second to respawn
    private bool gameOver;              // Create a variable to tell the game to stop running

    public GameObject player;           // Create a variable to store a playerController gameObject
    public int playerLives = 1;         // Create a variable to keep track of how many lives the player has

    // On load run this
    void Awake() {
        if (instance == null) {             // As long as there is not an instance already set
            instance = this;                // Store THIS instance of the class in the instance variable
            DontDestroyOnLoad(gameObject);  // Don't delete this object if we load a new scene
        } else {
            Destroy(this.gameObject);                                                // There can only be one - delete new object
            Debug.Log("Warning: A second game manager was detected and destoryed."); // Warning for designers
        }
    }

    // Use this for initialization
    void Start () {
        Instantiate(player, new Vector3(0, 0, 0), player.transform.rotation);   // Instantiate our player gameObject
        timeToRespawn = 0;                                                      // Intializing the time to respawn count
	}
	
	// Update is called once per frame
	void Update () {
        if (playerLives == 0) {                         // If player has no lives left
            Debug.Log("You got a score of: " + score);
            gameOver = true;                            // Declare that the game is over
            Application.Quit();                         // Close the program
        }

        if (PlayerController.instance == null && !gameOver) { // if there is not playerController in the scene;
            timeToRespawn++;                                  // Start the the respawn timer

            if (timeToRespawn * Time.deltaTime > respawnTime) { // If the time to respawn in greater than the respawn time
                Respawn();                                      // Respawn player
                timeToRespawn = 0;                              // Reset the time to respawn back to zero
            }
        }
	}

    void OnTriggerExit2D(Collider2D collision) {
        Destroy(collision.gameObject);              // Destory any object that leave the playspace

        if (collision.gameObject.tag == "Enemy") {  // If collision is an enemy
            EnemyController.enemies -= 1;           // Update enemy count
        }
    }

    public void PlayerDied() {
        playerLives -= 1;        // Take a players life away
    }

    void Respawn() {
        Instantiate(player, new Vector3(0, 0, 0), player.transform.rotation); // Insatantiate player
    }
}
