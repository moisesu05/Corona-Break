using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

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

            if (currentHealth == 0){
                FindObjectOfType<GameManager>().EndGame();
            }
        }
      }
    }
}
