using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int currentWave = 0;
    private int enemiesInWave;
    private int enemiesToSpawn;
    private GameManager gameManager;
    public float waveDelay;
    public float spawnDelay = 0f;
    // public float spawnRate = 10f;
    public int enemyIncreasePerRound;
    public GameObject enemyPrefab;    
    // public GameObject enemy;
    public Vector3 enemySpawnArea;
    public WaveTimer waveTimer;
    
    //TODO: Error on ine 23
    //TODO: Main Menu
    //TODO: Partices
    void Start(){
        gameManager = GetComponent<GameManager>();
        waveTimer = GetComponent<WaveTimer>();
        gameManager.HideUI();    
    }

    void StartWave(){

        if(gameManager.gameHasEnded){
            return;
        }
       
        currentWave += 1;
        
        enemiesInWave = enemyIncreasePerRound * currentWave;
        enemiesToSpawn = enemiesInWave;

        gameManager.UpdateUI(currentWave, enemiesInWave);
        
        StartCoroutine(Spawn());
    }
    void EndWave(){
        gameManager.HideUI();
        waveTimer.StartTimer(waveDelay);
    }
    IEnumerator Spawn(){
        for(int i = 0; i < enemiesToSpawn; i++){

            if(gameManager.gameHasEnded == true){
                break;
            }

            GameObject enemy = Instantiate(enemyPrefab, RandomSpawner(), Quaternion.identity);
        }
        yield return new WaitForSeconds(spawnDelay);
    }
   public Vector3 RandomSpawner(){

        return  new Vector3(Random.Range(-enemySpawnArea.x /2, enemySpawnArea.x /2),
                                                    Random.Range(-enemySpawnArea.y /2, enemySpawnArea.y /2), 0); 
   }
   void EnemyDied(){
        enemiesInWave -= 1;  

        gameManager.UpdateUI(currentWave, enemiesInWave);

        if(enemiesInWave == 0){
           EndWave();
        }
   }
}
  // void Update()
    // {   
    //     if(Time.time > spawnDelay){
    //         SpawnNextEnemy();
    //         spawnDelay = Time.time + spawnRate;
    //     }
    // }

    //     void SpawnNextEnemy(){
//         Vector3 enemyPos = new Vector3(Random.Range(-enemySpawnArea.x /2, enemySpawnArea.x /2),
//                                                     Random.Range(-enemySpawnArea.y /2, enemySpawnArea.y /2), 0); 

//         // enemy = Instantiate(enemyPrefab, enemyPos, Quaternion.identity);                          
//    }