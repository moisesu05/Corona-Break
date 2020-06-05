using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    private EnemySpawner spawner;
    private Transform target;
    public GameObject enemyParticle;

    void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance){ 
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); 
        }
    }
     void OnCollisionEnter2D (Collision2D collision){

        if(collision.gameObject.tag.Equals("Player")){
            EnemyParticle();
        }

    }
    void EnemyParticle(){
      Instantiate(enemyParticle, transform.position, Quaternion.identity);  
    }
}
