using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    private Vector2 randomPos;          // Create a variable to store a vector2
    private bool canSpawn;              // Create a variable to check if no errors
    public List<GameObject> enemies;    // Create a variable to hold a list of gameObjects

    // Use this for initialization
    void Start () {
        if (enemies.Count > 0) {    // If our list has elements in it
            canSpawn = true;        // Set canSpawn to true for over code to run
        }
    }

    // Update is called once per frame
    void Update () {
        if (canSpawn) {                             // If have elements in our list
            randomPos = Random.insideUnitCircle;    // Get a random point inside a circle with a radius of 1, i.e: (0.3,0.8)
            randomPos *= 100;                       // Strech the random vector2 just got above 100 units

            if (PlayerController.instance != null) {                                  // If there is a playercontroller in our scene
                Transform player = PlayerController.instance.gameObject.transform;    // Get the transform of the gameObject with the playercontroller
                Vector3 newPos = player.position + ( Vector3 )randomPos;              // Create a Vector3 at a random position
                if (EnemyController.enemies < 3) {                                    // If there are less than 3 enemies currently in the scene
                    GameObject spawnEnemy = enemies[Random.Range(0, enemies.Count)];  // Pick a random enemy
                    Instantiate(spawnEnemy, newPos, spawnEnemy.transform.rotation);   // Instantiate that random enemy that was picked
                }
            }
        }
    }
}
