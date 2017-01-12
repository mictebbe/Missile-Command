using UnityEngine;
using System.Collections;

public class ExplosionCollision : MonoBehaviour {
    public float maxExplosionCollision=30;
    public float grothAndShrinkRate = 1;
    
    private bool growing = true;

    void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Missile explodes from Explosion.");

        if (other.gameObject.GetComponent<enemyMissileScript>() != null)
        {
            other.gameObject.GetComponent<enemyMissileScript>().Explode();
            GameManager.Instance.addToScore("Enemy Missile destroyed");
        }

       
    }
    // Use this for initialization
    void Start () {
        
        
    }
	
	// Update is called once per frame
    //TODO: Coroutine
	void Update () {



       // gameObject.GetComponent<SphereCollider>().radius += 2f;
        if ( gameObject.GetComponent<SphereCollider>() != null)
          {

            

      
            if (growing)
            {
                gameObject.GetComponent<SphereCollider>().radius += grothAndShrinkRate;
              //  Debug.Log("growing"+ gameObject.GetComponent<SphereCollider>().radius);

            }else{
                gameObject.GetComponent<SphereCollider>().radius -= grothAndShrinkRate;
              //  Debug.Log("shrinking "+ gameObject.GetComponent<SphereCollider>().radius);
            }

            if (gameObject.GetComponent<SphereCollider>().radius >= maxExplosionCollision)
            {
                growing = false;
               // Debug.Log("growing is false");
            }

            if (gameObject.GetComponent<SphereCollider>().radius <= 0)
            {
               // Debug.Log("dead" + gameObject.GetComponent<SphereCollider>().radius);
                Destroy(gameObject);
                
            }

          }
          

    }
}
