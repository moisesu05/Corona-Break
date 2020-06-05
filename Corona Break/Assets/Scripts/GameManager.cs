using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private EnemySpawner spawner;
    public float timeStart;
    public bool timerActive = false;
    public Text textBox, endTextBox;
    public bool gameHasEnded = false;
    public GameObject gameOverText, restartButton, player, textToScore, scoreCounter,score;

     void Awake(){
        spawner = GetComponent<EnemySpawner>();
     }
     void Start(){
        textBox.text = timeStart.ToString("F2");

        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        textToScore.SetActive(false);
        score.SetActive(false);

        spawner.StartWave();
    }
    void Update(){
        Timer();
    }

    void Timer(){
        if(timerActive){
            timeStart += Time.deltaTime * 10;
            textBox.text = timeStart.ToString("0");
        }
    }
     public void EndGame(){
        if(gameHasEnded == false){

            gameHasEnded = true;
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            player.SetActive(false);
            textToScore.SetActive(true);
            scoreCounter.SetActive(false);
            score.SetActive(true);

            endTextBox.text = textBox.text;
            timerActive = !timerActive; 
        }
        
    }
}
