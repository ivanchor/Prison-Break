using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // Enemy to spawn
    public GameObject enemy;
    // Spawn area (x, y)
    public Vector2 spawnArea;
    // Spawn Timer
    public float spawnTimer;

    // Spawned enemies chase after "player"
    public Transform player;

    public HudManager hud;

    public int enemyCount = 0;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            SpawnEnemy();
            if (enemyCount % 5 == 0)
            {
                spawnTimer -= 0.1f;
            }

            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = new Vector3(
            UnityEngine.Random.Range(-spawnArea.x, spawnArea.x),
            UnityEngine.Random.Range(-spawnArea.y, spawnArea.y),
            0f
        );
        
        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<EnemyController>().targetDestination = player;
        newEnemy.GetComponent<EnemyController>().hud = hud;

        enemyCount++;
    }
}
