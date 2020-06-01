using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timeStart;
    public bool timerActive = false;
    public Text textBox, endTextBox, waveText, enemyTextCount;
    public bool gameHasEnded = false;
    public GameObject gameOverText, restartButton, player, textToScore, scoreCounter,score;
    EnemySpawner spawner;

    void Start(){
        textBox.text = timeStart.ToString("F2");

        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        textToScore.SetActive(false);
        score.SetActive(false);
    }
    void Update(){
     Timer();
    }

    public void UpdateUI(int wave, int enemies){
        waveText.text = wave.ToString();
        enemyTextCount.text = enemies.ToString(); 
    }

    public void HideUI(){
        waveText.text = "";
        enemyTextCount.text = "";
    }
    void Timer(){
        if(timerActive){
            timeStart += Time.deltaTime;
            textBox.text = timeStart.ToString("F2");
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

            endTextBox.text = textBox.text+" secs";
            timerActive = !timerActive;
            spawner.StopAllCoroutines();
        }
        
    }
}
