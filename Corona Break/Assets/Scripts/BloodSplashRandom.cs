using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplashRandom : MonoBehaviour
{
    public GameObject enSplash1, enSplash2, enSplash3;
    int whatToSpawnEn;
  
    public void SpawnEnemySplash(){
        whatToSpawnEn = Random.Range(1,4);
        switch(whatToSpawnEn){
            case 1:
                Instantiate(enSplash1, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enSplash2, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(enSplash3, transform.position, Quaternion.identity);
                break;
            
        }
    }
}
