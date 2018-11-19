using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;  // Create a singleton variable for this class 

    public int playerLives;

    // On load run this
    void Awake() {
        // As long as there is not an instance already set
        if (instance == null) {
            instance = this; // Store THIS instance of the class in the instance variable
            DontDestroyOnLoad(gameObject); // Don't delete this object if we load a new scene
        } else {
            Destroy(this.gameObject); // There can only be one - delete new object
            Debug.Log("Warning: A second game manager was detected and destoryed.");
        }
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (playerLives == 0) {
            // Destory all gameObject than quit the game
            //Application.Quit();
        }
	}
}
