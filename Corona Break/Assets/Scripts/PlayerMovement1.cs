using UnityEngine;

public class PlayerMovement1 : MonoBehaviour{
    public Animator topAnimator;
    public Animator bottomAnimator;

    public Vector3 movement;
    Vector3 aim ;
    Vector2 shootingDirection;
    
    float speed;
    public float moveSpeed = 2f;
    public float aimDistance = 0.24f;
    public float bulletSpeed = 5.0f;
    public float fireRate = 0.5f;
    private float nextFire = 0.2f;
    public float bulletTestAlign;

    public Joystick joyStick;
    public Joystick aimJoyStick;
    public GameObject bulletPrefab;
    public GameObject crossHair;
    public Rigidbody2D rb;
    // public ParticleSystem dust;
    void Update(){

      PlayerMove();
      AimAndShoot();
      CharacterAnimation();     
    
    }

    void PlayerMove(){
    
      movement = new Vector3(joyStick.Horizontal,joyStick.Vertical,0.0f);
      movement *= speed;
      // CreateDust();
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
      rb.velocity = movement;
    }
    void CharacterAnimation(){
        bottomAnimator.SetFloat("Horizontal", movement.x);
        bottomAnimator.SetFloat("Vertical", movement.y);
        bottomAnimator.SetFloat("Magnitude", movement.magnitude);

        topAnimator.SetFloat("MoveHorizontal", movement.x);
        topAnimator.SetFloat("MoveVertical", movement.y);
        topAnimator.SetFloat("MoveMagnitude", movement.magnitude);
    }
    void AimAnimation(){

        topAnimator.SetFloat("AimHorizontal", aim.x);
        topAnimator.SetFloat("AimVertical", aim.y);
        topAnimator.SetFloat("AimMagnitude", aim.magnitude);
        topAnimator.SetBool("Aim", true);
    }
    private void AimAndShoot(){

      aim = new Vector3(aimJoyStick.Horizontal,aimJoyStick.Vertical,0.0f);
      shootingDirection = new Vector2(aimJoyStick.Horizontal,aimJoyStick.Vertical);
     
      if(aim.magnitude > 0.0f){
        aim.Normalize();
        aim *= aimDistance;
        crossHair.transform.localPosition = aim;
        crossHair.SetActive(true);
        
        shootingDirection.Normalize();
        if(aimJoyStick.Horizontal >= .5f){
        Fire();
        AimAnimation();
        } 
        else if (aimJoyStick.Horizontal <= -.5f){
        Fire();
        AimAnimation();
        }
        else if(aimJoyStick.Vertical >= .5f){
        Fire();
        AimAnimation();
        } 
        else if (aimJoyStick.Vertical <= -.5f){
        Fire();
        AimAnimation();
        }
        else{
        topAnimator.SetBool("Aim", false);
        }
      }
      else{
        crossHair.SetActive(false);
      }

    }

    private void Fire(){
      if(Time.time > nextFire){
        nextFire = Time.time + fireRate; 

        GameObject bullet = Instantiate(bulletPrefab, transform.position + (Vector3.up * bulletTestAlign), Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.velocity = shootingDirection * bulletSpeed;
        bulletScript.sprayer = gameObject;
        
        Destroy(bullet, 1.0f);
      }
    }

    // void CreateDust(){
    //   dust.Play();  
    // }
}
