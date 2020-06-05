using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(WaveTimer))]
[RequireComponent(typeof(WaveUI))]
public class EnemySpawner : MonoBehaviour
{
    private int currentWave = 0;
    private int enemiesInWave;
    private int enemiesToSpawn;
    private GameManager gameManager;
    private WaveUI waveUI;
    private WaveTimer waveTimer;

    public float waveDelay;
    public float spawnDelay = 0f;
    // public float spawnRate = 10f;
    public int enemyIncreasePerRound;
    public GameObject enemyPrefab;    
    // public GameObject enemy;
    public Vector3 enemySpawnArea;
    
    //TODO: Error on ine 26
    //TODO: Main Menu
    //TODO: Particles
    void Awake(){
        gameManager = GetComponent<GameManager>();
        waveTimer = GetComponent<WaveTimer>();
        waveUI = GetComponent<WaveUI>();
    }
    void Start(){

        waveUI.HideUI();
    
    }

    public void StartWave(){
        
        if(gameManager.gameHasEnded){
            return;
        }
        
        currentWave += 1;
        
        enemiesInWave = enemyIncreasePerRound * currentWave;
        enemiesToSpawn = enemiesInWave;

        waveUI.UpdateUI(currentWave, enemiesInWave);
        
        StartCoroutine(Spawn());
    }
   
    IEnumerator Spawn(){
        for(int i = 0; i < enemiesToSpawn; i++){

            if(gameManager.gameHasEnded){
                break;
            }

            GameObject enemy = Instantiate(enemyPrefab, RandomSpawner(), Quaternion.identity);
        }
        yield return new WaitForSeconds(spawnDelay);
    }

    void EndWave(){
        waveUI.HideUI();
        FindObjectOfType<AudioManager>().Play("WaveComplete");
        waveTimer.StartTimer(waveDelay);
    }

    public void EnemyDied(){
        enemiesInWave -= 1;  

        waveUI.UpdateUI(currentWave, enemiesInWave);

        if(enemiesInWave == 0){
           EndWave();
        }
   }

     public Vector3 RandomSpawner(){

        return  new Vector3(Random.Range(-enemySpawnArea.x /2, enemySpawnArea.x /2),
                                                    Random.Range(-enemySpawnArea.y /2, enemySpawnArea.y /2), 0); 
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