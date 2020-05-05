using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Animator animator;
    public Vector3 movement;
    float speed;
    
    public float moveSpeed = 5f;
    public float aimDistance = 0.4f;
     Vector2 shootingDirection;
    public float bulletSpeed = 5.0f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    public Joystick joyStick;
    public Joystick aimJoyStick;
    
    public GameObject bulletPrefab;
    public GameObject crossHair;

    void Update(){

      PlayerMove();
      AimAndShoot();
      CharacterAnimation();     
    
    }

    void PlayerMove(){

      movement = new Vector3(joyStick.Horizontal,joyStick.Vertical,0.0f);
      movement *= speed;

      if(joyStick.Horizontal >= .5f){
        speed = moveSpeed;
      } 
      else if (joyStick.Horizontal <= -.5f){
        speed = moveSpeed;
      }
      else if(joyStick.Vertical >= .5f){
        speed = moveSpeed;
      } 
      else if (joyStick.Vertical <= -.5f){
        speed = moveSpeed;
      }
      else{
        speed = 0;
      }
      transform.position = transform.position + movement * Time.deltaTime;  
    }
    void CharacterAnimation(){

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

    }
    private void AimAndShoot(){

      Vector3 aim = new Vector3(aimJoyStick.Horizontal,aimJoyStick.Vertical,0.0f);
      shootingDirection = new Vector2(aimJoyStick.Horizontal,aimJoyStick.Vertical);
     
      if(aim.magnitude > 0.0f){
        aim.Normalize();
        aim *= aimDistance;
        crossHair.transform.localPosition = aim;
        crossHair.SetActive(true);
        
        shootingDirection.Normalize();
        if(aimJoyStick.Horizontal >= .5f){
        Fire();
        } 
        else if (aimJoyStick.Horizontal <= -.5f){
        Fire();
        }
        else if(aimJoyStick.Vertical >= .5f){
        Fire();
        } 
        else if (aimJoyStick.Vertical <= -.5f){
        Fire();
        }
        else{
        
        }
      }
      else{
        crossHair.SetActive(false);
      }

    }

    private void Fire(){
      if(Time.time>nextFire){

        nextFire = Time.time + fireRate;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * bulletSpeed;
        Destroy(bullet, 1.0f);
      }
      
    }
}
