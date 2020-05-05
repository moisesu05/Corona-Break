using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    //  public Animator animator;
 //   public float movespeed = 5;
    // Update is called once per frame
    void Update()
    {
       // animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        float x = Input.GetAxis ("Horizontal") * Time.deltaTime * 40;
        float y = Input.GetAxis ("Vertical") * Time.deltaTime * 40;

        transform.Translate (x , y, 0);
    }
}