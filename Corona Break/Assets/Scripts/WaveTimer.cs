using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaveTimer : MonoBehaviour
{
    public float timerValue;
    private bool runTimer = false;
    public Text timerText;
    public UnityEvent timerEvent;    
    public GameManager gameManager;

    void Start(){
        HideTimerUI();
        gameManager = GetComponent<GameManager>();
    }
    public void StartTimer(float startTimerValue){
        timerValue = startTimerValue;
        runTimer = true;
    }
    public void StopTimer(){
        runTimer = false;
        HideTimerUI();
    }
    private void Update(){
        if(runTimer){

            timerValue -= Time.deltaTime;
            UpdateTimerUI();
            
            if(timerValue <= 0f){

                StopTimer();

                if(timerEvent != null){

                    timerEvent.Invoke();
                }
            }
        }
    }
    private void UpdateTimerUI(){
        if(timerValue <= 0f){
            timerText.text = "Start";
        }
        else{
            timerText.text = timerValue.ToString("0");
        }
    }
    private void HideTimerUI(){
        timerText.text = "";
    }
}
