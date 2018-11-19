using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    private Transform tf;
    private Vector2 randomPos;

    public List<GameObject> enemies;
    public List<Transform> spawnLocation;

    // Use this for initialization
    void Start () {
        tf = GetComponent<Transform>();
        foreach (Transform child in transform) {
            spawnLocation.Add(child);
        }
    }

    // Update is called once per frame
    void Update () {
        randomPos = Random.insideUnitCircle;
        randomPos *= 200;
        Transform player = PlayerController.instance.gameObject.transform;
        Vector3 newPos = new Vector3(player.position.x + randomPos.x, player.position.y + randomPos.y, 0);

        GameObject spawnEnemy = enemies[Random.Range(0, enemies.Count)];
        Instantiate(spawnEnemy, newPos, spawnEnemy.transform.rotation);
    }
}
