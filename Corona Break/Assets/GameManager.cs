using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject gameOverText, restartButton, player;

    void Start(){
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
    }
    public void EndGame(){
        if(gameHasEnded == false){
            Debug.Log("GAME OVER!");
             
            gameHasEnded = true;
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            player.SetActive(false);
        }
        
    }
}
