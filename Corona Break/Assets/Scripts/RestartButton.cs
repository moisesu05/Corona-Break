﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
   public void RestartScene(){
       SceneManager.LoadScene("1");
   }
}
