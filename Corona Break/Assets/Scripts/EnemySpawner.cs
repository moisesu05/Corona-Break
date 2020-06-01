using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float nextSpawn = 0f;
    public float spawnRate = 10f;
    public GameObject enemyPrefab;    
    public Vector3 enemySpawnArea;
    // Update is called once per frame
    void Update()
    {   
        if(Time.time > nextSpawn){
            SpawnNextEnemy();
            nextSpawn = Time.time + spawnRate;
        }
    }
    void SpawnNextEnemy(){
        Vector3 enemyPos = new Vector3(Random.Range(-enemySpawnArea.x /2, enemySpawnArea.x /2),
                                                    Random.Range(-enemySpawnArea.y /2, enemySpawnArea.y /2), 0);                                          
        GameObject kalaban = Instantiate(enemyPrefab, enemyPos, Quaternion.identity);  
        // Enemy enemyScript = GetComponent<Enemy>();                          
   }
}
