using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    private Vector2 randomPos;              // Create a variable to store a vector2
    private bool canSpawn;                  // Create a variable to check if no errors
    private GameObject enemiesLoc;          // Create a variable to create a gameObject
    public List<GameObject> enemies;        // Create a variable to hold a list of gameObjects
    public List<Transform> spawnLocation;   // Create a variable to hold a list of transform

    // Use this for initialization
    void Start () {
        if (enemies.Count > 0) {    // If our list has elements in it
            canSpawn = true;        // Set canSpawn to true for over code to run
        }
        foreach (Transform child in transform) {    // Find every child's tranform component
            spawnLocation.Add(child);               // Add child's tranform to our list
        }

        if (!GameObject.Find("Bullets")) {           // If there isn't already a Bullets gameObject
            enemiesLoc = new GameObject("Enemies");  // Give our gameObject a name
        } else {
            enemiesLoc = GameObject.Find("Enemies");  // Set to current gameObject

            if (enemiesLoc.transform.position != new Vector3(0, 0, 0)) {    // If the enemies gameobject position isn't at the orgin
                enemiesLoc.transform.position = new Vector3(0, 0, 0);       // Move to the game World's orgin
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (canSpawn && PlayerController.instance != null) {    // If have elements in our list and we have a playercontroller in our scene
            if (EnemyController.enemies < 3) {                  // If there are less than 3 enemies currently in the scene
                SpawnEnemy();                                   // SpawnEnemy
            }
        }
    }

    void SpawnEnemy() {
        randomPos = Random.insideUnitCircle;                                                // Get a random point inside a circle with a radius of 1
        randomPos *= 2;                                                                     // Strech the random vector2 2 units

        Transform location = spawnLocation[Random.Range(0, spawnLocation.Count)];           // Pick a random location to spawn enemy
        Vector3 newPos = location.position + ( Vector3 )randomPos;                          // Create a Vector3 at a random position
        GameObject spawnEnemy = enemies[Random.Range(0, enemies.Count)];                    // Pick a random enemy
        GameObject clone = Instantiate(spawnEnemy, newPos, spawnEnemy.transform.rotation);  // Instantiate that random enemy that was picked
        clone.transform.parent = enemiesLoc.transform;                                      // Make child of bullets game object
    }
}
