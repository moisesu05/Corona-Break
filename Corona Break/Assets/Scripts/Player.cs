using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject playerParticle;

    void Start()
    {
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
            FindObjectOfType<AudioManager>().Play("PlayerHit");

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
