using UnityEngine;

public class Bullet : MonoBehaviour
{
   private EnemySpawner spawner;
   public GameObject bulletParticle;
   public GameObject enemyParticle;
   public GameObject sprayer;
   public Vector2 velocity =  new Vector2(0.0f, 0.0f);
   public Vector2 offset = new Vector2(0.0f, 0.0f);
   private BloodSplashRandom bloodSplash;

   private RipplePostProcessor camRipple;
   
   void Start(){
       camRipple = Camera.main.GetComponent<RipplePostProcessor>();
       bloodSplash = FindObjectOfType<BloodSplashRandom>();
       spawner = FindObjectOfType<EnemySpawner>();
   }
   void Update(){

       Vector2 currentPosition = new Vector2(transform.position.x , transform.position.y);
       Vector2 newPosition = currentPosition + velocity * Time.deltaTime;
       
       Debug.DrawLine(currentPosition + offset, newPosition + offset, Color.red);

       RaycastHit2D[] hits = Physics2D.LinecastAll(currentPosition + offset, newPosition + offset);

       foreach(RaycastHit2D hit in hits){
           GameObject other = hit.collider.gameObject;
           if(other != sprayer){
            //    Debug.Log(hit.collider.gameObject);
                if(other.CompareTag("Enemy")){
                    BulletParticle();
                    EnemyParticle();
                    camRipple.RippleEffect();
                    FindObjectOfType<AudioManager>().Play("EnemyHit");
                    spawner.EnemyDied();
                    
                    Destroy(gameObject);
                    Destroy(other);
                    bloodSplash.SpawnEnemySplash();
                    Debug.Log(other.name);
                    break;
                }
                if(other.CompareTag("Walls")){
                    BulletParticle();
                    FindObjectOfType<AudioManager>().Play("WallHit");
                    Destroy(gameObject);
                    Debug.Log(other.name);
                    break;
                }
           }
       }
       transform.position = newPosition;
   } 
    void BulletParticle(){
      Instantiate(bulletParticle, transform.position, Quaternion.identity);  
    }
    public void EnemyParticle(){
      Instantiate(enemyParticle, transform.position, Quaternion.identity);  
    }
}
