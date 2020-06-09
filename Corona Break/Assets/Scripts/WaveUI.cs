using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Text waveText, enemyTextCount;

    public void UpdateUI(int wave, int enemies){
        waveText.text = "wave: " + wave.ToString();
        enemyTextCount.text = "enemy: " + enemies.ToString(); 
    }

    public void HideUI(){
        waveText.text = "";
        enemyTextCount.text = "";
    }
}
