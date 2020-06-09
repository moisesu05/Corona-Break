using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject playerParticle;
    private BloodSplashRandom bloodSplash;
    private CameraShake shake;

    void Awake(){
       bloodSplash = FindObjectOfType<BloodSplashRandom>();                 
    }
    void Start()
    {
        shake = Camera.main.GetComponent<CameraShake  >();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        
        healthBar.SetHealth(currentHealth);
    }
    void OnCollisionEnter2D (Collision2D collision){

        GameObject other = collision.collider.gameObject;
        
      if(other != gameObject){
        if (other.CompareTag("Enemy")){
            
            TakeDamage(20);
            Destroy(other);
            FindObjectOfType<EnemySpawner>().EnemyDied();
            PlayerParticle();
            bloodSplash.SpawnEnemySplash();
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            StartCoroutine(shake.Shake(.14f, .4f));

            if (currentHealth == 0){
              FindObjectOfType<AudioManager>().Play("PlayerDeath");
              PlayerParticle();
              FindObjectOfType<GameManager>().EndGame();
                
            }
        }
      }
    }
    void PlayerParticle(){
      Instantiate(playerParticle, transform.position, Quaternion.identity);  
    }
}
