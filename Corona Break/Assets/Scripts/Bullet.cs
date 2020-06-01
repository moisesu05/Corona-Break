using UnityEngine;

public class Bullet : MonoBehaviour
{
   public Vector2 velocity =  new Vector2(0.0f, 0.0f);
   public Vector2 offset = new Vector2(0.0f, 0.0f);
   public GameObject sprayer;
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

                    Destroy(gameObject);
                    Destroy(other);
                    Debug.Log(other.name);
                    break;
                }
                if(other.CompareTag("Walls")){

                    Destroy(gameObject);
                    Debug.Log(other.name);
                    break;
                }
           }
       }
       transform.position = newPosition;
   } 
}
